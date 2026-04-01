using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Задание_8
{
    [Serializable]
    public class SlotMachine
    {
        public static string[] FruitImages = { "🍒", "🍋", "🍊", "🍇", "🍓", "🍉", "7", "⭐" };
        
        public int[] CurrentValues { get; set; } = new int[3];
        public int PlayerScore { get; set; }
        public int InitialScore { get; set; } = 100;
        public int WinTarget { get; set; } = 500;
        public bool IsSpinning { get; set; }

        public event Action<int, int, int> OnSpinComplete;
        public event Action<bool, int> OnGameEnd;

        private Random _random = new Random();

        public SlotMachine()
        {
            PlayerScore = InitialScore;
            CurrentValues = new int[] { 0, 0, 0 };
        }

        public void Spin()
        {
            if (IsSpinning || PlayerScore <= 0) return;

            PlayerScore -= 10;
            IsSpinning = true;

            for (int i = 0; i < 3; i++)
            {
                CurrentValues[i] = _random.Next(FruitImages.Length);
            }

            IsSpinning = false;
            CheckWin();
        }

        private void CheckWin()
        {
            if (CurrentValues[0] == CurrentValues[1] && CurrentValues[1] == CurrentValues[2])
            {
                int winAmount = CalculateWin(CurrentValues[0]);
                PlayerScore += winAmount;
                OnSpinComplete?.Invoke(CurrentValues[0], CurrentValues[1], CurrentValues[2]);

                if (PlayerScore >= WinTarget)
                {
                    OnGameEnd?.Invoke(true, PlayerScore);
                }
            }
            else
            {
                OnSpinComplete?.Invoke(CurrentValues[0], CurrentValues[1], CurrentValues[2]);

                if (PlayerScore <= 0)
                {
                    OnGameEnd?.Invoke(false, 0);
                }
            }
        }

        private int CalculateWin(int symbol)
        {
            switch (symbol)
            {
                case 6: return 200;
                case 5: return 100;
                case 4: return 75;
                case 3: return 50;
                case 2: return 40;
                case 1: return 30;
                case 0: return 20;
                default: return 50;
            }
        }

        public void Reset()
        {
            PlayerScore = InitialScore;
            CurrentValues = new int[] { 0, 0, 0 };
            IsSpinning = false;
        }

        public static void DrawSlot(Graphics g, Rectangle bounds, string symbol, bool highlight, Color frameColor)
        {
            using (var pen = new Pen(frameColor, 3))
            {
                if (highlight)
                {
                    using (var brush = new LinearGradientBrush(bounds, Color.Gold, Color.Orange, 45))
                    {
                        g.FillRectangle(brush, bounds);
                    }
                }
                else
                {
                    using (var brush = new LinearGradientBrush(bounds, Color.Silver, Color.DarkGray, 45))
                    {
                        g.FillRectangle(brush, bounds);
                    }
                }
                g.DrawRectangle(pen, bounds);
            }

            using (var font = new Font("Segoe UI Emoji", 36, FontStyle.Bold))
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                g.DrawString(symbol, font, Brushes.Black, bounds, sf);
            }
        }
    }
}
