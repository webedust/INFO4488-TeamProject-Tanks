namespace Tank
{
    partial class GameOver
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
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblGameOver = new System.Windows.Forms.Label();
            this.lblFinalKills = new System.Windows.Forms.Label();
            this.lblFinalLevel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReturn.Location = new System.Drawing.Point(107, 300);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(120, 30);
            this.btnReturn.TabIndex = 0;
            this.btnReturn.Text = "Back to Main Menu";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGameOver.Location = new System.Drawing.Point(83, 30);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(168, 37);
            this.lblGameOver.TabIndex = 1;
            this.lblGameOver.Text = "Game Over!";
            // 
            // lblFinalKills
            // 
            this.lblFinalKills.AutoSize = true;
            this.lblFinalKills.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFinalKills.Location = new System.Drawing.Point(12, 191);
            this.lblFinalKills.Name = "lblFinalKills";
            this.lblFinalKills.Size = new System.Drawing.Size(120, 30);
            this.lblFinalKills.TabIndex = 2;
            this.lblFinalKills.Text = "Total Kills: ";
            // 
            // lblFinalLevel
            // 
            this.lblFinalLevel.AutoSize = true;
            this.lblFinalLevel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFinalLevel.Location = new System.Drawing.Point(12, 113);
            this.lblFinalLevel.Name = "lblFinalLevel";
            this.lblFinalLevel.Size = new System.Drawing.Size(75, 30);
            this.lblFinalLevel.TabIndex = 3;
            this.lblFinalLevel.Text = "Level: ";
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(51)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(334, 361);
            this.Controls.Add(this.lblFinalLevel);
            this.Controls.Add(this.lblFinalKills);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.btnReturn);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "GameOver";
            this.Text = "Game Over";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Label lblFinalKills;
        private System.Windows.Forms.Label lblFinalLevel;
    }
}