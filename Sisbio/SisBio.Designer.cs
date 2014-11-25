namespace TCC
{
    partial class SisBio
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
            this.BrowseButton = new System.Windows.Forms.Button();
            this.PathSeeker = new System.Windows.Forms.OpenFileDialog();
            this.DB = new System.Windows.Forms.ComboBox();
            this.DataBaseLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.diretorioBox = new System.Windows.Forms.TextBox();
            this.BLASTButton = new System.Windows.Forms.Button();
            this.PathLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SaveBox = new System.Windows.Forms.TextBox();
            this.SaveIn = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PercentLabel = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.Strip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SaveDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.AboutStrip = new System.Windows.Forms.MenuStrip();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.Strip.SuspendLayout();
            this.panel4.SuspendLayout();
            this.AboutStrip.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(507, 0);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 0;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // DB
            // 
            this.DB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DB.FormattingEnabled = true;
            this.DB.Items.AddRange(new object[] {
            "Non-redundant protein sequences (nr)",
            "Reference proteins (refseq_protein)",
            "UniProtKB/Swiss-Prot(swissprot)",
            "Patented protein sequences(pat)",
            "Protein Data Bank proteins(pdb)",
            "Metagenomic proteins(env_nr)",
            "Transcriptome Shotgun Assembly proteins (tsa_nr)"});
            this.DB.Location = new System.Drawing.Point(70, 9);
            this.DB.Name = "DB";
            this.DB.Size = new System.Drawing.Size(275, 21);
            this.DB.TabIndex = 1;
            // 
            // DataBaseLabel
            // 
            this.DataBaseLabel.AutoSize = true;
            this.DataBaseLabel.Location = new System.Drawing.Point(8, 12);
            this.DataBaseLabel.Name = "DataBaseLabel";
            this.DataBaseLabel.Size = new System.Drawing.Size(56, 13);
            this.DataBaseLabel.TabIndex = 3;
            this.DataBaseLabel.Text = "Database:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DB);
            this.panel1.Controls.Add(this.DataBaseLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 35);
            this.panel1.TabIndex = 4;
            // 
            // diretorioBox
            // 
            this.diretorioBox.Location = new System.Drawing.Point(61, 3);
            this.diretorioBox.Name = "diretorioBox";
            this.diretorioBox.Size = new System.Drawing.Size(440, 20);
            this.diretorioBox.TabIndex = 5;
            this.diretorioBox.TextChanged += new System.EventHandler(this.diretorioBox_TextChanged);
            // 
            // BLASTButton
            // 
            this.BLASTButton.Location = new System.Drawing.Point(507, 5);
            this.BLASTButton.Name = "BLASTButton";
            this.BLASTButton.Size = new System.Drawing.Size(75, 23);
            this.BLASTButton.TabIndex = 6;
            this.BLASTButton.Text = "BLAST";
            this.BLASTButton.UseVisualStyleBackColor = true;
            this.BLASTButton.Click += new System.EventHandler(this.BLASTButton_Click);
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(8, 8);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(32, 13);
            this.PathLabel.TabIndex = 7;
            this.PathLabel.Text = "Path:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SaveButton);
            this.panel2.Controls.Add(this.diretorioBox);
            this.panel2.Controls.Add(this.SaveBox);
            this.panel2.Controls.Add(this.SaveIn);
            this.panel2.Controls.Add(this.PathLabel);
            this.panel2.Controls.Add(this.BrowseButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(593, 58);
            this.panel2.TabIndex = 8;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(507, 32);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Browse";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SaveBox
            // 
            this.SaveBox.Location = new System.Drawing.Point(61, 35);
            this.SaveBox.Name = "SaveBox";
            this.SaveBox.Size = new System.Drawing.Size(440, 20);
            this.SaveBox.TabIndex = 1;
            // 
            // SaveIn
            // 
            this.SaveIn.AutoSize = true;
            this.SaveIn.Location = new System.Drawing.Point(8, 38);
            this.SaveIn.Name = "SaveIn";
            this.SaveIn.Size = new System.Drawing.Size(47, 13);
            this.SaveIn.TabIndex = 0;
            this.SaveIn.Text = "Save In:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.PercentLabel);
            this.panel3.Controls.Add(this.ProgressLabel);
            this.panel3.Controls.Add(this.pBar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 122);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(593, 47);
            this.panel3.TabIndex = 9;
            // 
            // PercentLabel
            // 
            this.PercentLabel.AutoSize = true;
            this.PercentLabel.Location = new System.Drawing.Point(67, 5);
            this.PercentLabel.Name = "PercentLabel";
            this.PercentLabel.Size = new System.Drawing.Size(42, 13);
            this.PercentLabel.TabIndex = 2;
            this.PercentLabel.Text = "NoText";
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(8, 5);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(51, 13);
            this.ProgressLabel.TabIndex = 1;
            this.ProgressLabel.Text = "Progress:";
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(3, 21);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(587, 23);
            this.pBar.Step = 1;
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar.TabIndex = 0;
            // 
            // Strip
            // 
            this.Strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.Strip.Location = new System.Drawing.Point(0, 193);
            this.Strip.Name = "Strip";
            this.Strip.Size = new System.Drawing.Size(593, 22);
            this.Strip.TabIndex = 10;
            this.Strip.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(45, 17);
            this.StatusLabel.Text = "NoText";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BLASTButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 89);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(593, 33);
            this.panel4.TabIndex = 11;
            // 
            // AboutStrip
            // 
            this.AboutStrip.BackColor = System.Drawing.SystemColors.Control;
            this.AboutStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem});
            this.AboutStrip.Location = new System.Drawing.Point(0, 0);
            this.AboutStrip.Name = "AboutStrip";
            this.AboutStrip.Size = new System.Drawing.Size(593, 24);
            this.AboutStrip.TabIndex = 12;
            this.AboutStrip.Text = "menu";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.sobreToolStripMenuItem.Text = "About";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.Strip);
            this.panel5.Controls.Add(this.AboutStrip);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(595, 217);
            this.panel5.TabIndex = 13;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Controls.Add(this.panel4);
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 24);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(593, 169);
            this.panel6.TabIndex = 13;
            // 
            // SisBio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 217);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.AboutStrip;
            this.MaximizeBox = false;
            this.Name = "SisBio";
            this.Text = "SisBio";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.Strip.ResumeLayout(false);
            this.Strip.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.AboutStrip.ResumeLayout(false);
            this.AboutStrip.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.OpenFileDialog PathSeeker;
        private System.Windows.Forms.ComboBox DB;
        private System.Windows.Forms.Label DataBaseLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox diretorioBox;
        private System.Windows.Forms.Button BLASTButton;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.StatusStrip Strip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Label PercentLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox SaveBox;
        private System.Windows.Forms.Label SaveIn;
        private System.Windows.Forms.FolderBrowserDialog SaveDialog;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.MenuStrip AboutStrip;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
    }
}

