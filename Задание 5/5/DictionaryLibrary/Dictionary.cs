using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DictionaryLibrary
{
    /// <summary>
    /// Класс для работы со словарем
    /// </summary>
    public class Dictionary
    {
        private List<string> words;
        private string currentFilePath;
        private bool isModified;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Dictionary()
        {
            words = new List<string>();
            currentFilePath = "";
            isModified = false;
        }

        /// <summary>
        /// Конструктор с загрузкой из файла
        /// </summary>
        public Dictionary(string filePath) : this()
        {
            Load(filePath);
        }

        /// <summary>
        /// Количество слов в словаре
        /// </summary>
        public int Count
        {
            get { return words.Count; }
        }

        /// <summary>
        /// Путь к текущему файлу
        /// </summary>
        public string CurrentFilePath
        {
            get { return currentFilePath; }
        }

        /// <summary>
        /// Флаг изменения словаря
        /// </summary>
        public bool IsModified
        {
            get { return isModified; }
        }

        /// <summary>
        /// Индексатор для доступа к словам
        /// </summary>
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < words.Count)
                    return words[index];
                return null;
            }
        }

        /// <summary>
        /// Получение всех слов
        /// </summary>
        public List<string> GetAllWords()
        {
            return new List<string>(words);
        }

        /// <summary>
        /// Загрузка словаря из файла
        /// </summary>
        public void Load(string filePath)
        {
            try
            {
                words.Clear();

                using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim().ToLower();
                        if (!string.IsNullOrEmpty(line) && !words.Contains(line))
                        {
                            words.Add(line);
                        }
                    }
                }

                words.Sort();
                currentFilePath = filePath;
                isModified = false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка загрузки файла: {ex.Message}");
            }
        }

        /// <summary>
        /// Сохранение словаря в файл
        /// </summary>
        public void Save(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    foreach (string word in words)
                    {
                        writer.WriteLine(word);
                    }
                }

                currentFilePath = filePath;
                isModified = false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка сохранения файла: {ex.Message}");
            }
        }

        /// <summary>
        /// Добавление слова
        /// </summary>
        public bool AddWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return false;

            string newWord = word.Trim().ToLower();

            if (!words.Contains(newWord))
            {
                words.Add(newWord);
                words.Sort();
                isModified = true;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Удаление слова
        /// </summary>
        public bool RemoveWord(string word)
        {
            string target = word.Trim().ToLower();

            if (words.Remove(target))
            {
                isModified = true;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Поиск слов, начинающихся с заданной подстроки
        /// </summary>
        public List<string> FindWordsStartingWith(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
                return new List<string>();

            string searchPrefix = prefix.Trim().ToLower();

            return words.Where(w => w.StartsWith(searchPrefix)).ToList();
        }

        /// <summary>
        /// Поиск слов, содержащих заданную подстроку
        /// </summary>
        public List<string> FindWordsContaining(string substring)
        {
            if (string.IsNullOrEmpty(substring))
                return new List<string>();

            string search = substring.Trim().ToLower();

            return words.Where(w => w.Contains(search)).ToList();
        }

        /// <summary>
        /// Получение слов по алфавиту, начиная с буквы
        /// </summary>
        public List<string> GetWordsStartingWithLetter(char letter)
        {
            char searchLetter = char.ToLower(letter);
            return words.Where(w => w.Length > 0 && w[0] == searchLetter).ToList();
        }

        /// <summary>
        /// Создание нового пустого словаря
        /// </summary>
        public void CreateNew()
        {
            words.Clear();
            currentFilePath = "";
            isModified = false;
        }
    }
}