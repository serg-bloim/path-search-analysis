namespace AlgoUI
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.startBtn = new System.Windows.Forms.Button();
            this.runSingleIter = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.runNItersBtn = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.statusLbl = new System.Windows.Forms.Label();
            this.runTillEndBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 426);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 185);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 241);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.runTillEndBtn);
            this.panel3.Controls.Add(this.statusLbl);
            this.panel3.Controls.Add(this.numericUpDown1);
            this.panel3.Controls.Add(this.runNItersBtn);
            this.panel3.Controls.Add(this.startBtn);
            this.panel3.Controls.Add(this.runSingleIter);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 185);
            this.panel3.TabIndex = 0;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(12, 3);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // runSingleIter
            // 
            this.runSingleIter.Location = new System.Drawing.Point(12, 32);
            this.runSingleIter.Name = "runSingleIter";
            this.runSingleIter.Size = new System.Drawing.Size(75, 23);
            this.runSingleIter.TabIndex = 0;
            this.runSingleIter.Text = "Run single";
            this.runSingleIter.UseVisualStyleBackColor = true;
            this.runSingleIter.Click += new System.EventHandler(this.runSingleIter_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(200, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 426);
            this.panel2.TabIndex = 1;
            this.panel2.SizeChanged += new System.EventHandler(this.panel2_SizeChanged);
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMapToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openMapToolStripMenuItem
            // 
            this.openMapToolStripMenuItem.Name = "openMapToolStripMenuItem";
            this.openMapToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.openMapToolStripMenuItem.Text = "Open map";
            this.openMapToolStripMenuItem.Click += new System.EventHandler(this.openMapToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // runNItersBtn
            // 
            this.runNItersBtn.Location = new System.Drawing.Point(12, 61);
            this.runNItersBtn.Name = "runNItersBtn";
            this.runNItersBtn.Size = new System.Drawing.Size(75, 23);
            this.runNItersBtn.TabIndex = 2;
            this.runNItersBtn.Text = "Run #";
            this.runNItersBtn.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(93, 64);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(74, 20);
            this.numericUpDown1.TabIndex = 3;
            // 
            // status
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(12, 169);
            this.statusLbl.Name = "status";
            this.statusLbl.Size = new System.Drawing.Size(0, 13);
            this.statusLbl.TabIndex = 4;
            // 
            // runTillEndBtn
            // 
            this.runTillEndBtn.Location = new System.Drawing.Point(12, 90);
            this.runTillEndBtn.Name = "runTillEndBtn";
            this.runTillEndBtn.Size = new System.Drawing.Size(75, 23);
            this.runTillEndBtn.TabIndex = 5;
            this.runTillEndBtn.Text = "Run Till End";
            this.runTillEndBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMapToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button runSingleIter;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button runTillEndBtn;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button runNItersBtn;
    }
}

