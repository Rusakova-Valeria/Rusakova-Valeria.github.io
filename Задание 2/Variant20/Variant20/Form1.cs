using System;
using System.Windows.Forms;

namespace Variant20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string expression = txtExpression.Text.Trim();

                if (string.IsNullOrEmpty(expression))
                {
                    MessageBox.Show("Введите выражение для вычисления.", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double result = ExpressionCalculator.Calculate(expression);
                lblResult.Text = $"Результат: {result}";
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Ошибка в выражении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неожиданная ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtExpression.Clear();
            lblResult.Text = "Результат:";
            txtExpression.Focus();
        }

        private void btnExample_Click(object sender, EventArgs e)
        {
            txtExpression.Text = "-13.5*7 - 21.6/3.2/0.15 + 1.5^3 - 98.5";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}