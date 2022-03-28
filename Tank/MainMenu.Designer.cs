namespace Tank
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.menuPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCredits = new System.Windows.Forms.Button();
            this.btnInstructions = new System.Windows.Forms.Button();
            this.btnExitGame = new System.Windows.Forms.Button();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.instructionsPanel = new System.Windows.Forms.Panel();
            this.txtControlDesc = new System.Windows.Forms.TextBox();
            this.btnInstructionReturn = new System.Windows.Forms.Button();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.creditsPanel = new System.Windows.Forms.Panel();
            this.txtCreditsDesc = new System.Windows.Forms.TextBox();
            this.btnCreditsReturn = new System.Windows.Forms.Button();
            this.lblCredits = new System.Windows.Forms.Label();
            this.menuPanel.SuspendLayout();
            this.instructionsPanel.SuspendLayout();
            this.creditsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.lblTitle);
            this.menuPanel.Controls.Add(this.btnCredits);
            this.menuPanel.Controls.Add(this.btnInstructions);
            this.menuPanel.Controls.Add(this.btnExitGame);
            this.menuPanel.Controls.Add(this.btnStartGame);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(359, 411);
            this.menuPanel.TabIndex = 5;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(100, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(158, 37);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Tank Game";
            // 
            // btnCredits
            // 
            this.btnCredits.Location = new System.Drawing.Point(129, 286);
            this.btnCredits.Name = "btnCredits";
            this.btnCredits.Size = new System.Drawing.Size(100, 30);
            this.btnCredits.TabIndex = 9;
            this.btnCredits.Text = "Credits";
            this.btnCredits.UseVisualStyleBackColor = true;
            this.btnCredits.Click += new System.EventHandler(this.btnCredits_Click);
            // 
            // btnInstructions
            // 
            this.btnInstructions.Location = new System.Drawing.Point(129, 250);
            this.btnInstructions.Name = "btnInstructions";
            this.btnInstructions.Size = new System.Drawing.Size(100, 30);
            this.btnInstructions.TabIndex = 8;
            this.btnInstructions.Text = "Instructions";
            this.btnInstructions.UseVisualStyleBackColor = true;
            this.btnInstructions.Click += new System.EventHandler(this.btnInstructions_Click);
            // 
            // btnExitGame
            // 
            this.btnExitGame.Location = new System.Drawing.Point(129, 322);
            this.btnExitGame.Name = "btnExitGame";
            this.btnExitGame.Size = new System.Drawing.Size(100, 30);
            this.btnExitGame.TabIndex = 7;
            this.btnExitGame.Text = "Exit Game";
            this.btnExitGame.UseVisualStyleBackColor = true;
            this.btnExitGame.Click += new System.EventHandler(this.btnExitGame_Click);
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(129, 214);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(100, 30);
            this.btnStartGame.TabIndex = 6;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // instructionsPanel
            // 
            this.instructionsPanel.Controls.Add(this.txtControlDesc);
            this.instructionsPanel.Controls.Add(this.btnInstructionReturn);
            this.instructionsPanel.Controls.Add(this.lblInstructions);
            this.instructionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instructionsPanel.Location = new System.Drawing.Point(0, 0);
            this.instructionsPanel.Name = "instructionsPanel";
            this.instructionsPanel.Size = new System.Drawing.Size(359, 411);
            this.instructionsPanel.TabIndex = 10;
            this.instructionsPanel.Visible = false;
            // 
            // txtControlDesc
            // 
            this.txtControlDesc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtControlDesc.Location = new System.Drawing.Point(60, 114);
            this.txtControlDesc.Multiline = true;
            this.txtControlDesc.Name = "txtControlDesc";
            this.txtControlDesc.ReadOnly = true;
            this.txtControlDesc.Size = new System.Drawing.Size(238, 202);
            this.txtControlDesc.TabIndex = 12;
            this.txtControlDesc.Text = resources.GetString("txtControlDesc.Text");
            // 
            // btnInstructionReturn
            // 
            this.btnInstructionReturn.Location = new System.Drawing.Point(118, 322);
            this.btnInstructionReturn.Name = "btnInstructionReturn";
            this.btnInstructionReturn.Size = new System.Drawing.Size(123, 30);
            this.btnInstructionReturn.TabIndex = 11;
            this.btnInstructionReturn.Text = "Back to Main Menu";
            this.btnInstructionReturn.UseVisualStyleBackColor = true;
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblInstructions.Location = new System.Drawing.Point(95, 18);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(169, 37);
            this.lblInstructions.TabIndex = 10;
            this.lblInstructions.Text = "Instructions";
            // 
            // creditsPanel
            // 
            this.creditsPanel.Controls.Add(this.txtCreditsDesc);
            this.creditsPanel.Controls.Add(this.btnCreditsReturn);
            this.creditsPanel.Controls.Add(this.lblCredits);
            this.creditsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.creditsPanel.Location = new System.Drawing.Point(0, 0);
            this.creditsPanel.Name = "creditsPanel";
            this.creditsPanel.Size = new System.Drawing.Size(359, 411);
            this.creditsPanel.TabIndex = 13;
            this.creditsPanel.Visible = false;
            // 
            // txtCreditsDesc
            // 
            this.txtCreditsDesc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCreditsDesc.Location = new System.Drawing.Point(60, 114);
            this.txtCreditsDesc.Multiline = true;
            this.txtCreditsDesc.Name = "txtCreditsDesc";
            this.txtCreditsDesc.ReadOnly = true;
            this.txtCreditsDesc.Size = new System.Drawing.Size(238, 202);
            this.txtCreditsDesc.TabIndex = 12;
            this.txtCreditsDesc.Text = "Need to add credits";
            // 
            // btnCreditsReturn
            // 
            this.btnCreditsReturn.Location = new System.Drawing.Point(118, 322);
            this.btnCreditsReturn.Name = "btnCreditsReturn";
            this.btnCreditsReturn.Size = new System.Drawing.Size(123, 30);
            this.btnCreditsReturn.TabIndex = 11;
            this.btnCreditsReturn.Text = "Back to Main Menu";
            this.btnCreditsReturn.UseVisualStyleBackColor = true;
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCredits.Location = new System.Drawing.Point(125, 18);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(108, 37);
            this.lblCredits.TabIndex = 10;
            this.lblCredits.Text = "Credits";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 411);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.creditsPanel);
            this.Controls.Add(this.instructionsPanel);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.instructionsPanel.ResumeLayout(false);
            this.instructionsPanel.PerformLayout();
            this.creditsPanel.ResumeLayout(false);
            this.creditsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCredits;
        private System.Windows.Forms.Button btnInstructions;
        private System.Windows.Forms.Button btnExitGame;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Panel instructionsPanel;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnInstructionReturn;
        private System.Windows.Forms.TextBox txtControlDesc;
        private System.Windows.Forms.Panel creditsPanel;
        private System.Windows.Forms.TextBox txtCreditsDesc;
        private System.Windows.Forms.Button btnCreditsReturn;
        private System.Windows.Forms.Label lblCredits;
    }
}