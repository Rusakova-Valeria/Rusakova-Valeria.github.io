using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        // Свойства для передачи данных обратно в Form1
        public int Speed { get; private set; }
        public Color RectColor { get; private set; }

        public Form2(int currentSpeed, Color currentColor)
        {
            InitializeComponent();

            // Устанавливаем текущие значения
            trackBarSpeed.Value = currentSpeed;
            labelSpeedValue.Text = $"{currentSpeed} ms";
            panelColorPreview.BackColor = currentColor;

            // Сохраняем начальные значения
            Speed = currentSpeed;
            RectColor = currentColor;
        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            labelSpeedValue.Text = $"{trackBarSpeed.Value} ms";
        }

        private void buttonChooseColor_Click(object sender, EventArgs e)
        {
            // Открываем диалог выбора цвета
            colorDialog1.Color = panelColorPreview.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panelColorPreview.BackColor = colorDialog1.Color;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Сохраняем выбранные значения
            Speed = trackBarSpeed.Value;
            RectColor = panelColorPreview.BackColor;
        }
    }
}