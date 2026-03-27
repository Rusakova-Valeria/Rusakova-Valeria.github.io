using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlagQuiz
{
    public partial class FormMain : Form
    {
        private QuizManager quizManager;
        private Timer questionTimer;
        private int timeRemaining;
        private bool isGameActive;

        // Поля для элементов управления (объявлены в Designer)
        private ComboBox cmbTheme;
        private ComboBox cmbLevel;
        private Button btnStart;
        private Button btnAdmin;
        private Panel gamePanel;
        private PictureBox pictureBoxFlag;
        private Label lblQuestion;
        private ComboBox cmbAnswers;
        private Button btnAnswer;
        private Label lblTimer;
        private Label lblScore;
        private Label lblQuestionNumber;
        private Label lblHint;
        private Button btnHint;
        private Label lblMessage;

        public FormMain()
        {
            InitializeComponent();  // Это вызывает метод из Designer.cs

            // Подписка на события
            btnStart.Click += BtnStart_Click;
            btnAdmin.Click += BtnAdmin_Click;
            btnAnswer.Click += BtnAnswer_Click;
            btnHint.Click += BtnHint_Click;

            // Загрузка XML
            try
            {
                string xmlPath = System.IO.Path.Combine(Application.StartupPath, "data", "flags.xml");
                quizManager = new QuizManager(xmlPath);

                this.Text = quizManager.QuizTitle;
                LoadThemes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadThemes()
        {
            cmbTheme.Items.Clear();
            foreach (string theme in quizManager.GetThemes())
            {
                cmbTheme.Items.Add(theme);
            }
            if (cmbTheme.Items.Count > 0)
                cmbTheme.SelectedIndex = 0;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (cmbTheme.SelectedItem == null)
            {
                MessageBox.Show("Выберите тему", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string theme = cmbTheme.SelectedItem.ToString();
            int level = cmbLevel.SelectedIndex + 1;

            if (!quizManager.HasQuestions(theme, level))
            {
                MessageBox.Show($"В теме '{theme}' уровня '{cmbLevel.SelectedItem}' нет вопросов",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Начать игру
            quizManager.StartGame(theme, level, 5);
            isGameActive = true;

            // Показать игровую панель
            gamePanel.Visible = true;

            // Настройка таймера
            questionTimer = new Timer();
            questionTimer.Interval = 1000;
            questionTimer.Tick += QuestionTimer_Tick;

            // Показать первый вопрос
            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            if (!quizManager.HasNextQuestion())
            {
                EndGame();
                return;
            }

            Question q = quizManager.GetCurrentQuestion();
            if (q == null) return;

            // Обновить UI
            lblQuestion.Text = q.Text;
            lblQuestionNumber.Text = $"Вопрос {quizManager.CurrentQuestionNumber} из {quizManager.TotalQuestions}";
            lblScore.Text = $"Очки: {quizManager.CurrentScore} / {quizManager.MaxScore}";

            // Загрузить изображение
            try
            {
                string imagePath = System.IO.Path.Combine(Application.StartupPath, q.ImagePath);
                if (System.IO.File.Exists(imagePath))
                    pictureBoxFlag.Image = Image.FromFile(imagePath);
                else
                    pictureBoxFlag.Image = null;
            }
            catch
            {
                pictureBoxFlag.Image = null;
            }

            // Заполнить варианты ответов
            cmbAnswers.Items.Clear();
            foreach (string answer in q.Answers)
            {
                if (!string.IsNullOrEmpty(answer))
                    cmbAnswers.Items.Add(answer);
            }
            if (cmbAnswers.Items.Count > 0)
                cmbAnswers.SelectedIndex = 0;

            // Сбросить подсказку и сообщение
            lblHint.Text = "";
            lblMessage.Text = "";
            btnHint.Enabled = true;

            // Запустить таймер
            timeRemaining = quizManager.TimePerQuestion;
            lblTimer.Text = $"⏱️ {timeRemaining} сек";
            questionTimer.Start();
        }

        private void QuestionTimer_Tick(object sender, EventArgs e)
        {
            timeRemaining--;
            lblTimer.Text = $"⏱️ {timeRemaining} сек";

            if (timeRemaining <= 0)
            {
                questionTimer.Stop();
                TimeOut();
            }
        }

        private void TimeOut()
        {
            lblMessage.Text = "⏰ Время вышло!";
            lblMessage.ForeColor = Color.Red;
            btnAnswer.Enabled = false;
            btnHint.Enabled = false;

            Timer delayTimer = new Timer();
            delayTimer.Interval = 1500;
            delayTimer.Tick += (delaySender, delayArgs) =>
            {
                delayTimer.Stop();
                btnAnswer.Enabled = true;
                ContinueAfterAnswer();
            };
            delayTimer.Start();
        }

        private void BtnAnswer_Click(object sender, EventArgs e)
        {
            if (cmbAnswers.SelectedIndex == -1) return;

            questionTimer.Stop();

            int selectedIndex = cmbAnswers.SelectedIndex;
            int earnedPoints;
            bool isCorrect = quizManager.AnswerCurrentQuestion(selectedIndex, out earnedPoints);

            if (isCorrect)
            {
                lblMessage.Text = $"✓ Правильно! +{earnedPoints} очков";
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                string correctAnswer = quizManager.GetCurrentQuestion()?.GetCorrectAnswer() ?? "";
                lblMessage.Text = $"✗ Неправильно! Правильный ответ: {correctAnswer}";
                lblMessage.ForeColor = Color.Red;
            }

            btnAnswer.Enabled = false;
            btnHint.Enabled = false;

            Timer delayTimer = new Timer();
            delayTimer.Interval = 1500;
            delayTimer.Tick += (delaySender, delayArgs) =>
            {
                delayTimer.Stop();
                btnAnswer.Enabled = true;
                ContinueAfterAnswer();
            };
            delayTimer.Start();
        }

        private void ContinueAfterAnswer()
        {
            if (quizManager.HasNextQuestion())
            {
                ShowNextQuestion();
            }
            else
            {
                EndGame();
            }
        }

        private void BtnHint_Click(object sender, EventArgs e)
        {
            Question q = quizManager.GetCurrentQuestion();
            if (q != null && !string.IsNullOrEmpty(q.Hint))
            {
                lblHint.Text = $"💡 Подсказка: {q.Hint}";
                btnHint.Enabled = false;
            }
            else
            {
                lblHint.Text = "💡 Подсказка отсутствует";
            }
        }

        private void EndGame()
        {
            questionTimer?.Stop();
            isGameActive = false;

            int percentage = quizManager.GetPercentage();
            bool canAdvance = quizManager.CanAdvanceToNextLevel();

            string message = $"Игра окончена!\n\n";
            message += $"Набрано очков: {quizManager.CurrentScore} / {quizManager.MaxScore}\n";
            message += $"Процент: {percentage}%\n\n";

            if (canAdvance)
            {
                message += "🎉 ПОЗДРАВЛЯЕМ! 🎉\n";
                message += "Вы набрали 80% и можете перейти на следующий уровень!";
            }
            else
            {
                message += "😞 К сожалению, вы не набрали 80%.\n";
                message += "Попробуйте еще раз!";
            }

            MessageBox.Show(message, "Результаты", MessageBoxButtons.OK,
                canAdvance ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            gamePanel.Visible = false;
        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            FormAdmin adminForm = new FormAdmin(quizManager);
            adminForm.ShowDialog();
        }
    }
}