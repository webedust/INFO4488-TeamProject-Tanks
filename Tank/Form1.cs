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
            //Created these objects for testing purposes.
            GameHandler gh = new GameHandler(this);
            Collider collide = new Collider(gh, Collider.Shapes.Rectangle, playerTank.Size, panel1 );
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


            //Movement breaks in the if statement since the player.goLeft is never true.
            //However if the player.goLeft is set to false,
            //the player tank then begins to move across the screen, without user input.
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
            if (player.goDown == true && playerTank.Left < this.ClientSize.Height)
            {
                player.MoveDown();
            }
        }



        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            //The panel back color changing is for testing purposes.
            panel1.BackColor = Color.Black;
            switch (e.KeyCode)
            {
                case Keys.A:
                    panel1.BackColor = Color.Red;

                    player.goLeft = true;
                    player.direction = "left";
                    playerTank.Image = Properties.Resources.PlayerTankLeft;
                    break;

                case Keys.D:
                    panel1.BackColor = Color.Blue;

                    player.goRight = true;
                    player.direction = "left";
                    playerTank.Image= Properties.Resources.PlayerTankRight;
                    break;

                case Keys.W:
                    panel1.BackColor = Color.Yellow;

                    player.goUp = true;
                    player.direction = "left";
                    playerTank.Image = Properties.Resources.PlayerTankUp;
                    break;

                case Keys.S:
                    panel1.BackColor = Color.Green;

                    player.goDown = true;
                    player.direction = "left";
                    playerTank.Image = Properties.Resources.PlayerTankDown;
                    break;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    player.goLeft = false;
                    break;

                case Keys.Right:
                    player.goRight = false;
                    break;

                case Keys.Up:
                    player.goUp = false;
                    break;

                case Keys.Down:
                    player.goDown = false;
                    break;
                case Keys.Space:
                    player.Shoot(player.direction);
                    break;
            }
        }
    }
}
