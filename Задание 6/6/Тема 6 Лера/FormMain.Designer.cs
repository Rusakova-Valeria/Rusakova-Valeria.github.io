using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlagQuiz
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        // Исправленный метод Dispose
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
            this.cmbTheme = new ComboBox();
            this.cmbLevel = new ComboBox();
            this.btnStart = new Button();
            this.btnAdmin = new Button();
            this.gamePanel = new Panel();
            this.lblHint = new Label();
            this.btnHint = new Button();
            this.lblMessage = new Label();
            this.lblQuestionNumber = new Label();
            this.lblScore = new Label();
            this.lblTimer = new Label();
            this.btnAnswer = new Button();
            this.cmbAnswers = new ComboBox();
            this.lblQuestion = new Label();
            this.pictureBoxFlag = new PictureBox();

            this.SuspendLayout();

            // cmbTheme
            this.cmbTheme.Location = new Point(20, 20);
            this.cmbTheme.Size = new Size(200, 21);
            this.cmbTheme.DropDownStyle = ComboBoxStyle.DropDownList;

            // cmbLevel
            this.cmbLevel.Location = new Point(230, 20);
            this.cmbLevel.Size = new Size(120, 21);
            this.cmbLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbLevel.Items.AddRange(new object[] { "Легкий (10 баллов)", "Средний (20 баллов)", "Сложный (30 баллов)" });
            this.cmbLevel.SelectedIndex = 0;

            // btnStart
            this.btnStart.Location = new Point(360, 18);
            this.btnStart.Size = new Size(100, 25);
            this.btnStart.Text = "Начать игру";

            // btnAdmin
            this.btnAdmin.Location = new Point(470, 18);
            this.btnAdmin.Size = new Size(100, 25);
            this.btnAdmin.Text = "Админ панель";

            // gamePanel
            this.gamePanel.Location = new Point(20, 60);
            this.gamePanel.Size = new Size(550, 400);
            this.gamePanel.BorderStyle = BorderStyle.FixedSingle;
            this.gamePanel.Visible = false;

            // pictureBoxFlag
            this.pictureBoxFlag.Location = new Point(150, 20);
            this.pictureBoxFlag.Size = new Size(250, 150);
            this.pictureBoxFlag.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBoxFlag.BorderStyle = BorderStyle.FixedSingle;

            // lblQuestion
            this.lblQuestion.Location = new Point(20, 190);
            this.lblQuestion.Size = new Size(510, 40);
            this.lblQuestion.Font = new Font("Arial", 12, FontStyle.Bold);
            this.lblQuestion.TextAlign = ContentAlignment.MiddleCenter;

            // cmbAnswers
            this.cmbAnswers.Location = new Point(20, 250);
            this.cmbAnswers.Size = new Size(510, 21);
            this.cmbAnswers.DropDownStyle = ComboBoxStyle.DropDownList;

            // btnAnswer
            this.btnAnswer.Location = new Point(200, 290);
            this.btnAnswer.Size = new Size(150, 30);
            this.btnAnswer.Text = "Ответить";

            // lblTimer
            this.lblTimer.Location = new Point(20, 340);
            this.lblTimer.Size = new Size(150, 25);
            this.lblTimer.Font = new Font("Arial", 12, FontStyle.Bold);
            this.lblTimer.ForeColor = Color.Red;

            // lblScore
            this.lblScore.Location = new Point(380, 340);
            this.lblScore.Size = new Size(150, 25);
            this.lblScore.Font = new Font("Arial", 12, FontStyle.Bold);
            this.lblScore.TextAlign = ContentAlignment.MiddleRight;

            // lblQuestionNumber
            this.lblQuestionNumber.Location = new Point(20, 370);
            this.lblQuestionNumber.Size = new Size(200, 20);

            // lblHint
            this.lblHint.Location = new Point(20, 400);
            this.lblHint.Size = new Size(400, 40);
            this.lblHint.ForeColor = Color.Gray;
            this.lblHint.Font = new Font("Arial", 9, FontStyle.Italic);

            // btnHint
            this.btnHint.Location = new Point(430, 400);
            this.btnHint.Size = new Size(100, 25);
            this.btnHint.Text = "Подсказка";

            // lblMessage
            this.lblMessage.Location = new Point(20, 440);
            this.lblMessage.Size = new Size(510, 30);
            this.lblMessage.Font = new Font("Arial", 10, FontStyle.Bold);
            this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;

            // Добавление элементов на gamePanel
            this.gamePanel.Controls.Add(this.pictureBoxFlag);
            this.gamePanel.Controls.Add(this.lblQuestion);
            this.gamePanel.Controls.Add(this.cmbAnswers);
            this.gamePanel.Controls.Add(this.btnAnswer);
            this.gamePanel.Controls.Add(this.lblTimer);
            this.gamePanel.Controls.Add(this.lblScore);
            this.gamePanel.Controls.Add(this.lblQuestionNumber);
            this.gamePanel.Controls.Add(this.lblHint);
            this.gamePanel.Controls.Add(this.btnHint);
            this.gamePanel.Controls.Add(this.lblMessage);

            // FormMain
            this.ClientSize = new Size(590, 480);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cmbLevel);
            this.Controls.Add(this.cmbTheme);
            this.Text = "Викторина: Флаги мира";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
        }

        #endregion
    }
}