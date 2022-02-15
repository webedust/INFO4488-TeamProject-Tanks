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
        public float speed = 2;
        public float playerHealth;
        public float enemyHealth;
        public float fireRate;
        public float projectileDamage;

        public string direction = "up";
        public bool goLeft = false;
        public bool goRight = false;
        public bool goUp = false;
        public bool goDown = false;
        public bool gameOver;
        #region References
        Collider selfCollider;
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
        /// <param name="selfCollider"> Collider to use for this tank. </param>
        /// <param name="gh"> Reference to the GameHandler running the current form. </param>
        /// <param name="pic"> PictureBox to use for rendering this tank to the form. </param>
        public Tank(Collider selfCollider, GameHandler gh, PictureBox pic)
        {
            this.selfCollider = selfCollider;
            this.gh = gh;
            pictureBox = pic;
        }
        #endregion

        #region Unneccesary Code to be deleted later 
        //Need to add collision detection to movement and figure out how to attach
        //KeyIsDown and KeyIsUp events to the playerTank picturebox on the form

        //private void KeyIsDown(object sender, KeyEventArgs e)
        //{
        //    if(e.KeyCode == Keys.Left)
        //    {
        //        //goLeft = true;
        //        direction = "left";
        //        pictureBox.Image = Properties.Resources.PlayerTankLeft;

        //        if (pictureBox.Left > 0)
        //            pictureBox.Left -= (int)speed;
        //    }

        //    if (e.KeyCode == Keys.Right)
        //    {
        //        //goRight = true;
        //        direction = "right";
        //        pictureBox.Image = Properties.Resources.PlayerTankRight;

        //        if (pictureBox.Right > 0)
        //        {
        //            // Modifying from left because it's the only public property
        //            pictureBox.Left += (int)speed;
        //        }
        //    }

        //    if (e.KeyCode == Keys.Up)
        //    {
        //        //goUp = true;
        //        direction = "up";
        //        pictureBox.Image = Properties.Resources.PlayerTankUp;

        //        if (pictureBox.Top > 0)
        //        {
        //            pictureBox.Top -= (int)speed;
        //        }
        //    }

        //    if (e.KeyCode == Keys.Down)
        //    {
        //        //goDown = true;
        //        direction = "down";
        //        pictureBox.Image = Properties.Resources.PlayerTankDown;

        //        if (pictureBox.Bottom > 0)
        //        {
        //            // Modifying from top because it's the only public property
        //            pictureBox.Top += (int)speed;
        //        }
        //    }
        //}
        #endregion

        public void MoveLeft()
        {
            direction = "left";
            pictureBox.Image = Properties.Resources.PlayerTankLeft;

            if (pictureBox.Left > 0)
                pictureBox.Left -= (int)speed;
        }

        public void MoveRight()
        {
            direction = "right";
            pictureBox.Image = Properties.Resources.PlayerTankRight;

            if (pictureBox.Right > 0)
            {
                // Modifying from left because it's the only public property
                pictureBox.Left += (int)speed;
            }
        }

        public void MoveUp()
        {
            direction = "up";
            pictureBox.Image = Properties.Resources.PlayerTankUp;

            if (pictureBox.Top > 0)
            {
                pictureBox.Top -= (int)speed;
            }
        }

        public void MoveDown()
        {
            direction = "down";
            pictureBox.Image = Properties.Resources.PlayerTankDown;

            if (pictureBox.Bottom > 0)
            {
                // Modifying from top because it's the only public property
                pictureBox.Top += (int)speed;
            }
        }

        public void Shoot(String direction)
        {
            //Add code for firing the projectile 
        }

        public void TakeDamage(float projectileDamage)
        {
            //Add logic to determine which entity got hit
            playerHealth -= projectileDamage;

            enemyHealth -= projectileDamage;
        }

        public void PlayerDeath()
        {
            if(playerHealth <= 0)
            {
               
                //Display game over 
            }
        }

        public void EnemyDeath()
        {
            if(enemyHealth <= 0)
            {
              
                //Remove dead enemy from the map
            }
        }

        
        /// <summary> Attempts to move towards the specified position. </summary>
        /// <param name="moveTo"> Position to move towards. </param>
        /// <returns> True if successfully moved. False if there's an obstacle in the way. </returns>
        public bool TryMove(Point moveTo)
        {
            // Set true if there's a collider where attempting to move.
            bool colliderAtMovePos = false;
            foreach (Collider col in gh.Colliders)
            {
                // Skip if evaluating against self
                if (col == selfCollider)
                    continue;

                // Ignore any distant colliders to save memory usage
                const int distant = 150;
                if (Utils.Distance(pictureBox.Location, col.Pos) > distant)
                    continue;

                // Furthest left/right/up/down the collider extends
                int xMinPos = col.Pos.X - col.Size.Width / 2;
                int xMaxPos = col.Pos.X + col.Size.Width / 2;
                int yMinPos = col.Pos.Y - col.Size.Height / 2;
                int yMaxPos = col.Pos.Y + col.Size.Height / 2;
                // Test for collision against bounds of the collider
                if (moveTo.X >= xMinPos && moveTo.X < xMaxPos
                    || moveTo.Y >= yMinPos && moveTo.Y < yMinPos)
                {
                    colliderAtMovePos = true;
                    break;
                }
            }

            // Set new position if no colliders are in the way
            if (!colliderAtMovePos)
                PictureBox.Location = moveTo;

            return colliderAtMovePos;
        }
    }
}
