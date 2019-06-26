namespace GameOfLifeGraphicalUI
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
            this.PlayGroundPanel = new System.Windows.Forms.Panel();
            this.Stepsize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Anzahl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Stepsize)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayGroundPanel
            // 
            this.PlayGroundPanel.Location = new System.Drawing.Point(12, 12);
            this.PlayGroundPanel.Name = "PlayGroundPanel";
            this.PlayGroundPanel.Size = new System.Drawing.Size(400, 400);
            this.PlayGroundPanel.TabIndex = 0;
            // 
            // Stepsize
            // 
            this.Stepsize.Location = new System.Drawing.Point(428, 149);
            this.Stepsize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Stepsize.Name = "Stepsize";
            this.Stepsize.Size = new System.Drawing.Size(136, 20);
            this.Stepsize.TabIndex = 1;
            this.Stepsize.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(570, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stepsize in milliseconds";
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(573, 241);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 3;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(504, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // Anzahl
            // 
            this.Anzahl.Location = new System.Drawing.Point(428, 50);
            this.Anzahl.Name = "Anzahl";
            this.Anzahl.Size = new System.Drawing.Size(100, 20);
            this.Anzahl.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(428, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Create random entities";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 425);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Anzahl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Stepsize);
            this.Controls.Add(this.PlayGroundPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Stepsize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PlayGroundPanel;
        private System.Windows.Forms.NumericUpDown Stepsize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Anzahl;
        private System.Windows.Forms.Label label3;
    }
}

