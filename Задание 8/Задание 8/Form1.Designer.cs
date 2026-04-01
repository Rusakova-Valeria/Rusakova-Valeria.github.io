namespace Задание_8
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
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblPlayerName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblScore = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSpins = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelSlots = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnSpin = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.progressBarScore = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.resultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(500, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.resultsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newGameToolStripMenuItem.Text = "Новая игра";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.BtnNewGame_Click);
            // 
            // resultsToolStripMenuItem
            // 
            this.resultsToolStripMenuItem.Name = "resultsToolStripMenuItem";
            this.resultsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resultsToolStripMenuItem.Text = "Результаты";
            this.resultsToolStripMenuItem.Click += (s, e) => ShowResults();
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += (s, e) => this.Close();
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.settingsToolStripMenuItem.Text = "Настройки";
            this.settingsToolStripMenuItem.Click += (s, e) => ShowSettings();
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.helpToolStripMenuItem.Text = "Справка";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += (s, e) => ShowHelp();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPlayerName,
            this.lblScore,
            this.lblSpins});
            this.statusStrip.Location = new System.Drawing.Point(0, 403);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(500, 22);
            this.statusStrip.TabIndex = 1;
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(80, 17);
            this.lblPlayerName.Text = "Игрок: ";
            // 
            // lblScore
            // 
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(70, 17);
            this.lblScore.Text = "Очки: 100";
            // 
            // lblSpins
            // 
            this.lblSpins.Name = "lblSpins";
            this.lblSpins.Size = new System.Drawing.Size(70, 17);
            this.lblSpins.Text = "Спинов: 0";
            // 
            // panelSlots
            // 
            this.panelSlots.BackColor = System.Drawing.SystemColors.Control;
            this.panelSlots.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSlots.Location = new System.Drawing.Point(50, 80);
            this.panelSlots.Name = "panelSlots";
            this.panelSlots.Size = new System.Drawing.Size(400, 160);
            this.panelSlots.TabIndex = 2;
            this.panelSlots.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelSlots_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(192, 0, 192);
            this.lblTitle.Location = new System.Drawing.Point(50, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 50);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "🎰 ИГРОВОЙ АВТОМАТ 🎰";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblResult.Location = new System.Drawing.Point(50, 250);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(400, 30);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "Нажмите ВРАЩАТЬ";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSpin
            // 
            this.btnSpin.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
            this.btnSpin.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.btnSpin.ForeColor = System.Drawing.Color.White;
            this.btnSpin.Location = new System.Drawing.Point(150, 290);
            this.btnSpin.Name = "btnSpin";
            this.btnSpin.Size = new System.Drawing.Size(200, 50);
            this.btnSpin.TabIndex = 5;
            this.btnSpin.Text = "🎰 ВРАЩАТЬ 🎰";
            this.btnSpin.UseVisualStyleBackColor = false;
            this.btnSpin.Click += new System.EventHandler(this.BtnSpin_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.Color.FromArgb(192, 192, 192);
            this.btnNewGame.Font = new System.Drawing.Font("Arial", 10F);
            this.btnNewGame.Location = new System.Drawing.Point(370, 290);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(80, 50);
            this.btnNewGame.TabIndex = 6;
            this.btnNewGame.Text = "Новая\r\nигра";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.BtnNewGame_Click);
            // 
            // progressBarScore
            // 
            this.progressBarScore.Location = new System.Drawing.Point(50, 350);
            this.progressBarScore.Name = "progressBarScore";
            this.progressBarScore.Size = new System.Drawing.Size(400, 25);
            this.progressBarScore.TabIndex = 7;
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(50, 380);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(400, 15);
            this.lblProgress.TabIndex = 8;
            this.lblProgress.Text = "До выигрыша: 500 очков";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 425);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBarScore);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnSpin);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelSlots);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игровой автомат";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblPlayerName;
        private System.Windows.Forms.ToolStripStatusLabel lblScore;
        private System.Windows.Forms.ToolStripStatusLabel lblSpins;
        private System.Windows.Forms.Panel panelSlots;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnSpin;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.ProgressBar progressBarScore;
        private System.Windows.Forms.Label lblProgress;
    }
}
