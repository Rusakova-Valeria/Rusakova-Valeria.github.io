using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Элементы управления
        private TabControl tabControl;
        private TabPage tabPageInput;
        private TabPage tabPageTable;
        private TabPage tabPageChart;

        // Вкладка 1: Ввод данных
        private GroupBox groupBoxAdd;
        private Label lblDistrictName;
        private TextBox txtDistrictName;
        private Label lblTotalResidents;
        private TextBox txtTotalResidents;
        private Label lblParticipated;
        private TextBox txtParticipated;
        private Button btnAddDistrict;

        private GroupBox groupBoxInfo;
        private Label lblElectionNameTitle;
        private Label lblElectionName;
        private Button btnChangeElectionName;
        private Label lblTotalVotersTitle;
        private Label lblTotalVoters;
        private Label lblTotalParticipatedTitle;
        private Label lblTotalParticipated;
        private Label lblAverageTitle;
        private Label lblAverageParticipation;

        private GroupBox groupBoxActions;
        private Button btnSave;
        private Button btnLoad;
        private Button btnClearAll;

        // Вкладка 2: Таблица данных
        private DataGridView dataGridViewDistricts;
        private Button btnRemoveDistrict;

        // Вкладка 3: Диаграмма
        private System.Windows.Forms.DataVisualization.Charting.Chart chartParticipation;

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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageInput = new System.Windows.Forms.TabPage();
            this.tabPageTable = new System.Windows.Forms.TabPage();
            this.tabPageChart = new System.Windows.Forms.TabPage();

            // ===== Вкладка 1: Ввод данных =====
            this.groupBoxAdd = new System.Windows.Forms.GroupBox();
            this.lblDistrictName = new System.Windows.Forms.Label();
            this.txtDistrictName = new System.Windows.Forms.TextBox();
            this.lblTotalResidents = new System.Windows.Forms.Label();
            this.txtTotalResidents = new System.Windows.Forms.TextBox();
            this.lblParticipated = new System.Windows.Forms.Label();
            this.txtParticipated = new System.Windows.Forms.TextBox();
            this.btnAddDistrict = new System.Windows.Forms.Button();

            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.lblElectionNameTitle = new System.Windows.Forms.Label();
            this.lblElectionName = new System.Windows.Forms.Label();
            this.btnChangeElectionName = new System.Windows.Forms.Button();
            this.lblTotalVotersTitle = new System.Windows.Forms.Label();
            this.lblTotalVoters = new System.Windows.Forms.Label();
            this.lblTotalParticipatedTitle = new System.Windows.Forms.Label();
            this.lblTotalParticipated = new System.Windows.Forms.Label();
            this.lblAverageTitle = new System.Windows.Forms.Label();
            this.lblAverageParticipation = new System.Windows.Forms.Label();

            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();

            // ===== Вкладка 2: Таблица данных =====
            this.dataGridViewDistricts = new System.Windows.Forms.DataGridView();
            this.btnRemoveDistrict = new System.Windows.Forms.Button();

            // ===== Вкладка 3: Диаграмма =====
            this.chartParticipation = new System.Windows.Forms.DataVisualization.Charting.Chart();

            // Настройка TabControl
            this.tabControl.Controls.Add(this.tabPageInput);
            this.tabControl.Controls.Add(this.tabPageTable);
            this.tabControl.Controls.Add(this.tabPageChart);
            this.tabControl.Dock = DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Arial", 10F);

            // ===== Настройка вкладки 1 =====
            this.tabPageInput.Text = "Ввод данных";
            this.tabPageInput.Font = new System.Drawing.Font("Arial", 9F);

            // GroupBox для добавления
            this.groupBoxAdd.Text = "Добавление нового округа";
            this.groupBoxAdd.Location = new System.Drawing.Point(15, 15);
            this.groupBoxAdd.Size = new System.Drawing.Size(550, 150);

            this.lblDistrictName.Text = "Название округа:";
            this.lblDistrictName.Location = new System.Drawing.Point(15, 30);
            this.lblDistrictName.Size = new System.Drawing.Size(120, 20);

            this.txtDistrictName.Location = new System.Drawing.Point(140, 27);
            this.txtDistrictName.Size = new System.Drawing.Size(200, 22);

            this.lblTotalResidents.Text = "Количество жителей:";
            this.lblTotalResidents.Location = new System.Drawing.Point(15, 60);
            this.lblTotalResidents.Size = new System.Drawing.Size(120, 20);

            this.txtTotalResidents.Location = new System.Drawing.Point(140, 57);
            this.txtTotalResidents.Size = new System.Drawing.Size(200, 22);
            this.txtTotalResidents.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);

            this.lblParticipated.Text = "Участвовало:";
            this.lblParticipated.Location = new System.Drawing.Point(15, 90);
            this.lblParticipated.Size = new System.Drawing.Size(120, 20);

            this.txtParticipated.Location = new System.Drawing.Point(140, 87);
            this.txtParticipated.Size = new System.Drawing.Size(200, 22);
            this.txtParticipated.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);

            this.btnAddDistrict.Text = "Добавить округ";
            this.btnAddDistrict.Location = new System.Drawing.Point(360, 60);
            this.btnAddDistrict.Size = new System.Drawing.Size(150, 35);
            this.btnAddDistrict.UseVisualStyleBackColor = true;
            this.btnAddDistrict.Click += new System.EventHandler(this.btnAddDistrict_Click);

            this.groupBoxAdd.Controls.Add(this.lblDistrictName);
            this.groupBoxAdd.Controls.Add(this.txtDistrictName);
            this.groupBoxAdd.Controls.Add(this.lblTotalResidents);
            this.groupBoxAdd.Controls.Add(this.txtTotalResidents);
            this.groupBoxAdd.Controls.Add(this.lblParticipated);
            this.groupBoxAdd.Controls.Add(this.txtParticipated);
            this.groupBoxAdd.Controls.Add(this.btnAddDistrict);

            // GroupBox для информации
            this.groupBoxInfo.Text = "Информация о выборах";
            this.groupBoxInfo.Location = new System.Drawing.Point(15, 180);
            this.groupBoxInfo.Size = new System.Drawing.Size(550, 150);

            this.lblElectionNameTitle.Text = "Название выборов:";
            this.lblElectionNameTitle.Location = new System.Drawing.Point(15, 30);
            this.lblElectionNameTitle.Size = new System.Drawing.Size(120, 20);
            this.lblElectionNameTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);

            this.lblElectionName.Text = "Новые выборы";
            this.lblElectionName.Location = new System.Drawing.Point(140, 30);
            this.lblElectionName.Size = new System.Drawing.Size(200, 20);

            this.btnChangeElectionName.Text = "Изменить";
            this.btnChangeElectionName.Location = new System.Drawing.Point(360, 25);
            this.btnChangeElectionName.Size = new System.Drawing.Size(150, 30);
            this.btnChangeElectionName.UseVisualStyleBackColor = true;
            this.btnChangeElectionName.Click += new System.EventHandler(this.btnChangeElectionName_Click);

            this.lblTotalVotersTitle.Text = "Всего избирателей:";
            this.lblTotalVotersTitle.Location = new System.Drawing.Point(15, 60);
            this.lblTotalVotersTitle.Size = new System.Drawing.Size(120, 20);

            this.lblTotalVoters.Text = "0";
            this.lblTotalVoters.Location = new System.Drawing.Point(140, 60);
            this.lblTotalVoters.Size = new System.Drawing.Size(100, 20);
            this.lblTotalVoters.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);

            this.lblTotalParticipatedTitle.Text = "Всего участвовало:";
            this.lblTotalParticipatedTitle.Location = new System.Drawing.Point(15, 90);
            this.lblTotalParticipatedTitle.Size = new System.Drawing.Size(120, 20);

            this.lblTotalParticipated.Text = "0";
            this.lblTotalParticipated.Location = new System.Drawing.Point(140, 90);
            this.lblTotalParticipated.Size = new System.Drawing.Size(100, 20);
            this.lblTotalParticipated.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);

            this.lblAverageTitle.Text = "Средняя явка:";
            this.lblAverageTitle.Location = new System.Drawing.Point(15, 120);
            this.lblAverageTitle.Size = new System.Drawing.Size(120, 20);

            this.lblAverageParticipation.Text = "0%";
            this.lblAverageParticipation.Location = new System.Drawing.Point(140, 120);
            this.lblAverageParticipation.Size = new System.Drawing.Size(100, 20);
            this.lblAverageParticipation.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblAverageParticipation.ForeColor = System.Drawing.Color.Blue;

            this.groupBoxInfo.Controls.Add(this.lblElectionNameTitle);
            this.groupBoxInfo.Controls.Add(this.lblElectionName);
            this.groupBoxInfo.Controls.Add(this.btnChangeElectionName);
            this.groupBoxInfo.Controls.Add(this.lblTotalVotersTitle);
            this.groupBoxInfo.Controls.Add(this.lblTotalVoters);
            this.groupBoxInfo.Controls.Add(this.lblTotalParticipatedTitle);
            this.groupBoxInfo.Controls.Add(this.lblTotalParticipated);
            this.groupBoxInfo.Controls.Add(this.lblAverageTitle);
            this.groupBoxInfo.Controls.Add(this.lblAverageParticipation);

            // GroupBox для действий
            this.groupBoxActions.Text = "Действия с файлами";
            this.groupBoxActions.Location = new System.Drawing.Point(15, 345);
            this.groupBoxActions.Size = new System.Drawing.Size(550, 80);

            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(15, 30);
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnLoad.Text = "Загрузить";
            this.btnLoad.Location = new System.Drawing.Point(150, 30);
            this.btnLoad.Size = new System.Drawing.Size(120, 35);
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            this.btnClearAll.Text = "Очистить все";
            this.btnClearAll.Location = new System.Drawing.Point(285, 30);
            this.btnClearAll.Size = new System.Drawing.Size(120, 35);
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);

            this.groupBoxActions.Controls.Add(this.btnSave);
            this.groupBoxActions.Controls.Add(this.btnLoad);
            this.groupBoxActions.Controls.Add(this.btnClearAll);

            this.tabPageInput.Controls.Add(this.groupBoxAdd);
            this.tabPageInput.Controls.Add(this.groupBoxInfo);
            this.tabPageInput.Controls.Add(this.groupBoxActions);

            // ===== Настройка вкладки 2 =====
            this.tabPageTable.Text = "Таблица данных";

            this.dataGridViewDistricts.Location = new System.Drawing.Point(15, 15);
            this.dataGridViewDistricts.Size = new System.Drawing.Size(760, 350);
            this.dataGridViewDistricts.TabIndex = 0;

            this.btnRemoveDistrict.Text = "Удалить выбранный округ";
            this.btnRemoveDistrict.Location = new System.Drawing.Point(15, 380);
            this.btnRemoveDistrict.Size = new System.Drawing.Size(200, 35);
            this.btnRemoveDistrict.UseVisualStyleBackColor = true;
            this.btnRemoveDistrict.Click += new System.EventHandler(this.btnRemoveDistrict_Click);

            this.tabPageTable.Controls.Add(this.dataGridViewDistricts);
            this.tabPageTable.Controls.Add(this.btnRemoveDistrict);

            // ===== Настройка вкладки 3 =====
            this.tabPageChart.Text = "Диаграмма";

            this.chartParticipation.Location = new System.Drawing.Point(15, 15);
            this.chartParticipation.Size = new System.Drawing.Size(760, 400);
            this.chartParticipation.TabIndex = 0;

            this.tabPageChart.Controls.Add(this.chartParticipation);

            // ===== Настройка формы =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вариант 20: Статистика выборов";

            this.tabPageInput.ResumeLayout(false);
            this.tabPageTable.ResumeLayout(false);
            this.tabPageChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDistricts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartParticipation)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}