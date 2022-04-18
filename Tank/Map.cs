using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank
{
    public partial class Map : Form
    {
        #region References
        Tank player;
        GameHandler gh;
        #endregion


        public Map()
        {
            InitializeComponent();
            gh = new(this);
            player = gh.Player;
            
        }
        void GameTimer_Tick(object sender, EventArgs e)
        {
            lblKills.Text = "Kills: " + gh.killCount;
            lblLevel.Text = "Level: " + gh.level;

            if (player.Health > 1)
            {
                healthBar.Value = player.Health;
            }
            else
            {
                GameTimer.Stop();
                GameTimer.Dispose();
                player.gameOver = true;
                Close();
                GameOver gameOver = new GameOver();
                gameOver.Show();
            }
            //Used for testing the game over logic
            //player.playerHealth -= 1;

            if (player.goLeft == true)
            {
                //When tank goes off the screen on the left, move it to the right side of the screen.
                if (playerTank.Left <= 0)
                {
                    playerTank.Left = 1200;
                }
                player.PlayerMove(Utils.CardinalDirections.West);
            }

            if (player.goRight == true)
            {
                //When tank goes off the screen on the right, move it to the left side of the screen.
                if (playerTank.Left >= 1200)
                {
                    playerTank.Left = 0;
                }
                player.PlayerMove(Utils.CardinalDirections.East);
            }

            if (player.goUp == true)
            {
                //When tank goes off the screen on the top, move it to the bottom side of the screen.
                if (playerTank.Top <= 0)
                {
                    playerTank.Top = 700;
                }
                player.PlayerMove(Utils.CardinalDirections.North);
            }

            if (player.goDown == true)
            {
                //When tank goes off the screen on the bottom, move it to the top side of the screen.
                if (playerTank.Top >= 700)
                {
                    playerTank.Top = 0;
                }
                player.PlayerMove(Utils.CardinalDirections.South);
            }

        }
        void KeyIsDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:

                    player.goLeft = true;
                    playerTank.Image = Properties.Resources.PlayerTankLeft;
                    break;

                case Keys.D:

                    player.goRight = true;
                    playerTank.Image = Properties.Resources.PlayerTankRight;
                    break;

                case Keys.W:

                    player.goUp = true;
                    playerTank.Image = Properties.Resources.PlayerTankUp;
                    break;

                case Keys.S:

                    player.goDown = true;
                    playerTank.Image = Properties.Resources.PlayerTankDown;
                    break;
            }
        }
        void KeyIsUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    player.goLeft = false;
                    break;

                case Keys.D:
                    player.goRight = false;
                    break;

                case Keys.W:
                    player.goUp = false;
                    break;

                case Keys.S:
                    player.goDown = false;
                    break;
                case Keys.Space:
                    player.Shoot();
                    break;
            }
        }

       

        /// <summary>
        /// When the X is clicked on the form, open the main menu. 
        /// Used code from https://stackoverflow.com/questions/1669318/override-standard-close-x-button-in-a-windows-form
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (player.gameOver
                || e.CloseReason == CloseReason.WindowsShutDown)
                return;

            //Test this to see if it works
            if (e.CloseReason == CloseReason.UserClosing)
            {
                switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        MainMenu mainMenu = new MainMenu();
                        mainMenu.Show();
                        break;
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                }
            }
        }

    }
}
