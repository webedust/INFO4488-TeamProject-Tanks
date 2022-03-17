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
    public partial class Form1 : Form
    {
        Tank player;
        public Form1()
        {
            InitializeComponent();
            // Must be true for user input to work.
            KeyPreview = true;

            GameHandler gh = new(this);
            player = gh.Player;
        }
        void GameTimer_Tick(object sender, EventArgs e)
        {

            if (player.playerHealth > 1)
            {
                healthBar.Value = player.playerHealth;
            }
            else
            {
                player.gameOver = true;
                this.Close();
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

            //label1.Text = "X: " + playerTank.Left + " Y: " + playerTank.Top;
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
                    player.Shoot(this);
                    break;
            }
        }

        /// <summary>
        /// When the X is clicked on the form, open the main menu.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                return;
            }

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
