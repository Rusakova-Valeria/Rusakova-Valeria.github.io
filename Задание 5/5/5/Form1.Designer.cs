using System.Windows.Forms;

namespace DictionaryApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Панели
        private TabControl tabControl;
        private TabPage tabPageDictionary;
        private TabPage tabPageSearch;

        // Вкладка словаря
        private GroupBox groupBoxDictionary;
        private Label labelCurrentDict;
        private Label labelWordCount;
        private Label labelStatus;
        private ListBox listBoxWords;
        private TextBox textBoxFilter;
        private Button btnClearFilter;
        private TextBox textBoxNewWord;
        private Button btnAddWord;
        private Button btnRemoveWord;
        private Button btnLoadDictionary;
        private Button btnSaveDictionary;
        private Button btnSaveAsDictionary;
        private Button btnNewDictionary;
        private Label labelFilter;
        private Label labelNewWord;
        private TextBox textBoxSearchPrefix;
        private Button btnSearchPrefix;
        private Label labelSearchPrefix;

        // Вкладка поиска
        private GroupBox groupBoxSearch;
        private Label labelSearchWord;
        private TextBox textBoxSearchWord;
        private Button btnSearch;
        private ListBox listBoxResults;
        private Label labelResultCount;
        private Button btnSaveResults;

        // Диалоги
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Диалоги
            this.openFileDialog = new OpenFileDialog();
            this.saveFileDialog = new SaveFileDialog();

            // TabControl
            this.tabControl = new TabControl();
            this.tabPageDictionary = new TabPage();
            this.tabPageSearch = new TabPage();

            // ==================== ВКЛАДКА СЛОВАРЯ ====================
            this.groupBoxDictionary = new GroupBox();

            // Кнопки загрузки/сохранения
            this.btnLoadDictionary = new Button();
            this.btnSaveDictionary = new Button();
            this.btnSaveAsDictionary = new Button();
            this.btnNewDictionary = new Button();

            // Информация
            this.labelCurrentDict = new Label();
            this.labelWordCount = new Label();
            this.labelStatus = new Label();

            // Список слов
            this.listBoxWords = new ListBox();

            // Фильтр
            this.labelFilter = new Label();
            this.textBoxFilter = new TextBox();
            this.btnClearFilter = new Button();

            // Поиск по префиксу
            this.labelSearchPrefix = new Label();
            this.textBoxSearchPrefix = new TextBox();
            this.btnSearchPrefix = new Button();

            // Добавление/удаление
            this.labelNewWord = new Label();
            this.textBoxNewWord = new TextBox();
            this.btnAddWord = new Button();
            this.btnRemoveWord = new Button();

            // ==================== ВКЛАДКА ПОИСКА ====================
            this.groupBoxSearch = new GroupBox();
            this.labelSearchWord = new Label();
            this.textBoxSearchWord = new TextBox();
            this.btnSearch = new Button();
            this.listBoxResults = new ListBox();
            this.labelResultCount = new Label();
            this.btnSaveResults = new Button();

            // ==================== НАСТРОЙКА ЭЛЕМЕНТОВ ====================

            // groupBoxDictionary
            this.groupBoxDictionary.Text = "Управление словарем";
            this.groupBoxDictionary.Location = new System.Drawing.Point(10, 10);
            this.groupBoxDictionary.Size = new System.Drawing.Size(760, 540);

            // btnLoadDictionary
            this.btnLoadDictionary.Text = "Загрузить словарь";
            this.btnLoadDictionary.Location = new System.Drawing.Point(10, 25);
            this.btnLoadDictionary.Size = new System.Drawing.Size(140, 30);
            this.btnLoadDictionary.Click += new System.EventHandler(this.btnLoadDictionary_Click);

            // btnSaveDictionary
            this.btnSaveDictionary.Text = "Сохранить";
            this.btnSaveDictionary.Location = new System.Drawing.Point(160, 25);
            this.btnSaveDictionary.Size = new System.Drawing.Size(100, 30);
            this.btnSaveDictionary.Click += new System.EventHandler(this.btnSaveDictionary_Click);

            // btnSaveAsDictionary
            this.btnSaveAsDictionary.Text = "Сохранить как...";
            this.btnSaveAsDictionary.Location = new System.Drawing.Point(270, 25);
            this.btnSaveAsDictionary.Size = new System.Drawing.Size(120, 30);
            this.btnSaveAsDictionary.Click += new System.EventHandler(this.btnSaveAsDictionary_Click);

            // btnNewDictionary
            this.btnNewDictionary.Text = "Новый словарь";
            this.btnNewDictionary.Location = new System.Drawing.Point(400, 25);
            this.btnNewDictionary.Size = new System.Drawing.Size(120, 30);
            this.btnNewDictionary.Click += new System.EventHandler(this.btnNewDictionary_Click);

            // labelCurrentDict
            this.labelCurrentDict.Text = "Текущий словарь: не загружен";
            this.labelCurrentDict.Location = new System.Drawing.Point(10, 65);
            this.labelCurrentDict.Size = new System.Drawing.Size(400, 20);

            // labelWordCount
            this.labelWordCount.Text = "Слов в словаре: 0";
            this.labelWordCount.Location = new System.Drawing.Point(10, 90);
            this.labelWordCount.Size = new System.Drawing.Size(300, 20);

            // labelStatus
            this.labelStatus.Text = "Статус: изменения сохранены";
            this.labelStatus.Location = new System.Drawing.Point(10, 115);
            this.labelStatus.Size = new System.Drawing.Size(300, 20);

            // listBoxWords
            this.listBoxWords.Location = new System.Drawing.Point(10, 145);
            this.listBoxWords.Size = new System.Drawing.Size(400, 380);
            this.listBoxWords.Font = new System.Drawing.Font("Consolas", 10F);

            // labelFilter
            this.labelFilter.Text = "Фильтр (содержит):";
            this.labelFilter.Location = new System.Drawing.Point(420, 145);
            this.labelFilter.Size = new System.Drawing.Size(100, 20);

            // textBoxFilter
            this.textBoxFilter.Location = new System.Drawing.Point(420, 170);
            this.textBoxFilter.Size = new System.Drawing.Size(320, 25);
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);

            // btnClearFilter
            this.btnClearFilter.Text = "Очистить";
            this.btnClearFilter.Location = new System.Drawing.Point(420, 200);
            this.btnClearFilter.Size = new System.Drawing.Size(100, 30);
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);

            // labelSearchPrefix
            this.labelSearchPrefix.Text = "Поиск по началу:";
            this.labelSearchPrefix.Location = new System.Drawing.Point(420, 240);
            this.labelSearchPrefix.Size = new System.Drawing.Size(120, 20);

            // textBoxSearchPrefix
            this.textBoxSearchPrefix.Location = new System.Drawing.Point(420, 265);
            this.textBoxSearchPrefix.Size = new System.Drawing.Size(200, 25);

            // btnSearchPrefix
            this.btnSearchPrefix.Text = "Найти";
            this.btnSearchPrefix.Location = new System.Drawing.Point(630, 263);
            this.btnSearchPrefix.Size = new System.Drawing.Size(110, 30);
            this.btnSearchPrefix.Click += new System.EventHandler(this.btnSearchPrefix_Click);

            // labelNewWord
            this.labelNewWord.Text = "Добавить слово:";
            this.labelNewWord.Location = new System.Drawing.Point(420, 310);
            this.labelNewWord.Size = new System.Drawing.Size(100, 20);

            // textBoxNewWord
            this.textBoxNewWord.Location = new System.Drawing.Point(420, 335);
            this.textBoxNewWord.Size = new System.Drawing.Size(200, 25);

            // btnAddWord
            this.btnAddWord.Text = "Добавить";
            this.btnAddWord.Location = new System.Drawing.Point(630, 333);
            this.btnAddWord.Size = new System.Drawing.Size(110, 30);
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);

            // btnRemoveWord
            this.btnRemoveWord.Text = "Удалить выделенное слово";
            this.btnRemoveWord.Location = new System.Drawing.Point(420, 380);
            this.btnRemoveWord.Size = new System.Drawing.Size(200, 35);
            this.btnRemoveWord.Click += new System.EventHandler(this.btnRemoveWord_Click);

            this.groupBoxDictionary.Controls.Add(this.btnLoadDictionary);
            this.groupBoxDictionary.Controls.Add(this.btnSaveDictionary);
            this.groupBoxDictionary.Controls.Add(this.btnSaveAsDictionary);
            this.groupBoxDictionary.Controls.Add(this.btnNewDictionary);
            this.groupBoxDictionary.Controls.Add(this.labelCurrentDict);
            this.groupBoxDictionary.Controls.Add(this.labelWordCount);
            this.groupBoxDictionary.Controls.Add(this.labelStatus);
            this.groupBoxDictionary.Controls.Add(this.listBoxWords);
            this.groupBoxDictionary.Controls.Add(this.labelFilter);
            this.groupBoxDictionary.Controls.Add(this.textBoxFilter);
            this.groupBoxDictionary.Controls.Add(this.btnClearFilter);
            this.groupBoxDictionary.Controls.Add(this.labelSearchPrefix);
            this.groupBoxDictionary.Controls.Add(this.textBoxSearchPrefix);
            this.groupBoxDictionary.Controls.Add(this.btnSearchPrefix);
            this.groupBoxDictionary.Controls.Add(this.labelNewWord);
            this.groupBoxDictionary.Controls.Add(this.textBoxNewWord);
            this.groupBoxDictionary.Controls.Add(this.btnAddWord);
            this.groupBoxDictionary.Controls.Add(this.btnRemoveWord);

            // ==================== ВКЛАДКА ПОИСКА ====================
            this.groupBoxSearch.Text = "Поиск слов (Вариант 20: замена одной буквы)";
            this.groupBoxSearch.Location = new System.Drawing.Point(10, 10);
            this.groupBoxSearch.Size = new System.Drawing.Size(760, 540);

            this.labelSearchWord.Text = "Исходное слово:";
            this.labelSearchWord.Location = new System.Drawing.Point(10, 30);
            this.labelSearchWord.Size = new System.Drawing.Size(100, 25);

            this.textBoxSearchWord.Location = new System.Drawing.Point(120, 28);
            this.textBoxSearchWord.Size = new System.Drawing.Size(250, 25);

            this.btnSearch.Text = "Найти слова";
            this.btnSearch.Location = new System.Drawing.Point(380, 26);
            this.btnSearch.Size = new System.Drawing.Size(120, 30);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            this.labelResultCount.Text = "Найдено: 0 слов";
            this.labelResultCount.Location = new System.Drawing.Point(510, 32);
            this.labelResultCount.Size = new System.Drawing.Size(150, 25);

            this.btnSaveResults.Text = "Сохранить результаты";
            this.btnSaveResults.Location = new System.Drawing.Point(10, 500);
            this.btnSaveResults.Size = new System.Drawing.Size(150, 30);
            this.btnSaveResults.Enabled = false;
            this.btnSaveResults.Click += new System.EventHandler(this.btnSaveResults_Click);

            this.listBoxResults.Location = new System.Drawing.Point(10, 70);
            this.listBoxResults.Size = new System.Drawing.Size(730, 420);
            this.listBoxResults.Font = new System.Drawing.Font("Consolas", 10F);

            this.groupBoxSearch.Controls.Add(this.labelSearchWord);
            this.groupBoxSearch.Controls.Add(this.textBoxSearchWord);
            this.groupBoxSearch.Controls.Add(this.btnSearch);
            this.groupBoxSearch.Controls.Add(this.listBoxResults);
            this.groupBoxSearch.Controls.Add(this.labelResultCount);
            this.groupBoxSearch.Controls.Add(this.btnSaveResults);

            // TabControl
            this.tabControl.Controls.Add(this.tabPageDictionary);
            this.tabControl.Controls.Add(this.tabPageSearch);
            this.tabControl.Dock = DockStyle.Fill;

            this.tabPageDictionary.Controls.Add(this.groupBoxDictionary);
            this.tabPageDictionary.Text = "Словарь";

            this.tabPageSearch.Controls.Add(this.groupBoxSearch);
            this.tabPageSearch.Text = "Поиск";

            // Form1
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tabControl);
            this.Text = "Словарь - Вариант 20";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
        }

        #endregion
    }
}