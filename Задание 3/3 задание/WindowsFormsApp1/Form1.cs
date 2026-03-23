using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // Параметры прямоугольника
        private Rectangle rect;
        private int rectWidth = 60;
        private int rectHeight = 40;
        private Color rectColor = Color.Blue;

        // Параметры движения
        private int stepY = 5; // шаг движения по вертикали
        private int direction = 1; // 1 - вниз, -1 - вверх
        private bool isFlipped = false; // перевернут ли прямоугольник

        // Для обработки нажатия клавиши
        private bool isRunning = true;

        public Form1()
        {
            InitializeComponent();
            // Начальная позиция - центр формы
            rect = new Rectangle(
                (ClientSize.Width - rectWidth) / 2,
                (ClientSize.Height - rectHeight) / 2,
                rectWidth,
                rectHeight
            );

            // Запускаем таймер
            timer1.Start();

            // Подписываемся на событие KeyPreview, чтобы форма перехватывала клавиши
            this.KeyPreview = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isRunning) return;

            // Движение по вертикали
            rect.Y += stepY * direction;

            // Проверка достижения границ
            bool hitBoundary = false;

            if (rect.Y <= 0) // Верхняя граница
            {
                rect.Y = 0;
                direction = 1; // начинаем движение вниз
                hitBoundary = true;
            }
            else if (rect.Y + rect.Height >= ClientSize.Height) // Нижняя граница
            {
                rect.Y = ClientSize.Height - rect.Height;
                direction = -1; // начинаем движение вверх
                hitBoundary = true;
            }

            // При достижении границы - переворот и смена цвета
            if (hitBoundary)
            {
                FlipRectangle();
                ChangeColor();
            }

            // Перерисовываем форму
            Invalidate();
        }

        private void FlipRectangle()
        {
            isFlipped = !isFlipped;

            // Меняем ширину и высоту местами (переворот)
            int temp = rect.Width;
            rect.Width = rect.Height;
            rect.Height = temp;

            // Корректируем позицию, чтобы прямоугольник не вылез за границы
            if (rect.Y + rect.Height > ClientSize.Height)
            {
                rect.Y = ClientSize.Height - rect.Height;
            }
        }

        private void ChangeColor()
        {
            // Генерируем случайный цвет
            Random rand = new Random();
            rectColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Рисуем прямоугольник
            using (SolidBrush brush = new SolidBrush(rectColor))
            {
                e.Graphics.FillRectangle(brush, rect);
            }

            // Рисуем рамку вокруг прямоугольника
            using (Pen pen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // При изменении размера формы проверяем, не вышел ли прямоугольник за границы
            if (rect.Y + rect.Height > ClientSize.Height)
            {
                rect.Y = ClientSize.Height - rect.Height;
            }
            if (rect.Y < 0)
            {
                rect.Y = 0;
            }

            // Перерисовываем
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Окончание работы при нажатии любой клавиши
            isRunning = false;
            timer1.Stop();

            // Показываем сообщение
            MessageBox.Show("Программа завершена. Нажмите ОК для выхода.", "Завершение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Закрываем форму
            this.Close();
        }

        private void настройкиДвиженияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создаем и показываем форму настроек
            using (Form2 settingsForm = new Form2(timer1.Interval, rectColor))
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    // Применяем настройки
                    timer1.Interval = settingsForm.Speed;
                    rectColor = settingsForm.RectColor;

                    // Обновляем отображение скорости в статусной строке
                    toolStripStatusLabelSpeed.Text = $"{timer1.Interval} ms";

                    // Перерисовываем
                    Invalidate();
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}