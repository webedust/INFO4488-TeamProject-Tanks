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
        public enum Directions
        {
            Up,
            Down,
            Left,
            Right
        }
        //Change speed back after testing
        public int speed = 10;
        public int playerHealth;
        public int enemyHealth;
        public int fireRate;
        public int projectileDamage;

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
        #region Events
        /// <summary> Called at the end of a tank dying/being destroyed. </summary>
        public event EventHandler OnDeath;
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

        #region Depreciated movement code
        //Add label for tank coordinates to help debug why tank won't move down
        //when on the right side of the screen.
        public void MoveLeft()
        {
            direction = "left";
            pictureBox.Image = Properties.Resources.PlayerTankLeft;

            if (pictureBox.Left > 0)
                pictureBox.Left -= speed;
        }

        public void MoveRight()
        {
            direction = "right";
            pictureBox.Image = Properties.Resources.PlayerTankRight;

            if (pictureBox.Right > 0)
            {
                // Modifying from left because it's the only public property
                pictureBox.Left += speed;
            }
        }

        public void MoveUp()
        {
            direction = "up";
            pictureBox.Image = Properties.Resources.PlayerTankUp;

            if (pictureBox.Top > 0)
            {
                pictureBox.Top -= speed;
            }
        }

        public void MoveDown()
        {
            direction = "down";
            pictureBox.Image = Properties.Resources.PlayerTankDown;

            if (pictureBox.Bottom > 0)
            {
                // Modifying from top because it's the only public property
                pictureBox.Top += speed;
            }
        }
        #endregion

        /// <summary>
        /// Allows for the tank to shoot a projectile depending on the direction.
        /// </summary>
        /// <param name="direction"> Direction the tank is facing. </param>
        /// <param name="form">The game screen. </param>
        public void Shoot(String direction, Form form)
        {
            Bullet bullet = new Bullet();
            bullet.bulletDirection = direction;

            //Set bullet to fire from tank 
            bullet.leftFrame = pictureBox.Left + (pictureBox.Width / 2);
            bullet.topFrame = pictureBox.Top + (pictureBox.Height / 2);
            bullet.CreateBullet(form);

            
            
        }
        /// <summary>
        /// When a tank is hit cause it to take damage
        /// </summary>
        /// <param name="projectileDamage"> How much damage a tank will take. </param>
        public void TakeDamage(int projectileDamage)
        {
            //Add logic to determine which entity got hit
            playerHealth -= projectileDamage;

            enemyHealth -= projectileDamage;
        }
        /// <summary>
        /// Player died and game will need to be reset.
        /// </summary>
        public void PlayerDeath()
        {
            if (playerHealth <= 0)
            {

                //Display game over 
            }
        }
        /// <summary>
        /// Enemy died and will need to be removed from the form.
        /// </summary>
        public void EnemyDeath()
        {
            if (enemyHealth <= 0)
            {

                //Remove dead enemy from the map
                // TODO: Rest of Death code
                OnDeath?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary> Player moves the tank in the specified direction. </summary>
        public void PlayerMove(Directions dir)
        {
            Point moveTo = pictureBox.Location;
            switch (dir)
            {
                case Directions.Up:
                    direction = "up";
                    pictureBox.Image = Properties.Resources.PlayerTankUp;
                    if (pictureBox.Top > 0)
                        moveTo.Y -= (int)speed;
                    break;
                case Directions.Down:
                    direction = "down";
                    pictureBox.Image = Properties.Resources.PlayerTankDown;
                    if (pictureBox.Bottom > 0)
                        moveTo.Y += (int)speed;
                    break;
                case Directions.Left:
                    direction = "left";
                    pictureBox.Image = Properties.Resources.PlayerTankLeft;
                    if (pictureBox.Left > 0)
                        moveTo.X -= (int)speed;
                    break;
                case Directions.Right:
                    direction = "right";
                    pictureBox.Image = Properties.Resources.PlayerTankRight;
                    if (pictureBox.Right > 0)
                        moveTo.X += (int)speed;
                    break;
            }
            TryMove(moveTo);
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
