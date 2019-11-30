namespace MazeGenerator
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.nbXCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nbYCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblGenerationTime = new System.Windows.Forms.Label();
            this.lblPrintTime = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nbXCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbYCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(116, 86);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // nbXCount
            // 
            this.nbXCount.Location = new System.Drawing.Point(71, 12);
            this.nbXCount.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nbXCount.Name = "nbXCount";
            this.nbXCount.Size = new System.Drawing.Size(120, 20);
            this.nbXCount.TabIndex = 1;
            this.nbXCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y Count";
            // 
            // nbYCount
            // 
            this.nbYCount.Location = new System.Drawing.Point(71, 44);
            this.nbYCount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nbYCount.Name = "nbYCount";
            this.nbYCount.Size = new System.Drawing.Size(120, 20);
            this.nbYCount.TabIndex = 4;
            this.nbYCount.Value = new decimal(new int[] {
            130,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Generation Time (ms) :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Draw Time (ms) :";
            // 
            // lblGenerationTime
            // 
            this.lblGenerationTime.AutoSize = true;
            this.lblGenerationTime.Location = new System.Drawing.Point(130, 128);
            this.lblGenerationTime.Name = "lblGenerationTime";
            this.lblGenerationTime.Size = new System.Drawing.Size(10, 13);
            this.lblGenerationTime.TabIndex = 7;
            this.lblGenerationTime.Text = "-";
            // 
            // lblPrintTime
            // 
            this.lblPrintTime.AutoSize = true;
            this.lblPrintTime.Location = new System.Drawing.Point(130, 153);
            this.lblPrintTime.Name = "lblPrintTime";
            this.lblPrintTime.Size = new System.Drawing.Size(10, 13);
            this.lblPrintTime.TabIndex = 8;
            this.lblPrintTime.Text = "-";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(15, 86);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 207);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblPrintTime);
            this.Controls.Add(this.lblGenerationTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nbYCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nbXCount);
            this.Controls.Add(this.btnPrint);
            this.Name = "Form1";
            this.Text = "Maze Generate & Print";
            ((System.ComponentModel.ISupportInitialize)(this.nbXCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbYCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.NumericUpDown nbXCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nbYCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblGenerationTime;
        private System.Windows.Forms.Label lblPrintTime;
        private System.Windows.Forms.Button btnGenerate;
    }
}

