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
            this.distance = new System.Windows.Forms.NumericUpDown();
            this.fullCycles = new System.Windows.Forms.NumericUpDown();
            this.backgroundCB = new System.Windows.Forms.CheckBox();
            this.renderFreqLbl = new System.Windows.Forms.Label();
            this.delayLbl = new System.Windows.Forms.Label();
            this.algoDDBox = new System.Windows.Forms.ComboBox();
            this.redrawFreq = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.delaySlider = new System.Windows.Forms.TrackBar();
            this.runTillEndBtn = new System.Windows.Forms.Button();
            this.statusLbl = new System.Windows.Forms.Label();
            this.maxIters = new System.Windows.Forms.NumericUpDown();
            this.runNItersBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.runSingleIter = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.limit = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.distance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.fullCycles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.redrawFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.delaySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.maxIters)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.limit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 552);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 478);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(233, 74);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.limit);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.distance);
            this.panel3.Controls.Add(this.fullCycles);
            this.panel3.Controls.Add(this.backgroundCB);
            this.panel3.Controls.Add(this.renderFreqLbl);
            this.panel3.Controls.Add(this.delayLbl);
            this.panel3.Controls.Add(this.algoDDBox);
            this.panel3.Controls.Add(this.redrawFreq);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.delaySlider);
            this.panel3.Controls.Add(this.runTillEndBtn);
            this.panel3.Controls.Add(this.statusLbl);
            this.panel3.Controls.Add(this.maxIters);
            this.panel3.Controls.Add(this.runNItersBtn);
            this.panel3.Controls.Add(this.startBtn);
            this.panel3.Controls.Add(this.runSingleIter);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(233, 478);
            this.panel3.TabIndex = 0;
            // 
            // distance
            // 
            this.distance.Location = new System.Drawing.Point(135, 340);
            this.distance.Name = "distance";
            this.distance.Size = new System.Drawing.Size(86, 23);
            this.distance.TabIndex = 14;
            // 
            // fullCycles
            // 
            this.fullCycles.Location = new System.Drawing.Point(134, 138);
            this.fullCycles.Maximum = new decimal(new int[] {10000000, 0, 0, 0});
            this.fullCycles.Name = "fullCycles";
            this.fullCycles.Size = new System.Drawing.Size(86, 23);
            this.fullCycles.TabIndex = 13;
            this.fullCycles.Value = new decimal(new int[] {1, 0, 0, 0});
            // 
            // backgroundCB
            // 
            this.backgroundCB.AutoSize = true;
            this.backgroundCB.Location = new System.Drawing.Point(14, 168);
            this.backgroundCB.Name = "backgroundCB";
            this.backgroundCB.Size = new System.Drawing.Size(192, 19);
            this.backgroundCB.TabIndex = 12;
            this.backgroundCB.Text = "Execute in a background thread";
            this.backgroundCB.UseVisualStyleBackColor = true;
            // 
            // renderFreqLbl
            // 
            this.renderFreqLbl.AutoSize = true;
            this.renderFreqLbl.Location = new System.Drawing.Point(14, 276);
            this.renderFreqLbl.Name = "renderFreqLbl";
            this.renderFreqLbl.Size = new System.Drawing.Size(133, 15);
            this.renderFreqLbl.TabIndex = 11;
            this.renderFreqLbl.Text = "Render every iterations :";
            // 
            // delayLbl
            // 
            this.delayLbl.AutoSize = true;
            this.delayLbl.Location = new System.Drawing.Point(14, 192);
            this.delayLbl.Name = "delayLbl";
            this.delayLbl.Size = new System.Drawing.Size(95, 15);
            this.delayLbl.TabIndex = 10;
            this.delayLbl.Text = "Iteration Delay: 0";
            // 
            // algoDDBox
            // 
            this.algoDDBox.FormattingEnabled = true;
            this.algoDDBox.Items.AddRange(new object[] {"Flood", "A*", "A* - mod1", "A* - mod2"});
            this.algoDDBox.Location = new System.Drawing.Point(14, 3);
            this.algoDDBox.Name = "algoDDBox";
            this.algoDDBox.Size = new System.Drawing.Size(140, 23);
            this.algoDDBox.TabIndex = 9;
            this.algoDDBox.SelectedValueChanged += new System.EventHandler(this.algoDDBox_SelectedValueChanged);
            // 
            // redrawFreq
            // 
            this.redrawFreq.Location = new System.Drawing.Point(12, 294);
            this.redrawFreq.Maximum = 500;
            this.redrawFreq.Minimum = 1;
            this.redrawFreq.Name = "redrawFreq";
            this.redrawFreq.Size = new System.Drawing.Size(212, 45);
            this.redrawFreq.TabIndex = 8;
            this.redrawFreq.Value = 10;
            this.redrawFreq.ValueChanged += new System.EventHandler(this.redrawFreq_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(134, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 27);
            this.button1.TabIndex = 7;
            this.button1.Text = "stopBtn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // delaySlider
            // 
            this.delaySlider.Location = new System.Drawing.Point(12, 210);
            this.delaySlider.Maximum = 2000;
            this.delaySlider.Name = "delaySlider";
            this.delaySlider.Size = new System.Drawing.Size(212, 45);
            this.delaySlider.SmallChange = 10;
            this.delaySlider.TabIndex = 6;
            this.delaySlider.Value = 1;
            this.delaySlider.ValueChanged += new System.EventHandler(this.delaySlider_ValueChanged);
            // 
            // runTillEndBtn
            // 
            this.runTillEndBtn.Location = new System.Drawing.Point(14, 135);
            this.runTillEndBtn.Name = "runTillEndBtn";
            this.runTillEndBtn.Size = new System.Drawing.Size(87, 27);
            this.runTillEndBtn.TabIndex = 5;
            this.runTillEndBtn.Text = "Run Full";
            this.runTillEndBtn.UseVisualStyleBackColor = true;
            this.runTillEndBtn.Click += new System.EventHandler(this.runTillEndBtn_Click);
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(12, 415);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(39, 15);
            this.statusLbl.TabIndex = 4;
            this.statusLbl.Text = "Status";
            // 
            // maxIters
            // 
            this.maxIters.Location = new System.Drawing.Point(134, 102);
            this.maxIters.Maximum = new decimal(new int[] {10000000, 0, 0, 0});
            this.maxIters.Name = "maxIters";
            this.maxIters.Size = new System.Drawing.Size(86, 23);
            this.maxIters.TabIndex = 3;
            this.maxIters.Value = new decimal(new int[] {10000, 0, 0, 0});
            // 
            // runNItersBtn
            // 
            this.runNItersBtn.Location = new System.Drawing.Point(14, 102);
            this.runNItersBtn.Name = "runNItersBtn";
            this.runNItersBtn.Size = new System.Drawing.Size(87, 27);
            this.runNItersBtn.TabIndex = 2;
            this.runNItersBtn.Text = "Run iters #";
            this.runNItersBtn.UseVisualStyleBackColor = true;
            this.runNItersBtn.Click += new System.EventHandler(this.runNItersBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(14, 35);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(87, 27);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Restart";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // runSingleIter
            // 
            this.runSingleIter.Location = new System.Drawing.Point(14, 68);
            this.runSingleIter.Name = "runSingleIter";
            this.runSingleIter.Size = new System.Drawing.Size(87, 27);
            this.runSingleIter.TabIndex = 0;
            this.runSingleIter.Text = "Run single";
            this.runSingleIter.UseVisualStyleBackColor = true;
            this.runSingleIter.Click += new System.EventHandler(this.runSingleIter_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(233, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(767, 552);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(767, 552);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1000, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
                {this.openMapToolStripMenuItem});
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
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "Distance";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "Limit";
            // 
            // limit
            // 
            this.limit.Location = new System.Drawing.Point(134, 369);
            this.limit.Name = "limit";
            this.limit.Size = new System.Drawing.Size(86, 23);
            this.limit.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 576);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.distance)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.fullCycles)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.redrawFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.delaySlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.maxIters)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.limit)).EndInit();
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
        private System.Windows.Forms.NumericUpDown maxIters;
        private System.Windows.Forms.Button runNItersBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar delaySlider;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar redrawFreq;
        private System.Windows.Forms.ComboBox algoDDBox;
        private System.Windows.Forms.Label renderFreqLbl;
        private System.Windows.Forms.Label delayLbl;
        private System.Windows.Forms.CheckBox backgroundCB;
        private System.Windows.Forms.NumericUpDown fullCycles;
        private System.Windows.Forms.NumericUpDown distance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown limit;
        private System.Windows.Forms.Label label2;
    }
}

