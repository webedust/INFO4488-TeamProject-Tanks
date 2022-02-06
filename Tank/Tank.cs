using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank
{
    class Tank
    {
        public float speed;
        public float playerHealth;
        public float enemyHealth;
        public float fireRate;
        public float projectileDamage;

        public string direction = "up";
        //public bool goLeft;
        //public bool goRight;
        //public bool goUp;
        //public bool goDown;
        public bool gameOver;


        //Need to add collision detection to movement and figure out how to attach
        //KeyIsDown and KeyIsUp events to the playerTank picturebox on the form

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                //goLeft = true;
                direction = "left";
                playerTank.Image = Properties.Resources.PlayerTankLeft;

                
                if(playerTank.Left > 0)
                {
                    playerTank.Left -= speed;
                }
            }

            if (e.KeyCode == Keys.Right)
            {
                //goRight = true;
                direction = "right";
                playerTank.Image = Properties.Resources.PlayerTankRight;

                if (playerTank.Right > 0)
                {
                    playerTank.Right += speed;
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                //goUp = true;
                direction = "up";
                playerTank.Image = Properties.Resources.PlayerTankUp;

                if (playerTank.Up > 0)
                {
                    playerTank.Up -= speed;
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                //goDown = true;
                direction = "down";
                playerTank.Image = Properties.Resources.PlayerTankDown;

                if (playerTank.Down > 0)
                {
                    playerTank.Down += speed;
                }
            }
        }


        public void takeDamage(float projectileDamage)
        {
            //Add logic to determine which entity got hit
            playerHealth -= projectileDamage;

            enemyHealth -= projectileDamage;
        }

        private void playerDeath()
        {
            if(playerHealth <= 0)
            {
               
                //Display game over 
            }
        }

        private void enemyDeath()
        {
            if(enemyHealth <= 0)
            {
              
                //Remove dead enemy from the map
            }
        }

        private void shoot()
        {
            //Add code for firing the projectile 
        }
    }
}
