using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Windows.Forms;

namespace FlagQuiz
{
    /// <summary>
    /// Класс для управления викториной
    /// </summary>
    public class QuizManager
    {
        private string xmlFilePath;
        private string quizTitle;
        private string quizDescription;

        // Структура: тема -> уровень сложности -> список вопросов
        private Dictionary<string, Dictionary<int, List<Question>>> questions;
        private List<string> themes;

        // Параметры текущей игры
        private string currentTheme;
        private int currentLevel;
        private List<Question> currentQuestions;
        private int currentQuestionIndex;
        private int currentScore;
        private int totalQuestions;
        private int pointsPerQuestion;
        private int timePerQuestion;

        // Случайный генератор
        private Random random;

        public QuizManager(string xmlPath)
        {
            xmlFilePath = xmlPath;
            questions = new Dictionary<string, Dictionary<int, List<Question>>>();
            themes = new List<string>();
            random = new Random();
            LoadXml();
        }

        /// <summary>
        /// Загрузка XML файла
        /// </summary>
        private void LoadXml()
        {
            if (!File.Exists(xmlFilePath))
            {
                throw new Exception($"Файл {xmlFilePath} не найден!");
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            // Заголовок
            XmlNode titleNode = doc.SelectSingleNode("//title");
            if (titleNode != null)
                quizTitle = titleNode.InnerText;

            XmlNode descNode = doc.SelectSingleNode("//description");
            if (descNode != null)
                quizDescription = descNode.InnerText;

            // Загрузка тем
            XmlNodeList themeNodes = doc.SelectNodes("//themes/theme");
            foreach (XmlNode themeNode in themeNodes)
            {
                string themeName = themeNode.Attributes["name"]?.Value;
                if (string.IsNullOrEmpty(themeName)) continue;

                themes.Add(themeName);
                questions[themeName] = new Dictionary<int, List<Question>>();

                // Загрузка уровней
                XmlNodeList levelNodes = themeNode.SelectNodes("level");
                foreach (XmlNode levelNode in levelNodes)
                {
                    int difficulty = int.Parse(levelNode.Attributes["difficulty"]?.Value ?? "1");
                    questions[themeName][difficulty] = new List<Question>();

                    // Загрузка вопросов
                    XmlNodeList questionNodes = levelNode.SelectNodes("question");
                    foreach (XmlNode qNode in questionNodes)
                    {
                        Question q = new Question();

                        // Текст вопроса
                        XmlNode textNode = qNode.SelectSingleNode("text");
                        if (textNode != null)
                            q.Text = textNode.InnerText;

                        // Изображение
                        XmlNode imageNode = qNode.SelectSingleNode("image");
                        if (imageNode != null)
                            q.ImagePath = imageNode.InnerText;

                        // Подсказка
                        XmlNode hintNode = qNode.SelectSingleNode("hint");
                        if (hintNode != null)
                            q.Hint = hintNode.InnerText;

                        // Варианты ответов
                        XmlNodeList answerNodes = qNode.SelectNodes("answers/answer");
                        int answerIndex = 0;
                        foreach (XmlNode aNode in answerNodes)
                        {
                            string answerText = aNode.InnerText;
                            q.Answers.Add(answerText);

                            if (aNode.Attributes["correct"]?.Value == "true")
                                q.CorrectAnswerIndex = answerIndex;

                            answerIndex++;
                        }

                        questions[themeName][difficulty].Add(q);
                    }
                }
            }
        }

        /// <summary>
        /// Получить список тем
        /// </summary>
        public List<string> GetThemes()
        {
            return themes;
        }

        /// <summary>
        /// Получить название викторины
        /// </summary>
        public string QuizTitle
        {
            get { return quizTitle; }
        }

        /// <summary>
        /// Получить описание
        /// </summary>
        public string QuizDescription
        {
            get { return quizDescription; }
        }

        /// <summary>
        /// Проверить, есть ли вопросы для темы и уровня
        /// </summary>
        public bool HasQuestions(string theme, int level)
        {
            if (!questions.ContainsKey(theme)) return false;
            if (!questions[theme].ContainsKey(level)) return false;
            return questions[theme][level].Count > 0;
        }

        /// <summary>
        /// Начать игру
        /// </summary>
        public void StartGame(string theme, int level, int questionsToTake = 5)
        {
            currentTheme = theme;
            currentLevel = level;

            if (!questions.ContainsKey(theme) || !questions[theme].ContainsKey(level))
                throw new Exception("Нет вопросов для выбранной темы и уровня");

            // Получить все вопросы уровня
            List<Question> allQuestions = new List<Question>(questions[theme][level]);

            // Перемешать вопросы
            currentQuestions = allQuestions.OrderBy(x => random.Next()).Take(questionsToTake).ToList();

            currentQuestionIndex = 0;
            currentScore = 0;
            totalQuestions = currentQuestions.Count;

            // Параметры уровня
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);
            XmlNode levelNode = doc.SelectSingleNode($"//theme[@name='{theme}']/level[@difficulty='{level}']");

            if (levelNode != null)
            {
                pointsPerQuestion = int.Parse(levelNode.Attributes["points_per_question"]?.Value ?? "10");
                timePerQuestion = int.Parse(levelNode.Attributes["time_seconds"]?.Value ?? "30");
            }
        }

        /// <summary>
        /// Получить текущий вопрос
        /// </summary>
        public Question GetCurrentQuestion()
        {
            if (currentQuestionIndex < currentQuestions.Count)
                return currentQuestions[currentQuestionIndex];
            return null;
        }

        /// <summary>
        /// Ответить на вопрос
        /// </summary>
        public bool AnswerCurrentQuestion(int answerIndex, out int earnedPoints)
        {
            Question q = GetCurrentQuestion();
            earnedPoints = 0;

            if (q == null) return false;

            bool isCorrect = q.IsCorrect(answerIndex);
            if (isCorrect)
            {
                earnedPoints = pointsPerQuestion;
                currentScore += earnedPoints;
            }

            currentQuestionIndex++;
            return isCorrect;
        }

        /// <summary>
        /// Есть ли следующий вопрос
        /// </summary>
        public bool HasNextQuestion()
        {
            return currentQuestionIndex < currentQuestions.Count;
        }

        /// <summary>
        /// Получить текущий счет
        /// </summary>
        public int CurrentScore
        {
            get { return currentScore; }
        }

        /// <summary>
        /// Получить максимальный балл
        /// </summary>
        public int MaxScore
        {
            get { return totalQuestions * pointsPerQuestion; }
        }

        /// <summary>
        /// Получить процент правильных ответов
        /// </summary>
        public int GetPercentage()
        {
            if (totalQuestions == 0) return 0;
            return (currentScore * 100) / MaxScore;
        }

        /// <summary>
        /// Получить количество вопросов в текущем сеансе
        /// </summary>
        public int TotalQuestions
        {
            get { return totalQuestions; }
        }

        /// <summary>
        /// Получить номер текущего вопроса (1-based)
        /// </summary>
        public int CurrentQuestionNumber
        {
            get { return currentQuestionIndex + 1; }
        }

        /// <summary>
        /// Получить время на вопрос (секунд)
        /// </summary>
        public int TimePerQuestion
        {
            get { return timePerQuestion; }
        }

        /// <summary>
        /// Получить очки за вопрос
        /// </summary>
        public int PointsPerQuestion
        {
            get { return pointsPerQuestion; }
        }

        /// <summary>
        /// Получить текущую тему
        /// </summary>
        public string CurrentTheme
        {
            get { return currentTheme; }
        }

        /// <summary>
        /// Получить текущий уровень
        /// </summary>
        public int CurrentLevel
        {
            get { return currentLevel; }
        }

        /// <summary>
        /// Проверить, можно ли перейти на следующий уровень (нужно 80% баллов)
        /// </summary>
        public bool CanAdvanceToNextLevel()
        {
            return GetPercentage() >= 80;
        }

        /// <summary>
        /// Добавить новый вопрос (для админа)
        /// </summary>
        public void AddQuestion(string theme, int level, Question question)
        {
            if (!questions.ContainsKey(theme))
            {
                questions[theme] = new Dictionary<int, List<Question>>();
                themes.Add(theme);
            }

            if (!questions[theme].ContainsKey(level))
            {
                questions[theme][level] = new List<Question>();
            }

            questions[theme][level].Add(question);

            // Сохранить в XML
            SaveToXml();
        }

        /// <summary>
        /// Сохранить данные в XML
        /// </summary>
        private void SaveToXml()
        {
            XmlDocument doc = new XmlDocument();

            // Корневой элемент
            XmlElement root = doc.CreateElement("quiz");
            doc.AppendChild(root);

            // Заголовок
            XmlElement titleElem = doc.CreateElement("title");
            titleElem.InnerText = quizTitle;
            root.AppendChild(titleElem);

            // Описание
            XmlElement descElem = doc.CreateElement("description");
            descElem.InnerText = quizDescription;
            root.AppendChild(descElem);

            // Темы
            XmlElement themesElem = doc.CreateElement("themes");
            root.AppendChild(themesElem);

            foreach (string themeName in themes)
            {
                XmlElement themeElem = doc.CreateElement("theme");
                themeElem.SetAttribute("name", themeName);
                themesElem.AppendChild(themeElem);

                foreach (var levelPair in questions[themeName])
                {
                    XmlElement levelElem = doc.CreateElement("level");
                    levelElem.SetAttribute("difficulty", levelPair.Key.ToString());
                    levelElem.SetAttribute("name", levelPair.Key == 1 ? "Легкий" : (levelPair.Key == 2 ? "Средний" : "Сложный"));
                    levelElem.SetAttribute("points_per_question", (levelPair.Key == 1 ? "10" : (levelPair.Key == 2 ? "20" : "30")));
                    levelElem.SetAttribute("time_seconds", (levelPair.Key == 1 ? "30" : (levelPair.Key == 2 ? "20" : "15")));
                    themeElem.AppendChild(levelElem);

                    foreach (Question q in levelPair.Value)
                    {
                        XmlElement qElem = doc.CreateElement("question");
                        levelElem.AppendChild(qElem);

                        XmlElement textElem = doc.CreateElement("text");
                        textElem.InnerText = q.Text;
                        qElem.AppendChild(textElem);

                        XmlElement imageElem = doc.CreateElement("image");
                        imageElem.InnerText = q.ImagePath;
                        qElem.AppendChild(imageElem);

                        XmlElement hintElem = doc.CreateElement("hint");
                        hintElem.InnerText = q.Hint;
                        qElem.AppendChild(hintElem);

                        XmlElement answersElem = doc.CreateElement("answers");
                        qElem.AppendChild(answersElem);

                        for (int i = 0; i < q.Answers.Count; i++)
                        {
                            XmlElement aElem = doc.CreateElement("answer");
                            if (i == q.CorrectAnswerIndex)
                                aElem.SetAttribute("correct", "true");
                            aElem.InnerText = q.Answers[i];
                            answersElem.AppendChild(aElem);
                        }
                    }
                }
            }

            doc.Save(xmlFilePath);
        }
    }
}