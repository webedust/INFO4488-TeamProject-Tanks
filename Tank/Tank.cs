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
        #region Attributes
        public int speed = 10;
        public int playerHealth = 100;
        public int enemyHealth;
        public int fireRate;
        public int projectileDamage;

        public Utils.CardinalDirections direction = Utils.CardinalDirections.North;
        public bool goLeft = false;
        public bool goRight = false;
        public bool goUp = false;
        public bool goDown = false;
        public bool gameOver;
        #endregion
        #region References
        Collider col;
        public Collider Col { get { return col; } }
        GameHandler gh;
        PictureBox pictureBox;
        /// <summary> PictureBox being used to render this Tank. </summary>
        public PictureBox Pic { get { return pictureBox; } }
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
            this.col = selfCollider;
            this.gh = gh;
            pictureBox = pic;
        }
        #endregion
        /// <summary> Player moves the tank in the specified direction. </summary>

        public void PlayerMove(Utils.CardinalDirections dir)
        {
            direction = dir;
            Point moveTo = pictureBox.Location;
            switch (direction)
            {
                case Utils.CardinalDirections.North:
                    pictureBox.Image = Properties.Resources.PlayerTankUp;
                    if (pictureBox.Top > 0)
                        moveTo.Y -= speed;
                    break;
                case Utils.CardinalDirections.South:
                    pictureBox.Image = Properties.Resources.PlayerTankDown;
                    if (pictureBox.Bottom > 0)
                        moveTo.Y += speed;
                    break;
                case Utils.CardinalDirections.West:
                    pictureBox.Image = Properties.Resources.PlayerTankLeft;
                    if (pictureBox.Left > 0)
                        moveTo.X -= speed;
                    break;
                case Utils.CardinalDirections.East:
                    pictureBox.Image = Properties.Resources.PlayerTankRight;
                    if (pictureBox.Right > 0)
                        moveTo.X += speed;
                    break;
            }
            col.TryMove(moveTo);
        }
        /// <summary>
        /// Allows for the tank to shoot a projectile depending on the direction.
        /// </summary>
        /// <param name="form">The game screen. </param>
        public void Shoot(Form form)
        {
            Bullet bullet = new(gh, this);
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
    }
}
