using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace тема_7
{
    public partial class Form1 : Form
    {
        private List<Figure> _figures = new List<Figure>();
        private List<Figure> _clipboard = new List<Figure>();
        private Figure _selectedFigure;
        private SelectionFrame _selectionFrame = new SelectionFrame();
        private StackMemory _undoStack = new StackMemory(20);
        private StackMemory _redoStack = new StackMemory(20);
        private Color _currentColor = Color.Black;
        private Color _currentFillColor = Color.Transparent;
        private bool _hasFill = false;
        private float _currentStrokeWidth = 2f;
        private Point _startPoint;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void SaveState()
        {
            _undoStack.Push(ObjectToStream(_figures));
            _redoStack.Clear();
        }

        private MemoryStream ObjectToStream(List<Figure> figures)
        {
            var ms = new MemoryStream();
            new BinaryFormatter().Serialize(ms, figures);
            ms.Position = 0;
            return ms;
        }

        private List<Figure> StreamToObject(MemoryStream ms)
        {
            ms.Position = 0;
            return (List<Figure>)new BinaryFormatter().Deserialize(ms);
        }

        private void PanelCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            foreach (var figure in _figures)
                figure.Draw(g);

            if (_selectedFigure != null)
            {
                _selectionFrame.Update(_selectedFigure);
                _selectionFrame.Draw(g);
            }
        }

        private void PanelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            _startPoint = e.Location;
            Figure clicked = FindFigureAt(e.Location);
            if (clicked != null)
            {
                if (_selectedFigure != clicked)
                {
                    SaveState();
                    _selectedFigure = clicked;
                }
            }
            else
            {
                _selectedFigure = null;
            }
            panelCanvas.Invalidate();
        }

        private Figure FindFigureAt(Point point)
        {
            for (int i = _figures.Count - 1; i >= 0; i--)
                if (_figures[i].ContainsPoint(point))
                    return _figures[i];
            return null;
        }

        private void CreateFigure(FigureType type)
        {
            var stroke = new Stroke(_currentColor, _currentStrokeWidth)
            {
                FillColor = _currentFillColor,
                HasFill = _hasFill
            };

            Figure figure;
            Point loc = new Point(panelCanvas.Width / 2 - 50, panelCanvas.Height / 2 - 50);

            switch (type)
            {
                case FigureType.Circle:
                    figure = new Circle(loc, new Size(100, 100), stroke);
                    break;
                case FigureType.Ellipse:
                    figure = new Ellipse(loc, new Size(150, 100), stroke);
                    break;
                case FigureType.HalfCircle:
                    figure = new HalfCircle(loc, new Size(100, 100), stroke);
                    break;
                case FigureType.HalfEllipse:
                    figure = new HalfEllipse(loc, new Size(150, 100), stroke);
                    break;
                default:
                    figure = new Circle(loc, new Size(100, 100), stroke);
                    break;
            }

            SaveState();
            _figures.Add(figure);
            _selectedFigure = figure;
            panelCanvas.Invalidate();
            lblStatus.Text = "Добавлено: " + figure.GetType().Name;
        }

        private enum FigureType { Circle, Ellipse, HalfCircle, HalfEllipse }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_selectedFigure == null) return;
            int pixels = e.Shift ? 1 : 5;

            SaveState();

            switch (e.KeyCode)
            {
                case Keys.Left: _selectedFigure.ShiftLeft(pixels); break;
                case Keys.Right: _selectedFigure.ShiftRight(pixels); break;
                case Keys.Up: _selectedFigure.ShiftUp(pixels); break;
                case Keys.Down: _selectedFigure.ShiftDown(pixels); break;
                case Keys.Delete: DeleteSelected(); return;
                default: return;
            }
            panelCanvas.Invalidate();
        }

        private void DeleteSelected()
        {
            if (_selectedFigure != null)
            {
                SaveState();
                _figures.Remove(_selectedFigure);
                _selectedFigure = null;
                panelCanvas.Invalidate();
                lblStatus.Text = "Удалено";
            }
        }

        // ========== Меню Файл ==========
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_figures.Count > 0 && MessageBox.Show("Очистить холст?", "Новый", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            SaveState();
            _figures.Clear();
            _selectedFigure = null;
            panelCanvas.Invalidate();
            lblStatus.Text = "Новый холст";
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var fs = new FileStream(saveFileDialog1.FileName, FileMode.Create))
                        new BinaryFormatter().Serialize(fs, _figures);
                    lblStatus.Text = "Сохранено";
                }
                catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
                        _figures = (List<Figure>)new BinaryFormatter().Deserialize(fs);
                    _selectedFigure = null;
                    panelCanvas.Invalidate();
                    lblStatus.Text = "Загружено";
                }
                catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
            }
        }

        // ========== Меню Редактирование ==========
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_undoStack.Count > 0)
            {
                var ms = new MemoryStream();
                _undoStack.Pop(ms);
                _redoStack.Push(ObjectToStream(_figures));
                _figures = StreamToObject(ms);
                _selectedFigure = null;
                panelCanvas.Invalidate();
                lblStatus.Text = "Отменено";
            }
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_redoStack.Count > 0)
            {
                var ms = new MemoryStream();
                _redoStack.Pop(ms);
                _undoStack.Push(ObjectToStream(_figures));
                _figures = StreamToObject(ms);
                _selectedFigure = null;
                panelCanvas.Invalidate();
                lblStatus.Text = "Возврат";
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedFigure != null)
            {
                _clipboard.Clear();
                _clipboard.Add(_selectedFigure.Clone());
                lblStatus.Text = "Скопировано";
            }
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedFigure != null)
            {
                _clipboard.Clear();
                _clipboard.Add(_selectedFigure.Clone());
                SaveState();
                _figures.Remove(_selectedFigure);
                _selectedFigure = null;
                panelCanvas.Invalidate();
                lblStatus.Text = "Вырезано";
            }
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_clipboard.Count > 0)
            {
                SaveState();
                var pasted = _clipboard[0].Clone();
                pasted.Location = new Point(pasted.Location.X + 20, pasted.Location.Y + 20);
                _figures.Add(pasted);
                _selectedFigure = pasted;
                panelCanvas.Invalidate();
                lblStatus.Text = "Вставлено";
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e) => DeleteSelected();

        // ========== Меню Фигуры ==========
        private void CircleToolStripMenuItem_Click(object sender, EventArgs e) => CreateFigure(FigureType.Circle);
        private void EllipseToolStripMenuItem_Click(object sender, EventArgs e) => CreateFigure(FigureType.Ellipse);
        private void HalfCircleToolStripMenuItem_Click(object sender, EventArgs e) => CreateFigure(FigureType.HalfCircle);
        private void HalfEllipseToolStripMenuItem_Click(object sender, EventArgs e) => CreateFigure(FigureType.HalfEllipse);

        // ========== Меню Трансформация ==========
        private void ReflectXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedFigure != null)
            {
                SaveState();
                _selectedFigure.ReflectX();
                panelCanvas.Invalidate();
                lblStatus.Text = "Отражено по X";
            }
        }

        private void ReflectYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedFigure != null)
            {
                SaveState();
                _selectedFigure.ReflectY();
                panelCanvas.Invalidate();
                lblStatus.Text = "Отражено по Y";
            }
        }

        private void Rotate90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedFigure != null)
            {
                SaveState();
                _selectedFigure.Rotate(90);
                panelCanvas.Invalidate();
                lblStatus.Text = "Повёрнуто на 90°";
            }
        }

        // ========== Панель инструментов ==========
        private void BtnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _currentColor = colorDialog1.Color;
                if (_selectedFigure != null)
                {
                    SaveState();
                    _selectedFigure.Stroke.Color = _currentColor;
                    panelCanvas.Invalidate();
                }
            }
        }

        private void BtnFillColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _currentFillColor = colorDialog1.Color;
                _hasFill = true;
                if (_selectedFigure != null)
                {
                    SaveState();
                    _selectedFigure.Stroke.FillColor = _currentFillColor;
                    _selectedFigure.Stroke.HasFill = true;
                    panelCanvas.Invalidate();
                }
            }
        }

        private void BtnStrokeWidth_Click(object sender, EventArgs e)
        {
            using (var form = new Form())
            {
                form.Text = "Толщина линии";
                form.StartPosition = FormStartPosition.CenterParent;
                form.ClientSize = new Size(200, 60);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;

                var numeric = new NumericUpDown { Location = new Point(10, 15), Size = new Size(80, 25), Value = (decimal)_currentStrokeWidth, Minimum = 1, Maximum = 20 };
                var okBtn = new Button { Text = "OK", Location = new Point(100, 15), Size = new Size(80, 25), DialogResult = DialogResult.OK };

                form.Controls.Add(numeric);
                form.Controls.Add(okBtn);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _currentStrokeWidth = (float)numeric.Value;
                    if (_selectedFigure != null)
                    {
                        SaveState();
                        _selectedFigure.Stroke.Width = _currentStrokeWidth;
                        panelCanvas.Invalidate();
                    }
                }
            }
        }

        private void PanelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            lblCoords.Text = string.Format("X: {0}, Y: {1}", e.X, e.Y);
        }
    }
}
