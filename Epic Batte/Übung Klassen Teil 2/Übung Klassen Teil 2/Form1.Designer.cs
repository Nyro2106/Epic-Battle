namespace EpicBattleSimulator
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.progBarHealth = new System.Windows.Forms.ProgressBar();
            this.progBarEnemy = new System.Windows.Forms.ProgressBar();
            this.lblInfo = new System.Windows.Forms.Label();
            this.timRound = new System.Windows.Forms.Timer(this.components);
            this.timRound2 = new System.Windows.Forms.Timer(this.components);
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblEnemy = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuesSpielToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spielSpeichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spielLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLbLBottom = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLeisteBottom = new System.Windows.Forms.ToolStripProgressBar();
            this.contextMenuStripZauberbuch = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.heilungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feuerballToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picSpellbook = new System.Windows.Forms.PictureBox();
            this.picSwordAttack = new System.Windows.Forms.PictureBox();
            this.lblPlayerInfo = new System.Windows.Forms.Label();
            this.lblEnemyInfo = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStripZauberbuch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSpellbook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSwordAttack)).BeginInit();
            this.SuspendLayout();
            // 
            // progBarHealth
            // 
            this.progBarHealth.Location = new System.Drawing.Point(52, 140);
            this.progBarHealth.Name = "progBarHealth";
            this.progBarHealth.Size = new System.Drawing.Size(100, 18);
            this.progBarHealth.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progBarHealth.TabIndex = 2;
            // 
            // progBarEnemy
            // 
            this.progBarEnemy.Location = new System.Drawing.Point(394, 135);
            this.progBarEnemy.Name = "progBarEnemy";
            this.progBarEnemy.Size = new System.Drawing.Size(100, 23);
            this.progBarEnemy.TabIndex = 5;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(196, 56);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(28, 13);
            this.lblInfo.TabIndex = 7;
            this.lblInfo.Text = "Info:";
            // 
            // timRound
            // 
            this.timRound.Interval = 2000;
            this.timRound.Tick += new System.EventHandler(this.timRound_Tick);
            // 
            // timRound2
            // 
            this.timRound2.Interval = 2000;
            this.timRound2.Tick += new System.EventHandler(this.timRound2_Tick);
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Location = new System.Drawing.Point(49, 56);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(39, 13);
            this.lblPlayer.TabIndex = 8;
            this.lblPlayer.Text = "Spieler";
            // 
            // lblEnemy
            // 
            this.lblEnemy.AutoSize = true;
            this.lblEnemy.Location = new System.Drawing.Point(391, 56);
            this.lblEnemy.Name = "lblEnemy";
            this.lblEnemy.Size = new System.Drawing.Size(42, 13);
            this.lblEnemy.TabIndex = 9;
            this.lblEnemy.Text = "Gegner";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.beendenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(534, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuesSpielToolStripMenuItem,
            this.spielSpeichernToolStripMenuItem,
            this.spielLadenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // neuesSpielToolStripMenuItem
            // 
            this.neuesSpielToolStripMenuItem.Name = "neuesSpielToolStripMenuItem";
            this.neuesSpielToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.neuesSpielToolStripMenuItem.Text = "Neues Spiel";
            this.neuesSpielToolStripMenuItem.Click += new System.EventHandler(this.neuesSpielToolStripMenuItem_Click);
            // 
            // spielSpeichernToolStripMenuItem
            // 
            this.spielSpeichernToolStripMenuItem.Name = "spielSpeichernToolStripMenuItem";
            this.spielSpeichernToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.spielSpeichernToolStripMenuItem.Text = "Spiel Speichern";
            this.spielSpeichernToolStripMenuItem.Click += new System.EventHandler(this.spielSpeichernToolStripMenuItem_Click);
            // 
            // spielLadenToolStripMenuItem
            // 
            this.spielLadenToolStripMenuItem.Name = "spielLadenToolStripMenuItem";
            this.spielLadenToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.spielLadenToolStripMenuItem.Text = "Spiel Laden";
            this.spielLadenToolStripMenuItem.Click += new System.EventHandler(this.spielLadenToolStripMenuItem_Click);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLbLBottom,
            this.toolStripStatusLeisteBottom});
            this.statusStrip1.Location = new System.Drawing.Point(0, 464);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(534, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLbLBottom
            // 
            this.toolStripStatusLbLBottom.Name = "toolStripStatusLbLBottom";
            this.toolStripStatusLbLBottom.Size = new System.Drawing.Size(85, 17);
            this.toolStripStatusLbLBottom.Text = "Status: Normal";
            // 
            // toolStripStatusLeisteBottom
            // 
            this.toolStripStatusLeisteBottom.Maximum = 3;
            this.toolStripStatusLeisteBottom.Name = "toolStripStatusLeisteBottom";
            this.toolStripStatusLeisteBottom.Size = new System.Drawing.Size(100, 16);
            // 
            // contextMenuStripZauberbuch
            // 
            this.contextMenuStripZauberbuch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heilungToolStripMenuItem,
            this.feuerballToolStripMenuItem});
            this.contextMenuStripZauberbuch.Name = "contextMenuStripZauberbuch";
            this.contextMenuStripZauberbuch.Size = new System.Drawing.Size(123, 48);
            // 
            // heilungToolStripMenuItem
            // 
            this.heilungToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("heilungToolStripMenuItem.Image")));
            this.heilungToolStripMenuItem.Name = "heilungToolStripMenuItem";
            this.heilungToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.heilungToolStripMenuItem.Text = "Heilung";
            this.heilungToolStripMenuItem.Click += new System.EventHandler(this.heilungToolStripMenuItem_Click);
            // 
            // feuerballToolStripMenuItem
            // 
            this.feuerballToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("feuerballToolStripMenuItem.Image")));
            this.feuerballToolStripMenuItem.Name = "feuerballToolStripMenuItem";
            this.feuerballToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.feuerballToolStripMenuItem.Text = "Feuerball";
            // 
            // picSpellbook
            // 
            this.picSpellbook.ContextMenuStrip = this.contextMenuStripZauberbuch;
            this.picSpellbook.Image = ((System.Drawing.Image)(resources.GetObject("picSpellbook.Image")));
            this.picSpellbook.InitialImage = ((System.Drawing.Image)(resources.GetObject("picSpellbook.InitialImage")));
            this.picSpellbook.Location = new System.Drawing.Point(281, 234);
            this.picSpellbook.Name = "picSpellbook";
            this.picSpellbook.Size = new System.Drawing.Size(54, 62);
            this.picSpellbook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSpellbook.TabIndex = 19;
            this.picSpellbook.TabStop = false;
            // 
            // picSwordAttack
            // 
            this.picSwordAttack.Image = ((System.Drawing.Image)(resources.GetObject("picSwordAttack.Image")));
            this.picSwordAttack.Location = new System.Drawing.Point(181, 236);
            this.picSwordAttack.Name = "picSwordAttack";
            this.picSwordAttack.Size = new System.Drawing.Size(68, 60);
            this.picSwordAttack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSwordAttack.TabIndex = 20;
            this.picSwordAttack.TabStop = false;
            this.picSwordAttack.Click += new System.EventHandler(this.picSwordAttack_Click);
            // 
            // lblPlayerInfo
            // 
            this.lblPlayerInfo.AutoSize = true;
            this.lblPlayerInfo.Location = new System.Drawing.Point(49, 69);
            this.lblPlayerInfo.Name = "lblPlayerInfo";
            this.lblPlayerInfo.Size = new System.Drawing.Size(28, 13);
            this.lblPlayerInfo.TabIndex = 22;
            this.lblPlayerInfo.Text = "Info:";
            // 
            // lblEnemyInfo
            // 
            this.lblEnemyInfo.AutoSize = true;
            this.lblEnemyInfo.Location = new System.Drawing.Point(391, 69);
            this.lblEnemyInfo.Name = "lblEnemyInfo";
            this.lblEnemyInfo.Size = new System.Drawing.Size(28, 13);
            this.lblEnemyInfo.TabIndex = 23;
            this.lblEnemyInfo.Text = "Info:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 486);
            this.Controls.Add(this.lblEnemyInfo);
            this.Controls.Add(this.lblPlayerInfo);
            this.Controls.Add(this.picSwordAttack);
            this.Controls.Add(this.picSpellbook);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblEnemy);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.progBarEnemy);
            this.Controls.Add(this.progBarHealth);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Epic Battle Simulator v0.6";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStripZauberbuch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSpellbook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSwordAttack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progBarHealth;
        private System.Windows.Forms.ProgressBar progBarEnemy;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Timer timRound;
        private System.Windows.Forms.Timer timRound2;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Label lblEnemy;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuesSpielToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spielSpeichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spielLadenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLbLBottom;
        private System.Windows.Forms.ToolStripProgressBar toolStripStatusLeisteBottom;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripZauberbuch;
        private System.Windows.Forms.ToolStripMenuItem heilungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feuerballToolStripMenuItem;
        private System.Windows.Forms.PictureBox picSpellbook;
        private System.Windows.Forms.PictureBox picSwordAttack;
        private System.Windows.Forms.Label lblPlayerInfo;
        private System.Windows.Forms.Label lblEnemyInfo;
    }
}

