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
            this.drawPanel = new System.Windows.Forms.Panel();
            this.loadBuilder = new System.Windows.Forms.Button();
            this.loadSolver = new System.Windows.Forms.Button();
            this.Build = new System.Windows.Forms.Button();
            this.Solve = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.log = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawPanel
            // 
            this.drawPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawPanel.BackColor = System.Drawing.Color.Black;
            this.drawPanel.Location = new System.Drawing.Point(12, 77);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(401, 281);
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
            // 
            // loadSolver
            // 
            this.loadSolver.Location = new System.Drawing.Point(98, 19);
            this.loadSolver.Name = "loadSolver";
            this.loadSolver.Size = new System.Drawing.Size(86, 26);
            this.loadSolver.TabIndex = 2;
            this.loadSolver.Text = "Solver ...";
            this.loadSolver.UseVisualStyleBackColor = true;
            // 
            // Build
            // 
            this.Build.Location = new System.Drawing.Point(6, 19);
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(86, 26);
            this.Build.TabIndex = 2;
            this.Build.Text = "Build Maze";
            this.Build.UseVisualStyleBackColor = true;
            // 
            // Solve
            // 
            this.Solve.Location = new System.Drawing.Point(98, 19);
            this.Solve.Name = "Solve";
            this.Solve.Size = new System.Drawing.Size(86, 26);
            this.Solve.TabIndex = 2;
            this.Solve.Text = "Escape maze !";
            this.Solve.UseVisualStyleBackColor = true;
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
            this.groupBox2.Controls.Add(this.Build);
            this.groupBox2.Controls.Add(this.Solve);
            this.groupBox2.Location = new System.Drawing.Point(228, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(189, 55);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Run";
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log.Location = new System.Drawing.Point(421, 77);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(223, 280);
            this.log.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 370);
            this.Controls.Add(this.log);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.drawPanel);
            this.Name = "Form1";
            this.Text = "Mazes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.Label log;
    }
}

