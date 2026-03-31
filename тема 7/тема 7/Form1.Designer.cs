namespace тема_7
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.halfCircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.halfEllipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reflectXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reflectYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCircle = new System.Windows.Forms.ToolStripButton();
            this.btnEllipse = new System.Windows.Forms.ToolStripButton();
            this.btnHalfCircle = new System.Windows.Forms.ToolStripButton();
            this.btnHalfEllipse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnColor = new System.Windows.Forms.ToolStripButton();
            this.btnFillColor = new System.Windows.Forms.ToolStripButton();
            this.btnStrokeWidth = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReflectX = new System.Windows.Forms.ToolStripButton();
            this.btnReflectY = new System.Windows.Forms.ToolStripButton();
            this.btnRotate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnRedo = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCoords = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.figureToolStripMenuItem,
            this.transformToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(900, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "Новый";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Загрузить";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.editToolStripMenuItem.Text = "Редактирование";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.undoToolStripMenuItem.Text = "Отменить";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.redoToolStripMenuItem.Text = "Вернуть";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyToolStripMenuItem.Text = "Копировать";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cutToolStripMenuItem.Text = "Вырезать";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pasteToolStripMenuItem.Text = "Вставить";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // figureToolStripMenuItem
            // 
            this.figureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circleToolStripMenuItem,
            this.ellipseToolStripMenuItem,
            this.halfCircleToolStripMenuItem,
            this.halfEllipseToolStripMenuItem});
            this.figureToolStripMenuItem.Name = "figureToolStripMenuItem";
            this.figureToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.figureToolStripMenuItem.Text = "Фигуры";
            // 
            // circleToolStripMenuItem
            // 
            this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            this.circleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.circleToolStripMenuItem.Text = "Круг";
            this.circleToolStripMenuItem.Click += new System.EventHandler(this.CircleToolStripMenuItem_Click);
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ellipseToolStripMenuItem.Text = "Эллипс";
            this.ellipseToolStripMenuItem.Click += new System.EventHandler(this.EllipseToolStripMenuItem_Click);
            // 
            // halfCircleToolStripMenuItem
            // 
            this.halfCircleToolStripMenuItem.Name = "halfCircleToolStripMenuItem";
            this.halfCircleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.halfCircleToolStripMenuItem.Text = "Половина круга";
            this.halfCircleToolStripMenuItem.Click += new System.EventHandler(this.HalfCircleToolStripMenuItem_Click);
            // 
            // halfEllipseToolStripMenuItem
            // 
            this.halfEllipseToolStripMenuItem.Name = "halfEllipseToolStripMenuItem";
            this.halfEllipseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.halfEllipseToolStripMenuItem.Text = "Половина эллипса";
            this.halfEllipseToolStripMenuItem.Click += new System.EventHandler(this.HalfEllipseToolStripMenuItem_Click);
            // 
            // transformToolStripMenuItem
            // 
            this.transformToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reflectXToolStripMenuItem,
            this.reflectYToolStripMenuItem,
            this.rotate90ToolStripMenuItem});
            this.transformToolStripMenuItem.Name = "transformToolStripMenuItem";
            this.transformToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.transformToolStripMenuItem.Text = "Трансформация";
            // 
            // reflectXToolStripMenuItem
            // 
            this.reflectXToolStripMenuItem.Name = "reflectXToolStripMenuItem";
            this.reflectXToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reflectXToolStripMenuItem.Text = "Отразить по X";
            this.reflectXToolStripMenuItem.Click += new System.EventHandler(this.ReflectXToolStripMenuItem_Click);
            // 
            // reflectYToolStripMenuItem
            // 
            this.reflectYToolStripMenuItem.Name = "reflectYToolStripMenuItem";
            this.reflectYToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reflectYToolStripMenuItem.Text = "Отразить по Y";
            this.reflectYToolStripMenuItem.Click += new System.EventHandler(this.ReflectYToolStripMenuItem_Click);
            // 
            // rotate90ToolStripMenuItem
            // 
            this.rotate90ToolStripMenuItem.Name = "rotate90ToolStripMenuItem";
            this.rotate90ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rotate90ToolStripMenuItem.Text = "Повернуть на 90°";
            this.rotate90ToolStripMenuItem.Click += new System.EventHandler(this.Rotate90ToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnSave,
            this.btnLoad,
            this.toolStripSeparator1,
            this.btnCircle,
            this.btnEllipse,
            this.btnHalfCircle,
            this.btnHalfEllipse,
            this.toolStripSeparator2,
            this.btnColor,
            this.btnFillColor,
            this.btnStrokeWidth,
            this.toolStripSeparator3,
            this.btnReflectX,
            this.btnReflectY,
            this.btnRotate,
            this.toolStripSeparator4,
            this.btnUndo,
            this.btnRedo});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(900, 25);
            this.toolStrip.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 22);
            this.btnNew.Text = "Новый";
            this.btnNew.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(23, 22);
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCircle
            // 
            this.btnCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(23, 22);
            this.btnCircle.Text = "Круг";
            this.btnCircle.Click += new System.EventHandler(this.CircleToolStripMenuItem_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(23, 22);
            this.btnEllipse.Text = "Эллипс";
            this.btnEllipse.Click += new System.EventHandler(this.EllipseToolStripMenuItem_Click);
            // 
            // btnHalfCircle
            // 
            this.btnHalfCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHalfCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHalfCircle.Name = "btnHalfCircle";
            this.btnHalfCircle.Size = new System.Drawing.Size(23, 22);
            this.btnHalfCircle.Text = "Пол.круга";
            this.btnHalfCircle.Click += new System.EventHandler(this.HalfCircleToolStripMenuItem_Click);
            // 
            // btnHalfEllipse
            // 
            this.btnHalfEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHalfEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHalfEllipse.Name = "btnHalfEllipse";
            this.btnHalfEllipse.Size = new System.Drawing.Size(23, 22);
            this.btnHalfEllipse.Text = "Пол.эллипс";
            this.btnHalfEllipse.Click += new System.EventHandler(this.HalfEllipseToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnColor
            // 
            this.btnColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(50, 22);
            this.btnColor.Text = "Цвет";
            this.btnColor.Click += new System.EventHandler(this.BtnColor_Click);
            // 
            // btnFillColor
            // 
            this.btnFillColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFillColor.Name = "btnFillColor";
            this.btnFillColor.Size = new System.Drawing.Size(60, 22);
            this.btnFillColor.Text = "Заливка";
            this.btnFillColor.Click += new System.EventHandler(this.BtnFillColor_Click);
            // 
            // btnStrokeWidth
            // 
            this.btnStrokeWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStrokeWidth.Name = "btnStrokeWidth";
            this.btnStrokeWidth.Size = new System.Drawing.Size(65, 22);
            this.btnStrokeWidth.Text = "Толщина";
            this.btnStrokeWidth.Click += new System.EventHandler(this.BtnStrokeWidth_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnReflectX
            // 
            this.btnReflectX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReflectX.Name = "btnReflectX";
            this.btnReflectX.Size = new System.Drawing.Size(55, 22);
            this.btnReflectX.Text = "Отр.X";
            this.btnReflectX.Click += new System.EventHandler(this.ReflectXToolStripMenuItem_Click);
            // 
            // btnReflectY
            // 
            this.btnReflectY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReflectY.Name = "btnReflectY";
            this.btnReflectY.Size = new System.Drawing.Size(55, 22);
            this.btnReflectY.Text = "Отр.Y";
            this.btnReflectY.Click += new System.EventHandler(this.ReflectYToolStripMenuItem_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(70, 22);
            this.btnRotate.Text = "Повернуть";
            this.btnRotate.Click += new System.EventHandler(this.Rotate90ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(23, 22);
            this.btnUndo.Text = "Отмена";
            this.btnUndo.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(23, 22);
            this.btnRedo.Text = "Вернуть";
            this.btnRedo.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblCoords});
            this.statusStrip.Location = new System.Drawing.Point(0, 478);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(900, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(70, 17);
            this.lblStatus.Text = "Готово";
            // 
            // lblCoords
            // 
            this.lblCoords.Name = "lblCoords";
            this.lblCoords.Size = new System.Drawing.Size(100, 17);
            this.lblCoords.Text = "";
            // 
            // panelCanvas
            // 
            this.panelCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCanvas.Location = new System.Drawing.Point(0, 49);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(900, 429);
            this.panelCanvas.TabIndex = 3;
            this.panelCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCanvas_Paint);
            this.panelCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelCanvas_MouseDown);
            this.panelCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelCanvas_MouseMove);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Vector Files|*.vec";
            this.openFileDialog1.Title = "Загрузить";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Vector Files|*.vec";
            this.saveFileDialog1.Title = "Сохранить";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.panelCanvas);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Векторный редактор - Лера";
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem halfCircleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem halfEllipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reflectXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reflectYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate90ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCircle;
        private System.Windows.Forms.ToolStripButton btnEllipse;
        private System.Windows.Forms.ToolStripButton btnHalfCircle;
        private System.Windows.Forms.ToolStripButton btnHalfEllipse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnColor;
        private System.Windows.Forms.ToolStripButton btnFillColor;
        private System.Windows.Forms.ToolStripButton btnStrokeWidth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnReflectX;
        private System.Windows.Forms.ToolStripButton btnReflectY;
        private System.Windows.Forms.ToolStripButton btnRotate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripButton btnRedo;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblCoords;
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
