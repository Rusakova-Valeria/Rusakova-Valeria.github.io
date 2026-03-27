using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlagQuiz
{
    partial class FormAdmin
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
            this.txtTheme = new TextBox();
            this.cmbLevel = new ComboBox();
            this.txtQuestion = new TextBox();
            this.txtImagePath = new TextBox();
            this.btnBrowseImage = new Button();
            this.txtHint = new TextBox();
            this.txtAnswer1 = new TextBox();
            this.txtAnswer2 = new TextBox();
            this.txtAnswer3 = new TextBox();
            this.txtAnswer4 = new TextBox();
            this.cmbCorrectAnswer = new ComboBox();
            this.btnAdd = new Button();
            this.btnClose = new Button();

            this.SuspendLayout();

            // txtTheme
            this.txtTheme.Location = new Point(130, 20);
            this.txtTheme.Size = new Size(200, 20);

            // cmbLevel
            this.cmbLevel.Location = new Point(150, 55);
            this.cmbLevel.Size = new Size(100, 21);
            this.cmbLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbLevel.Items.AddRange(new object[] { "Легкий (1)", "Средний (2)", "Сложный (3)" });
            this.cmbLevel.SelectedIndex = 0;

            // txtQuestion
            this.txtQuestion.Location = new Point(130, 95);
            this.txtQuestion.Size = new Size(330, 20);

            // txtImagePath
            this.txtImagePath.Location = new Point(130, 135);
            this.txtImagePath.Size = new Size(270, 20);

            // btnBrowseImage
            this.btnBrowseImage.Location = new Point(410, 133);
            this.btnBrowseImage.Size = new Size(50, 25);
            this.btnBrowseImage.Text = "Обзор";

            // txtHint
            this.txtHint.Location = new Point(130, 175);
            this.txtHint.Size = new Size(330, 20);

            // txtAnswer1
            this.txtAnswer1.Location = new Point(130, 250);
            this.txtAnswer1.Size = new Size(330, 20);

            // txtAnswer2
            this.txtAnswer2.Location = new Point(130, 280);
            this.txtAnswer2.Size = new Size(330, 20);

            // txtAnswer3
            this.txtAnswer3.Location = new Point(130, 310);
            this.txtAnswer3.Size = new Size(330, 20);

            // txtAnswer4
            this.txtAnswer4.Location = new Point(130, 340);
            this.txtAnswer4.Size = new Size(330, 20);

            // cmbCorrectAnswer
            this.cmbCorrectAnswer.Location = new Point(150, 380);
            this.cmbCorrectAnswer.Size = new Size(100, 21);
            this.cmbCorrectAnswer.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCorrectAnswer.Items.AddRange(new object[] { "Вариант 1", "Вариант 2", "Вариант 3", "Вариант 4" });
            this.cmbCorrectAnswer.SelectedIndex = 0;

            // btnAdd
            this.btnAdd.Location = new Point(150, 420);
            this.btnAdd.Size = new Size(150, 30);
            this.btnAdd.Text = "Добавить вопрос";
            this.btnAdd.BackColor = Color.LightGreen;

            // btnClose
            this.btnClose.Location = new Point(310, 420);
            this.btnClose.Size = new Size(100, 30);
            this.btnClose.Text = "Закрыть";

            // FormAdmin
            this.Text = "Админ панель - Добавление вопросов";
            this.Size = new Size(500, 500);
            this.StartPosition = FormStartPosition.CenterParent;

            this.Controls.Add(this.txtTheme);
            this.Controls.Add(this.cmbLevel);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.btnBrowseImage);
            this.Controls.Add(this.txtHint);
            this.Controls.Add(this.txtAnswer1);
            this.Controls.Add(this.txtAnswer2);
            this.Controls.Add(this.txtAnswer3);
            this.Controls.Add(this.txtAnswer4);
            this.Controls.Add(this.cmbCorrectAnswer);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);

            this.ResumeLayout(false);
        }

        #endregion
    }
}