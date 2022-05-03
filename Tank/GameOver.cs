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
    /// <summary>
    /// <include file='Authors.XML' path='Docs/Author[@name="Team"]/*' />
    /// </summary>
    public partial class GameOver : Form
    {
        #region Attributes
        /// <summary> Determines where to go after the Game Over form is closed. </summary>
        bool closingToMenu;
        #endregion


        public GameOver(GameHandler gh)
        {
            InitializeComponent();
            lblFinalKills.Text = "Total Kills: " + gh.killCount;
            lblFinalLevel.Text = "Level: " + gh.level;
        }
        void btnReturn_Click(object sender, EventArgs e)
        {
            closingToMenu = true;

            MainMenu menu = new();
            menu.Show();

            Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (closingToMenu)
                return;

            else if (e.CloseReason == CloseReason.UserClosing
                || e.CloseReason == CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
        }
    }
}
