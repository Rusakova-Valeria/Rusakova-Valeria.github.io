using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryLibrary
{
    /// <summary>
    /// Класс для поиска слов по заданию (Вариант 20)
    /// Поиск слов, которые можно получить из заданного слова заменой одной буквы
    /// </summary>
    public class WordFinder
    {
        private Dictionary dictionary;

        public WordFinder(Dictionary dict)
        {
            this.dictionary = dict;
        }

        /// <summary>
        /// Найти слова, которые можно получить из заданного слова заменой одной буквы
        /// </summary>
        /// <param name="sourceWord">Исходное слово</param>
        /// <returns>Список найденных слов</returns>
        public List<string> FindWordsByOneReplace(string sourceWord)
        {
            if (string.IsNullOrWhiteSpace(sourceWord))
                return new List<string>();

            string source = sourceWord.Trim().ToLower();
            List<string> result = new List<string>();
            List<string> allWords = dictionary.GetAllWords();

            foreach (string word in allWords)
            {
                // Длина должна быть одинаковой
                if (word.Length != source.Length)
                    continue;

                // Проверяем, можно ли получить слово заменой одной буквы
                if (Levenshtein.CanGetByOneReplace(source, word))
                {
                    result.Add(word);
                }
            }

            return result;
        }

        /// <summary>
        /// Найти слова, которые можно получить из заданного слова заменой одной буквы
        /// С возможностью поиска на русском и английском
        /// </summary>
        public List<string> FindWordsByOneReplaceWithLanguage(string sourceWord, bool isRussian)
        {
            List<string> result = FindWordsByOneReplace(sourceWord);

            // Дополнительная фильтрация по языку
            if (isRussian)
            {
                // Русские буквы: а-я, ё
                result = result.Where(w => w.All(c =>
                    (c >= 'а' && c <= 'я') || c == 'ё')).ToList();
            }
            else
            {
                // Английские буквы: a-z
                result = result.Where(w => w.All(c => c >= 'a' && c <= 'z')).ToList();
            }

            return result;
        }

        /// <summary>
        /// Поиск с проверкой на наличие результатов
        /// </summary>
        public SearchResult SearchWithResult(string sourceWord)
        {
            List<string> results = FindWordsByOneReplace(sourceWord);

            return new SearchResult
            {
                SourceWord = sourceWord,
                FoundWords = results,
                Count = results.Count,
                IsSuccess = results.Count > 0
            };
        }

        /// <summary>
        /// Сохранение результатов поиска в файл
        /// </summary>
        public void SaveResultsToFile(string filePath, SearchResult result)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    writer.WriteLine("=".PadRight(60, '='));
                    writer.WriteLine($"Результаты поиска слов, получаемых заменой одной буквы");
                    writer.WriteLine($"Исходное слово: {result.SourceWord}");
                    writer.WriteLine($"Найдено слов: {result.Count}");
                    writer.WriteLine("=".PadRight(60, '='));
                    writer.WriteLine();

                    if (result.Count > 0)
                    {
                        writer.WriteLine("Найденные слова:");
                        writer.WriteLine();

                        for (int i = 0; i < result.FoundWords.Count; i++)
                        {
                            string original = result.FoundWords[i];
                            string replaced = GetReplacedWord(result.SourceWord, original);
                            writer.WriteLine($"{i + 1,3}. {original} (замена: {original} ← {replaced})");
                        }
                    }
                    else
                    {
                        writer.WriteLine("Совпадений не найдено.");
                    }

                    writer.WriteLine();
                    writer.WriteLine($"Дата поиска: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
                    writer.WriteLine("=".PadRight(60, '='));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка сохранения файла: {ex.Message}");
            }
        }

        /// <summary>
        /// Получение строки с указанием замены
        /// </summary>
        private string GetReplacedWord(string source, string target)
        {
            if (source.Length != target.Length)
                return target;

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != target[i])
                {
                    return $"{source.Substring(0, i)}[{source[i]}→{target[i]}]{source.Substring(i + 1)}";
                }
            }

            return target;
        }
    }

    /// <summary>
    /// Класс результата поиска
    /// </summary>
    public class SearchResult
    {
        public string SourceWord { get; set; }
        public List<string> FoundWords { get; set; }
        public int Count { get; set; }
        public bool IsSuccess { get; set; }

        public SearchResult()
        {
            FoundWords = new List<string>();
        }
    }
}