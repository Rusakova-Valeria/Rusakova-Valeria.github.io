using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Чтение данных
            double x = double.Parse(textBox1.Text);
            double eps = double.Parse(textBox2.Text);

            // Проверка области определения (x > -1)
            if (x <= -1)
            {
                MessageBox.Show("Область определения: x > -1", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Левая часть - математическая функция √(1+x)
            double left = Math.Sqrt(1 + x);

            // Вычисление суммы ряда
            double sum = 1.0;        // U₀ = 1 (n=0)
            double term = 0.5 * x;    // U₁ = (1/2)x (n=1)
            int n = 1;
            int memberCount = 1;      // уже учли первый член

            // Добавляем второй член, если он больше точности
            if (Math.Abs(term) > eps)
            {
                sum += term;
                memberCount++;
            }
            else
            {
                // Если второй член уже меньше точности
                textBox3.Text = left.ToString("F10");
                textBox4.Text = sum.ToString("F10");
                textBox5.Text = memberCount.ToString();
                return;
            }

            // Суммируем остальные члены (n >= 2)
            while (Math.Abs(term) > eps)
            {
                n++;

                // Рекуррентная формула для члена n:
                // Uₙ = Uₙ₋₁ * (-x) * (2n-3)/(2n)
                term = term * (-x) * (2.0 * n - 3) / (2.0 * n);

                if (Math.Abs(term) > eps)
                {
                    sum += term;
                    memberCount++;
                }
            }

            // Вывод результатов
            textBox3.Text = left.ToString("F10");
            textBox4.Text = sum.ToString("F10");
            textBox5.Text = memberCount.ToString();
        }

        // Проверка ввода
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != ',' && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '-' && ((TextBox)sender).Text.Length > 0)
                e.Handled = true;

            if (e.KeyChar == ',' && ((TextBox)sender).Text.Contains(","))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && ((TextBox)sender).Text.Contains(","))
                e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrEmpty(textBox1.Text) &&
                             !string.IsNullOrEmpty(textBox2.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrEmpty(textBox1.Text) &&
                             !string.IsNullOrEmpty(textBox2.Text);
        }
    }
}