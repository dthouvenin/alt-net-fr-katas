namespace Mazes.Runner
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.drawPanel = new System.Windows.Forms.Panel();
            this.loadBuilder = new System.Windows.Forms.Button();
            this.loadSolver = new System.Windows.Forms.Button();
            this.Build = new System.Windows.Forms.Button();
            this.Solve = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.maxMoves = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.logBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxMoves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawPanel
            // 
            this.drawPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawPanel.BackColor = System.Drawing.Color.Black;
            this.drawPanel.Location = new System.Drawing.Point(2, 2);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(344, 284);
            this.drawPanel.TabIndex = 0;
            // 
            // loadBuilder
            // 
            this.loadBuilder.Location = new System.Drawing.Point(6, 19);
            this.loadBuilder.Name = "loadBuilder";
            this.loadBuilder.Size = new System.Drawing.Size(86, 26);
            this.loadBuilder.TabIndex = 2;
            this.loadBuilder.Text = "Builder ...";
            this.loadBuilder.UseVisualStyleBackColor = true;
            this.loadBuilder.Click += new System.EventHandler(this.loadBuilder_Click);
            // 
            // loadSolver
            // 
            this.loadSolver.Location = new System.Drawing.Point(98, 19);
            this.loadSolver.Name = "loadSolver";
            this.loadSolver.Size = new System.Drawing.Size(86, 26);
            this.loadSolver.TabIndex = 2;
            this.loadSolver.Text = "Solver ...";
            this.loadSolver.UseVisualStyleBackColor = true;
            this.loadSolver.Click += new System.EventHandler(this.loadSolver_Click);
            // 
            // Build
            // 
            this.Build.Location = new System.Drawing.Point(6, 19);
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(86, 26);
            this.Build.TabIndex = 2;
            this.Build.Text = "Build Maze";
            this.Build.UseVisualStyleBackColor = true;
            this.Build.Click += new System.EventHandler(this.Build_Click);
            // 
            // Solve
            // 
            this.Solve.Location = new System.Drawing.Point(235, 19);
            this.Solve.Name = "Solve";
            this.Solve.Size = new System.Drawing.Size(86, 26);
            this.Solve.TabIndex = 2;
            this.Solve.Text = "Escape maze !";
            this.Solve.UseVisualStyleBackColor = true;
            this.Solve.Click += new System.EventHandler(this.Solve_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.loadBuilder);
            this.groupBox1.Controls.Add(this.loadSolver);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 55);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.maxMoves);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Build);
            this.groupBox2.Controls.Add(this.Solve);
            this.groupBox2.Location = new System.Drawing.Point(228, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 55);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Run";
            // 
            // maxMoves
            // 
            this.maxMoves.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maxMoves.Location = new System.Drawing.Point(166, 24);
            this.maxMoves.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.maxMoves.Name = "maxMoves";
            this.maxMoves.Size = new System.Drawing.Size(63, 20);
            this.maxMoves.TabIndex = 4;
            this.maxMoves.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Max Moves";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Assemblies|*.dll;*.exe";
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.logBox.Location = new System.Drawing.Point(2, 2);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(184, 286);
            this.logBox.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(14, 75);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.drawPanel);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.logBox);
            this.splitContainer2.Size = new System.Drawing.Size(543, 290);
            this.splitContainer2.SplitterDistance = 350;
            this.splitContainer2.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 370);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Mazes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxMoves)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.Button loadBuilder;
        private System.Windows.Forms.Button loadSolver;
        private System.Windows.Forms.Button Build;
        private System.Windows.Forms.Button Solve;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NumericUpDown maxMoves;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}

