namespace Epic_Battle_Simulator
{
    partial class Stadt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdFightOn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdFightOn
            // 
            this.cmdFightOn.Location = new System.Drawing.Point(242, 385);
            this.cmdFightOn.Name = "cmdFightOn";
            this.cmdFightOn.Size = new System.Drawing.Size(88, 23);
            this.cmdFightOn.TabIndex = 0;
            this.cmdFightOn.Text = "Weiterkämpfen";
            this.cmdFightOn.UseVisualStyleBackColor = true;
            this.cmdFightOn.Click += new System.EventHandler(this.cmdFightOn_Click);
            // 
            // Stadt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 420);
            this.Controls.Add(this.cmdFightOn);
            this.Name = "Stadt";
            this.Text = "Stadt";
            this.Load += new System.EventHandler(this.Stadt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdFightOn;
    }
}