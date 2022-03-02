using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank
{
    class Tank
    {
        /// <summary> All directions that the player can move the tank. </summary>
        public enum Directions
        {
            Up,
            Down,
            Left,
            Right
        }
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
                        moveTo.Y -= speed;
                    break;
                case Directions.Down:
                    direction = "down";
                    pictureBox.Image = Properties.Resources.PlayerTankDown;
                    if (pictureBox.Bottom > 0)
                        moveTo.Y += speed;
                    break;
                case Directions.Left:
                    direction = "left";
                    pictureBox.Image = Properties.Resources.PlayerTankLeft;
                    if (pictureBox.Left > 0)
                        moveTo.X -= speed;
                    break;
                case Directions.Right:
                    direction = "right";
                    pictureBox.Image = Properties.Resources.PlayerTankRight;
                    if (pictureBox.Right > 0)
                        moveTo.X += speed;
                    break;
            }
            TryMove(moveTo);
        }
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

        /// <summary> Attempts to move towards the specified position. </summary>
        /// <param name="moveTo"> Position to move towards. </param>
        /// <returns> True if successfully moved. False if there's an obstacle in the way. </returns>
        public bool TryMove(Point moveTo)
        {
            // Set true if there's a collider where attempting to move.
            bool colAtMovePos = false;
            foreach (Collider col in gh.Colliders)
            {
                // Skip if evaluating against self
                if (col == selfCollider)
                    continue;

                // Ignore any distant colliders to save memory usage
                const int distant = 80;
                if (Utils.Distance(pictureBox.Location, col.Location) > distant)
                    continue;

                // Check each edge for collision
                Rectangle movePos = new
                    (
                        moveTo.X,
                        moveTo.Y,
                        PictureBox.Size.Width,
                        PictureBox.Size.Height
                    );
                Rectangle colRect = new
                    (
                        col.Location.X,
                        col.Location.Y,
                        col.Size.Width,
                        col.Size.Height
                    );
                if (colRect.IntersectsWith(movePos))
                {
                    colAtMovePos = true;
                    break;
                }
            }

            // Set new position if no obstacles are in the way
            if (!colAtMovePos)
                PictureBox.Location = moveTo;

            return colAtMovePos;
        }
    }
}
