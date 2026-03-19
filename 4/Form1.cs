using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ElectionData electionData;
        private string currentFileName;

        public Form1()
        {
            InitializeComponent();

            // Инициализация данных
            electionData = new ElectionData();
            currentFileName = "";

            // Настройка DataGridView
            SetupDataGridView();

            // Обновление списка округов
            UpdateDistrictsList();
        }

        /// <summary>
        /// Настройка таблицы данных
        /// </summary>
        private void SetupDataGridView()
        {
            // Очистка колонок
            dataGridViewDistricts.Columns.Clear();

            // Добавление колонок
            dataGridViewDistricts.Columns.Add("Name", "Название округа");
            dataGridViewDistricts.Columns.Add("TotalResidents", "Количество жителей");
            dataGridViewDistricts.Columns.Add("Participated", "Участвовало");
            dataGridViewDistricts.Columns.Add("Percent", "Явка (%)");

            // Настройка ширины колонок
            dataGridViewDistricts.Columns["Name"].Width = 200;
            dataGridViewDistricts.Columns["TotalResidents"].Width = 120;
            dataGridViewDistricts.Columns["Participated"].Width = 120;
            dataGridViewDistricts.Columns["Percent"].Width = 100;

            // Запрет добавления строк пользователем
            dataGridViewDistricts.AllowUserToAddRows = false;
            dataGridViewDistricts.AllowUserToDeleteRows = false;

            // Только чтение
            dataGridViewDistricts.ReadOnly = true;

            // Режим выделения
            dataGridViewDistricts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDistricts.MultiSelect = false;
        }

        /// <summary>
        /// Обновление списка округов в DataGridView
        /// </summary>
        private void UpdateDistrictsList()
        {
            // Очистка таблицы
            dataGridViewDistricts.Rows.Clear();

            // Добавление данных
            for (int i = 0; i < electionData.Count; i++)
            {
                District district = electionData[i];
                dataGridViewDistricts.Rows.Add(
                    district.Name,
                    district.TotalResidents,
                    district.Participated,
                    district.ParticipationPercent.ToString("F2")
                );
            }

            // Обновление информации
            UpdateInfoLabels();

            // Обновление диаграммы
            UpdateChart();
        }

        /// <summary>
        /// Обновление информационных меток
        /// </summary>
        private void UpdateInfoLabels()
        {
            lblElectionName.Text = electionData.ElectionName;
            lblTotalVoters.Text = electionData.TotalVoters.ToString("N0");
            lblTotalParticipated.Text = electionData.TotalParticipated.ToString("N0");
            lblAverageParticipation.Text = electionData.AverageParticipation.ToString("F2") + "%";
        }

        /// <summary>
        /// Обновление диаграммы
        /// </summary>
        private void UpdateChart()
        {
            if (electionData.Count > 0)
            {
                electionData.BuildPieChart(chartParticipation);
            }
            else
            {
                chartParticipation.Series.Clear();
                chartParticipation.Titles.Clear();
                chartParticipation.Titles.Add("Нет данных для отображения");
            }
        }

        /// <summary>
        /// Очистка полей ввода
        /// </summary>
        private void ClearInputFields()
        {
            txtDistrictName.Text = "";
            txtTotalResidents.Text = "";
            txtParticipated.Text = "";
        }

        /// <summary>
        /// Проверка корректности ввода
        /// </summary>
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtDistrictName.Text))
            {
                MessageBox.Show("Введите название округа", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtTotalResidents.Text, out int total) || total <= 0)
            {
                MessageBox.Show("Количество жителей должно быть положительным целым числом",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtParticipated.Text, out int participated) || participated < 0)
            {
                MessageBox.Show("Количество участвовавших должно быть неотрицательным целым числом",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (participated > total)
            {
                MessageBox.Show("Количество участвовавших не может превышать общее количество жителей",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Кнопка добавления округа
        /// </summary>
        private void btnAddDistrict_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string name = txtDistrictName.Text;
                int total = int.Parse(txtTotalResidents.Text);
                int participated = int.Parse(txtParticipated.Text);

                electionData.AddDistrict(name, total, participated);
                UpdateDistrictsList();
                ClearInputFields();
            }
        }

        /// <summary>
        /// Кнопка удаления выбранного округа
        /// </summary>
        private void btnRemoveDistrict_Click(object sender, EventArgs e)
        {
            if (dataGridViewDistricts.SelectedRows.Count > 0)
            {
                int index = dataGridViewDistricts.SelectedRows[0].Index;

                DialogResult result = MessageBox.Show(
                    $"Удалить округ '{electionData[index].Name}'?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    electionData.RemoveDistrict(index);
                    UpdateDistrictsList();
                }
            }
            else
            {
                MessageBox.Show("Выберите округ для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Кнопка сохранения в файл
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (electionData.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveDialog.DefaultExt = "txt";
            saveDialog.FileName = "election_data.txt";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    electionData.SaveToFile(saveDialog.FileName);
                    currentFileName = saveDialog.FileName;

                    // Обновляем название выборов (можно спросить у пользователя)
                    string newName = Microsoft.VisualBasic.Interaction.InputBox(
                        "Введите название выборов:",
                        "Название выборов",
                        electionData.ElectionName);

                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        electionData.ElectionName = newName;
                        UpdateInfoLabels();
                    }

                    MessageBox.Show("Данные успешно сохранены", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Кнопка загрузки из файла
        /// </summary>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    electionData.LoadFromFile(openDialog.FileName);
                    currentFileName = openDialog.FileName;
                    UpdateDistrictsList();

                    MessageBox.Show("Данные успешно загружены", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Кнопка очистки всех данных
        /// </summary>
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (electionData.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Очистить все данные?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    electionData.Clear();
                    UpdateDistrictsList();
                    ClearInputFields();
                }
            }
        }

        /// <summary>
        /// Изменение названия выборов
        /// </summary>
        private void btnChangeElectionName_Click(object sender, EventArgs e)
        {
            string newName = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите название выборов:",
                "Название выборов",
                electionData.ElectionName);

            if (!string.IsNullOrWhiteSpace(newName))
            {
                electionData.ElectionName = newName;
                UpdateInfoLabels();
                UpdateChart();
            }
        }

        /// <summary>
        /// Обработка нажатия клавиш в полях ввода (только цифры)
        /// </summary>
        private void txtNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}