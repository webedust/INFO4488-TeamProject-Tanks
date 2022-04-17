using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            btnCreditsReturn.Click += ReturnEvent;
            btnInstructionReturn.Click += ReturnEvent;
        }


        private void btnStartGame_Click(object sender, EventArgs e)
        {
            Form1 frm  = new Form1();
            frm.Show();
            this.Hide();
        }

        private void btnExitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Swaps panel focus to the instruction panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInstructions_Click(object sender, EventArgs e)
        {
            instructionsPanel.Visible = true;
            menuPanel.Visible = false;
        }

        /// <summary>
        /// Swaps panel focus to the credits panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCredits_Click(object sender, EventArgs e)
        {
            creditsPanel.Visible = true;
            menuPanel.Visible=false;
        }
        /// <summary>
        /// Swaps panel focus back to the main menu panel 
        /// when on one of the other two panels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnEvent(object sender, EventArgs e)
        {
            instructionsPanel.Visible = false;
            creditsPanel.Visible = false;
            menuPanel.Visible = true;
        }
        /// <summary>
        /// When the X is clicked on the form, open the main menu. 
        /// Used code from https://stackoverflow.com/questions/1669318/override-standard-close-x-button-in-a-windows-form
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                return;
            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}
