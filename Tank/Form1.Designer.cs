
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
            this.components = new System.ComponentModel.Container();
            this.healthLabel = new System.Windows.Forms.Label();
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.playerTank = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.playerTank)).BeginInit();
            this.SuspendLayout();
            // 
            // healthLabel
            // 
            this.healthLabel.AutoSize = true;
            this.healthLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.healthLabel.Location = new System.Drawing.Point(12, 9);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(61, 21);
            this.healthLabel.TabIndex = 0;
            this.healthLabel.Text = "Health";
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
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(104, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(630, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(57, 83);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(977, 392);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(44, 44);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(208, 148);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(96, 90);
            this.panel4.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(590, 543);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(97, 89);
            this.panel5.TabIndex = 7;
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(29, 113);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(44, 44);
            this.panel6.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.Location = new System.Drawing.Point(960, 138);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(89, 100);
            this.panel7.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.playerTank);
            this.Controls.Add(this.healthBar);
            this.Controls.Add(this.healthLabel);
            this.Controls.Add(this.panel7);
            this.Name = "Form1";
            this.Text = "Tank Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.playerTank)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label healthLabel;
        private System.Windows.Forms.ProgressBar healthBar;
        private System.Windows.Forms.PictureBox playerTank;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
    }
}

