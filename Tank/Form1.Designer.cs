
namespace Tank
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.playerTank = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.playerTank)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Health";
            // 
            // healthBar
            // 
            this.healthBar.Location = new System.Drawing.Point(79, 9);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(159, 23);
            this.healthBar.TabIndex = 1;
            this.healthBar.Value = 100;
            // 
            // playerTank
            // 
            this.playerTank.Image = global::Tank.Properties.Resources.PlayerTankUp;
            this.playerTank.Location = new System.Drawing.Point(552, 356);
            this.playerTank.Name = "playerTank";
            this.playerTank.Size = new System.Drawing.Size(50, 75);
            this.playerTank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerTank.TabIndex = 2;
            this.playerTank.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.playerTank);
            this.Controls.Add(this.healthBar);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Tank Game";
            ((System.ComponentModel.ISupportInitialize)(this.playerTank)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar healthBar;
        private System.Windows.Forms.PictureBox playerTank;
    }
}

