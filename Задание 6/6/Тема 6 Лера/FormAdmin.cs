using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlagQuiz
{
    public partial class FormAdmin : Form
    {
        private QuizManager quizManager;

        // Поля для элементов управления (объявлены в Designer)
        private TextBox txtTheme;
        private ComboBox cmbLevel;
        private TextBox txtQuestion;
        private TextBox txtImagePath;
        private Button btnBrowseImage;
        private TextBox txtHint;
        private TextBox txtAnswer1;
        private TextBox txtAnswer2;
        private TextBox txtAnswer3;
        private TextBox txtAnswer4;
        private ComboBox cmbCorrectAnswer;
        private Button btnAdd;
        private Button btnClose;

        public FormAdmin(QuizManager manager)
        {
            quizManager = manager;
            InitializeComponent();  // Это вызывает метод из Designer.cs
            LoadThemes();
        }

        private void LoadThemes()
        {
            // Пустое поле для новой темы
            txtTheme.Text = "";
        }

        private void BtnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Изображения (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                ofd.Title = "Выберите изображение флага";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Копируем файл в папку flags
                    string destFolder = System.IO.Path.Combine(Application.StartupPath, "flags");
                    if (!System.IO.Directory.Exists(destFolder))
                        System.IO.Directory.CreateDirectory(destFolder);

                    string fileName = System.IO.Path.GetFileName(ofd.FileName);
                    string destPath = System.IO.Path.Combine(destFolder, fileName);

                    System.IO.File.Copy(ofd.FileName, destPath, true);
                    txtImagePath.Text = $"flags/{fileName}";
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка данных
                if (string.IsNullOrWhiteSpace(txtTheme.Text))
                {
                    MessageBox.Show("Введите название темы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtQuestion.Text))
                {
                    MessageBox.Show("Введите вопрос", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAnswer1.Text) || string.IsNullOrWhiteSpace(txtAnswer2.Text))
                {
                    MessageBox.Show("Введите хотя бы два варианта ответа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Создание вопроса
                Question q = new Question();
                q.Text = txtQuestion.Text;
                q.ImagePath = txtImagePath.Text;
                q.Hint = txtHint.Text;

                q.Answers.Add(txtAnswer1.Text);
                q.Answers.Add(txtAnswer2.Text);
                if (!string.IsNullOrWhiteSpace(txtAnswer3.Text))
                    q.Answers.Add(txtAnswer3.Text);
                if (!string.IsNullOrWhiteSpace(txtAnswer4.Text))
                    q.Answers.Add(txtAnswer4.Text);

                q.CorrectAnswerIndex = cmbCorrectAnswer.SelectedIndex;

                // Добавление вопроса
                string theme = txtTheme.Text.Trim();
                int level = cmbLevel.SelectedIndex + 1;

                quizManager.AddQuestion(theme, level, q);

                MessageBox.Show("Вопрос успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Очистка формы
                txtQuestion.Clear();
                txtImagePath.Clear();
                txtHint.Clear();
                txtAnswer1.Clear();
                txtAnswer2.Clear();
                txtAnswer3.Clear();
                txtAnswer4.Clear();
                cmbCorrectAnswer.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}