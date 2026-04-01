using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Задание_8
{
    public partial class Form1 : Form
    {
        private SlotMachine _slotMachine;
        private string _playerName;
        private int _spinsCount = 0;
        private Timer _spinTimer;
        private Timer _animationTimer;
        private Random _random = new Random();
        private int _animationPhase = 0;
        private List<int[]> _animationFrames = new List<int[]>();
        private int _currentFrame = 0;
        private Color _frameColor = Color.Gold;
        private List<GameResult> _results = new List<GameResult>();
        private string _dataPath;

        public Form1()
        {
            InitializeComponent();
            _slotMachine = new SlotMachine();
            _dataPath = Path.Combine(Application.StartupPath, "data");
            if (!Directory.Exists(_dataPath))
                Directory.CreateDirectory(_dataPath);

            LoadResults();
            ShowLoginDialog();
            SetupTimers();
        }

        private void SetupTimers()
        {
            _spinTimer = new Timer();
            _spinTimer.Interval = 50;
            _spinTimer.Tick += SpinTimer_Tick;

            _animationTimer = new Timer();
            _animationTimer.Interval = 100;
            _animationTimer.Tick += AnimationTimer_Tick;
        }

        private void ShowLoginDialog()
        {
            using (var form = new Form())
            {
                form.Text = "Вход";
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ClientSize = new Size(300, 120);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                var label = new Label { Text = "Введите имя игрока:", Location = new Point(10, 15), Size = new Size(280, 20) };
                var textBox = new TextBox { Location = new Point(10, 40), Size = new Size(280, 25), Text = "Игрок" };
                var okBtn = new Button { Text = "OK", Location = new Point(100, 70), Size = new Size(100, 30), DialogResult = DialogResult.OK };

                form.Controls.Add(label);
                form.Controls.Add(textBox);
                form.Controls.Add(okBtn);

                if (form.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(textBox.Text))
                    _playerName = textBox.Text;
                else
                    _playerName = "Игрок";

                lblPlayerName.Text = "Игрок: " + _playerName;
                lblProgress.Text = "До выигрыша: " + _slotMachine.WinTarget + " очков";
            }
            SetupTimers();
        }

        private void SpinTimer_Tick(object sender, EventArgs e)
        {
            _animationPhase++;
            if (_animationPhase >= 30)
            {
                _spinTimer.Stop();
                _animationPhase = 0;
                FinishSpin();
            }
            panelSlots.Invalidate();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            _currentFrame++;
            if (_currentFrame >= _animationFrames.Count)
            {
                _animationTimer.Stop();
                _currentFrame = 0;
            }
            panelSlots.Invalidate();
        }

        private void StartSpin()
        {
            if (_slotMachine.IsSpinning || _slotMachine.PlayerScore <= 0)
            {
                if (_slotMachine.PlayerScore <= 0)
                    MessageBox.Show("У вас закончились очки! Начните новую игру.", "Конец игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _spinsCount++;
            lblSpins.Text = "Спинов: " + _spinsCount;

            GenerateAnimationFrames();
            _currentFrame = 0;
            _animationTimer.Interval = 80;
            _animationTimer.Start();
            _spinTimer.Start();
        }

        private void GenerateAnimationFrames()
        {
            _animationFrames.Clear();
            int target1 = _random.Next(SlotMachine.FruitImages.Length);
            int target2 = _random.Next(SlotMachine.FruitImages.Length);
            int target3 = _random.Next(SlotMachine.FruitImages.Length);

            for (int i = 0; i < 15; i++)
            {
                _animationFrames.Add(new int[] {
                    _random.Next(SlotMachine.FruitImages.Length),
                    _random.Next(SlotMachine.FruitImages.Length),
                    _random.Next(SlotMachine.FruitImages.Length)
                });
            }

            _animationFrames.Add(new int[] { target1, target2, target3 });
        }

        private void FinishSpin()
        {
            int bet = 10;
            _slotMachine.PlayerScore -= bet;
            UpdateScore();

            _slotMachine.Spin();
            UpdateSlots();
            CheckWin();
        }

        private void CheckWin()
        {
            int[] values = _slotMachine.CurrentValues;
            bool isJackpot = values[0] == values[1] && values[1] == values[2];

            if (isJackpot)
            {
                int winAmount = values[0] == 6 ? 200 : values[0] == 5 ? 100 : values[0] == 4 ? 75 : 50;
                _slotMachine.PlayerScore += winAmount;
                lblResult.Text = "ДЖЕКПОТ! +" + winAmount;
                lblResult.ForeColor = Color.Gold;
                panelSlots.BackColor = Color.FromArgb(50, 205, 50);
            }
            else
            {
                lblResult.Text = "Попробуйте ещё раз!";
                lblResult.ForeColor = Color.Red;
                panelSlots.BackColor = SystemColors.Control;
            }

            UpdateScore();

            if (_slotMachine.PlayerScore >= _slotMachine.WinTarget)
            {
                EndGame(true);
            }
            else if (_slotMachine.PlayerScore <= 0)
            {
                EndGame(false);
            }
        }

        private void EndGame(bool won)
        {
            _spinTimer.Stop();
            _animationTimer.Stop();

            var result = new GameResult(_playerName, _slotMachine.PlayerScore, _spinsCount, won);
            _results.Add(result);
            SaveResults();

            string message = won
                ? $"Поздравляем! Вы выиграли {_slotMachine.PlayerScore} очков!\nСделано спинов: {_spinsCount}"
                : "Игра окончена. Очки закончились.";

            var dialogResult = MessageBox.Show(message + "\n\nНачать новую игру?", won ? "Победа!" : "Конец игры",
                MessageBoxButtons.YesNo, won ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
                NewGame();
            else
                btnSpin.Enabled = false;
        }

        private void UpdateSlots()
        {
            panelSlots.Invalidate();
        }

        private void UpdateScore()
        {
            lblScore.Text = "Очки: " + _slotMachine.PlayerScore;
            progressBarScore.Value = Math.Min(100, _slotMachine.PlayerScore * 100 / _slotMachine.WinTarget);
            int remaining = _slotMachine.WinTarget - _slotMachine.PlayerScore;
            lblProgress.Text = remaining > 0 ? "До выигрыша: " + remaining + " очков" : "Цель достигнута!";
        }

        private void NewGame()
        {
            _slotMachine.Reset();
            _spinsCount = 0;
            lblSpins.Text = "Спинов: 0";
            lblResult.Text = "Нажмите ВРАЩАТЬ";
            lblResult.ForeColor = Color.Black;
            panelSlots.BackColor = SystemColors.Control;
            btnSpin.Enabled = true;
            UpdateScore();
            panelSlots.Invalidate();
        }

        private void SaveResults()
        {
            try
            {
                string filePath = Path.Combine(_dataPath, "results.dat");
                using (var fs = new FileStream(filePath, FileMode.Create))
                    new BinaryFormatter().Serialize(fs, _results);
            }
            catch { }
        }

        private void LoadResults()
        {
            try
            {
                string filePath = Path.Combine(_dataPath, "results.dat");
                if (File.Exists(filePath))
                {
                    using (var fs = new FileStream(filePath, FileMode.Open))
                        _results = (List<GameResult>)new BinaryFormatter().Deserialize(fs);
                }
            }
            catch { }
        }

        private void ShowResults()
        {
            string message = "История игр:\n\n";
            foreach (var r in _results)
            {
                message += $"{r.PlayerName}: {r.FinalScore} очков ({r.SpinsCount} спинов) - {(r.IsWin ? "Победа" : "Проигрыш")}\n";
            }
            MessageBox.Show(message, "Результаты", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowSettings()
        {
            using (var form = new Form())
            {
                form.Text = "Настройки";
                form.StartPosition = FormStartPosition.CenterParent;
                form.ClientSize = new Size(350, 200);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;

                var lbl1 = new Label { Text = "Начальные очки:", Location = new Point(10, 15), Size = new Size(120, 20) };
                var numInitial = new NumericUpDown { Location = new Point(140, 12), Size = new Size(80, 25), Value = _slotMachine.InitialScore, Minimum = 10, Maximum = 1000 };

                var lbl2 = new Label { Text = "Цель выигрыша:", Location = new Point(10, 50), Size = new Size(120, 20) };
                var numTarget = new NumericUpDown { Location = new Point(140, 47), Size = new Size(80, 25), Value = _slotMachine.WinTarget, Minimum = 50, Maximum = 10000 };

                var lbl3 = new Label { Text = "Цвет рамки:", Location = new Point(10, 85), Size = new Size(120, 20) };
                var btnColor = new Button { Text = "Выбрать", Location = new Point(140, 82), Size = new Size(80, 25) };
                var colorPanel = new Panel { Location = new Point(230, 82), Size = new Size(40, 25), BackColor = _frameColor, BorderStyle = BorderStyle.FixedSingle };

                btnColor.Click += (s, e) =>
                {
                    using (var cd = new ColorDialog())
                    {
                        if (cd.ShowDialog() == DialogResult.OK)
                        {
                            _frameColor = cd.Color;
                            colorPanel.BackColor = _frameColor;
                        }
                    }
                };

                var okBtn = new Button { Text = "OK", Location = new Point(130, 130), Size = new Size(80, 30), DialogResult = DialogResult.OK };

                form.Controls.AddRange(new Control[] { lbl1, numInitial, lbl2, numTarget, lbl3, btnColor, colorPanel, okBtn });

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _slotMachine.InitialScore = (int)numInitial.Value;
                    _slotMachine.WinTarget = (int)numTarget.Value;
                    NewGame();
                }
            }
        }

        private void ShowHelp()
        {
            MessageBox.Show("ИГРОВОЙ АВТОМАТ\n\n" +
                "Правила:\n" +
                "- Нажмите ВРАЩАТЬ, чтобы запустить барабаны\n" +
                "- Ставка за спин: 10 очков\n" +
                "- Три одинаковых символа = выигрыш!\n" +
                "- Джекпот даёт до 200 очков\n" +
                "- Цель: набрать " + _slotMachine.WinTarget + " очков\n\n" +
                "Управление:\n" +
                "- Стрелки или кнопки на форме",
                "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PanelSlots_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(SystemColors.Control);

            int slotWidth = 100;
            int slotHeight = 100;
            int spacing = 20;
            int totalWidth = slotWidth * 3 + spacing * 2;
            int startX = (panelSlots.Width - totalWidth) / 2;
            int startY = (panelSlots.Height - slotHeight) / 2;

            int[] values;
            if (_animationTimer.Enabled && _currentFrame < _animationFrames.Count)
                values = _animationFrames[_currentFrame];
            else
                values = _slotMachine.CurrentValues;

            for (int i = 0; i < 3; i++)
            {
                var bounds = new Rectangle(startX + i * (slotWidth + spacing), startY, slotWidth, slotHeight);
                bool highlight = (i < values.Length && _slotMachine.PlayerScore >= _slotMachine.WinTarget) || 
                               (values[0] == values[1] && values[1] == values[2]);
                SlotMachine.DrawSlot(g, bounds, SlotMachine.FruitImages[values[i]], highlight, _frameColor);
            }
        }

        private void BtnSpin_Click(object sender, EventArgs e)
        {
            StartSpin();
        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            if (_spinsCount > 0)
            {
                var result = MessageBox.Show("Начать новую игру? Текущий прогресс будет потерян.", "Новая игра",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
            }
            NewGame();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {
                StartSpin();
            }
        }
    }
}
