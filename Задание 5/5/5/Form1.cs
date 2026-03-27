using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DictionaryLibrary;

namespace DictionaryApp
{
    public partial class Form1 : Form
    {
        private Dictionary dictionary;
        private WordFinder wordFinder;
        private string currentDictionaryPath;

        public Form1()
        {
            InitializeComponent();

            dictionary = new Dictionary();
            wordFinder = new WordFinder(dictionary);

            UpdateUI();
        }

        private void UpdateUI()
        {
            // Обновление заголовка
            if (!string.IsNullOrEmpty(currentDictionaryPath))
            {
                this.Text = $"Словарь - {System.IO.Path.GetFileName(currentDictionaryPath)}";
                labelCurrentDict.Text = $"Текущий словарь: {System.IO.Path.GetFileName(currentDictionaryPath)}";
            }
            else
            {
                this.Text = "Словарь - новый (не сохранен)";
                labelCurrentDict.Text = "Текущий словарь: новый (не сохранен)";
            }

            // Обновление статуса
            labelWordCount.Text = $"Слов в словаре: {dictionary.Count}";

            if (dictionary.IsModified)
            {
                labelStatus.Text = "Статус: Есть несохраненные изменения";
                labelStatus.ForeColor = Color.Orange;
            }
            else
            {
                labelStatus.Text = "Статус: Изменения сохранены";
                labelStatus.ForeColor = Color.Green;
            }

            // Обновление списка
            UpdateWordList();
        }

        private void UpdateWordList()
        {
            listBoxWords.Items.Clear();

            List<string> words = dictionary.GetAllWords();
            foreach (string word in words)
            {
                listBoxWords.Items.Add(word);
            }

            if (listBoxWords.Items.Count > 0)
            {
                labelWordCount.Text = $"Слов в словаре: {dictionary.Count}";
            }
        }

        private void UpdateSearchResults(List<string> results, string sourceWord)
        {
            listBoxResults.Items.Clear();

            if (results.Count > 0)
            {
                listBoxResults.Items.Add($"=== Результаты поиска для слова \"{sourceWord}\" ===");
                listBoxResults.Items.Add($"Найдено слов: {results.Count}");
                listBoxResults.Items.Add("");

                for (int i = 0; i < results.Count; i++)
                {
                    listBoxResults.Items.Add($"{i + 1,3}. {results[i]}");
                }
            }
            else
            {
                listBoxResults.Items.Add($"=== Результаты поиска для слова \"{sourceWord}\" ===");
                listBoxResults.Items.Add("");
                listBoxResults.Items.Add("Совпадений не найдено.");
            }

            labelResultCount.Text = $"Найдено: {results.Count} слов";
        }

        // ==================== ЗАГРУЗКА СЛОВАРЯ ====================

        private void btnLoadDictionary_Click(object sender, EventArgs e)
        {
            if (dictionary.IsModified)
            {
                DialogResult result = MessageBox.Show(
                    "Есть несохраненные изменения. Загрузить другой словарь?\nНесохраненные изменения будут потеряны.",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;
            }

            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dictionary.Load(openFileDialog.FileName);
                    currentDictionaryPath = openFileDialog.FileName;
                    UpdateUI();

                    MessageBox.Show($"Словарь загружен. Слов: {dictionary.Count}", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==================== СОХРАНЕНИЕ СЛОВАРЯ ====================

        private void btnSaveDictionary_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentDictionaryPath))
            {
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentDictionaryPath = saveFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }

            try
            {
                dictionary.Save(currentDictionaryPath);
                UpdateUI();

                MessageBox.Show($"Словарь сохранен в файл:\n{currentDictionaryPath}", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveAsDictionary_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dictionary.Save(saveFileDialog.FileName);
                    currentDictionaryPath = saveFileDialog.FileName;
                    UpdateUI();

                    MessageBox.Show($"Словарь сохранен в файл:\n{currentDictionaryPath}", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==================== СОЗДАНИЕ НОВОГО СЛОВАРЯ ====================

        private void btnNewDictionary_Click(object sender, EventArgs e)
        {
            if (dictionary.IsModified)
            {
                DialogResult result = MessageBox.Show(
                    "Есть несохраненные изменения. Создать новый словарь?\nНесохраненные изменения будут потеряны.",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;
            }

            dictionary.CreateNew();
            currentDictionaryPath = "";
            UpdateUI();
        }

        // ==================== ДОБАВЛЕНИЕ СЛОВА ====================

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            string newWord = textBoxNewWord.Text.Trim();

            if (string.IsNullOrEmpty(newWord))
            {
                MessageBox.Show("Введите слово для добавления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dictionary.AddWord(newWord))
            {
                textBoxNewWord.Clear();
                UpdateUI();

                MessageBox.Show($"Слово \"{newWord}\" добавлено", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Слово \"{newWord}\" уже есть в словаре", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ==================== УДАЛЕНИЕ СЛОВА ====================

        private void btnRemoveWord_Click(object sender, EventArgs e)
        {
            if (listBoxWords.SelectedItem == null)
            {
                MessageBox.Show("Выберите слово для удаления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string word = listBoxWords.SelectedItem.ToString();

            DialogResult result = MessageBox.Show(
                $"Удалить слово \"{word}\"?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (dictionary.RemoveWord(word))
                {
                    UpdateUI();
                    MessageBox.Show($"Слово \"{word}\" удалено", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // ==================== ПОИСК ПО ВАРИАНТУ 20 ====================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sourceWord = textBoxSearchWord.Text.Trim();

            if (string.IsNullOrEmpty(sourceWord))
            {
                MessageBox.Show("Введите слово для поиска", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dictionary.Count == 0)
            {
                MessageBox.Show("Словарь пуст. Загрузите словарь или добавьте слова.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Поиск
            SearchResult result = wordFinder.SearchWithResult(sourceWord);
            UpdateSearchResults(result.FoundWords, sourceWord);

            // Сохранение последнего результата
            lastSearchResult = result;
            btnSaveResults.Enabled = true;
        }

        private SearchResult lastSearchResult;

        // ==================== СОХРАНЕНИЕ РЕЗУЛЬТАТОВ ====================

        private void btnSaveResults_Click(object sender, EventArgs e)
        {
            if (lastSearchResult == null || lastSearchResult.FoundWords.Count == 0)
            {
                MessageBox.Show("Нет результатов для сохранения", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.FileName = $"search_{lastSearchResult.SourceWord}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    wordFinder.SaveResultsToFile(saveFileDialog.FileName, lastSearchResult);

                    MessageBox.Show($"Результаты сохранены в файл:\n{saveFileDialog.FileName}", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==================== ФИЛЬТРАЦИЯ СПИСКА ====================

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            string filter = textBoxFilter.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filter))
            {
                UpdateWordList();
            }
            else
            {
                listBoxWords.Items.Clear();
                List<string> words = dictionary.GetAllWords();

                foreach (string word in words)
                {
                    if (word.Contains(filter))
                    {
                        listBoxWords.Items.Add(word);
                    }
                }

                labelWordCount.Text = $"Показано: {listBoxWords.Items.Count} / {dictionary.Count} слов";
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            textBoxFilter.Clear();
            UpdateWordList();
        }

        // ==================== ПОИСК ПО ПРЕФИКСУ ====================

        private void btnSearchPrefix_Click(object sender, EventArgs e)
        {
            string prefix = textBoxSearchPrefix.Text.Trim();

            if (string.IsNullOrEmpty(prefix))
            {
                UpdateWordList();
                return;
            }

            List<string> results = dictionary.FindWordsStartingWith(prefix);

            listBoxWords.Items.Clear();
            foreach (string word in results)
            {
                listBoxWords.Items.Add(word);
            }

            labelWordCount.Text = $"Найдено: {listBoxWords.Items.Count} слов, начинающихся с \"{prefix}\"";
        }
    }
}