using System;
using System.Collections.Generic;
using System.Drawing;
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
        #region References
        GameHandler gh;
        PictureBox pictureBox;
        public PictureBox PictureBox
        {
            /// <summary> PictureBox being used to render this Tank. </summary>
            get { return pictureBox; }
        }
        #endregion


        #region Initial
        /// <summary> Creates a new tank. </summary>
        /// <param name="gh"> Reference to the GameHandler running the current form. </param>
        /// <param name="pic"> PictureBox to use for rendering this tank to the form. </param>
        public Tank(GameHandler gh, PictureBox pic)
        {
            this.gh = gh;
            pictureBox = pic;
        }
        #endregion
        //Need to add collision detection to movement and figure out how to attach
        //KeyIsDown and KeyIsUp events to the playerTank picturebox on the form

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                //goLeft = true;
                direction = "left";
                pictureBox.Image = Properties.Resources.PlayerTankLeft;

                if (pictureBox.Left > 0)
                    pictureBox.Left -= (int)speed;
            }

            if (e.KeyCode == Keys.Right)
            {
                //goRight = true;
                direction = "right";
                pictureBox.Image = Properties.Resources.PlayerTankRight;

                if (pictureBox.Right > 0)
                {
                    // Modifying from left because it's the only public property
                    pictureBox.Left += (int)speed;
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                //goUp = true;
                direction = "up";
                pictureBox.Image = Properties.Resources.PlayerTankUp;

                if (pictureBox.Top > 0)
                {
                    pictureBox.Top -= (int)speed;
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                //goDown = true;
                direction = "down";
                pictureBox.Image = Properties.Resources.PlayerTankDown;

                if (pictureBox.Bottom > 0)
                {
                    // Modifying from top because it's the only public property
                    pictureBox.Top += (int)speed;
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
        /// <summary> Attempts to move towards the specified position. </summary>
        /// <param name="a"> Current position. </param>
        /// <param name="b"> Position to move towards. </param>
        /// <returns> True if successfully moved. False if there's an obstacle in the way. </returns>
        public bool TryMove(Point a, Point b)
        {
            // Convert point. May not be needed so commented out
            // uncomment if movement and collision testing seems odd.
            //a = PictureBox.PointToClient(a);

            foreach (Collider col in gh.Colliders)
            {
                // Ignore any distant colliders to save memory usage
                if (// To-do: Write a utils function for distance here)

                // To-do: Collision testing will go here
            }

            // Set new position if no colliders are in the way
            PictureBox.Location = b;
            return true;
        }
    }
}
