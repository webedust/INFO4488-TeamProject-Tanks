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
        public int speed = 2;
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


        #region
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
        public void Shoot(String direction, Form form)
        {
            Bullet bullet = new Bullet();
            bullet.bulletDirection = direction;
            bullet.CreateBullet(form);

            bullet.leftFrame = pictureBox.Left;
            bullet.topFrame = pictureBox.Top;
            //Set bullet to fire from tank and delete bullet if it collides
            //with something or if it travels off the screen
        }

        public void TakeDamage(int projectileDamage)
        {
            //Add logic to determine which entity got hit
            playerHealth -= projectileDamage;

            enemyHealth -= projectileDamage;
        }

        public void PlayerDeath()
        {
            if (playerHealth <= 0)
            {

                //Display game over 
            }
        }

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

                Control potentialCollider =
                    gh.CurrentForm.GetChildAtPoint(moveTo);
                if (potentialCollider != null && (string)potentialCollider.Tag == "Rock")
                {
                    colliderAtMovePos = true;
                    Debug.WriteLine("Collider at move position");
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
