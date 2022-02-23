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
    public partial class Form1 : Form
    {
        Tank player;
        public Form1()
        {
            InitializeComponent();
            GameHandler gh = new GameHandler(this);
            Collider collide = new Collider(gh, Collider.Shapes.Rectangle, playerTank.Size, panel1);
            player = new Tank(collide, gh, playerTank);
            
        }


        private void GameTimer_Tick(object sender, EventArgs e)
        {

            if (player.playerHealth > 1)
            {
                healthBar.Value = (int)player.playerHealth;
            }
            //Need to add gameover logic here
            else
            {
                player.gameOver = true;
            }


           
            if (player.goLeft == true && playerTank.Left > 0)
            {
                player.MoveLeft();
            }
            if (player.goRight == true && playerTank.Left < this.ClientSize.Width)
            {
                player.MoveRight();
            }
            if (player.goUp == true && playerTank.Top > 0)
            {
                player.MoveUp();
            }
            if (player.goDown == true && playerTank.Top < this.ClientSize.Height)
            {
                player.MoveDown();
            }

        }



        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:

                    player.goLeft = true;
                    player.direction = "left";
                    playerTank.Image = Properties.Resources.PlayerTankLeft;
                    break;

                case Keys.D:

                    player.goRight = true;
                    player.direction = "right";
                    playerTank.Image = Properties.Resources.PlayerTankRight;
                    break;

                case Keys.W:

                    player.goUp = true;
                    player.direction = "up";
                    playerTank.Image = Properties.Resources.PlayerTankUp;
                    break;

                case Keys.S:

                    player.goDown = true;
                    player.direction = "down";
                    playerTank.Image = Properties.Resources.PlayerTankDown;
                    break;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
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
                    player.Shoot(player.direction, this);
                    break;
            }
        }
    }
}
