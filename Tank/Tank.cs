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
    /// <summary>
    /// <include file='Authors.XML' path='Docs/Author[@name="Team"]/*' />
    /// A tank vehicle with movement and shooting capabilities.
    /// </summary>
    public class Tank
    {
        /// <summary> Factions a tank can belong to. </summary>
        public enum Faction
        {
            Player = 0,
            Enemy = 1
        }
        #region Attributes
        bool noCollide;
        public bool NoCollide 
        { 
            get { return noCollide; } 
            private set 
            { 
                noCollide = value;
                if (!noCollide)
                    ForceMovesPerformed = 0;
            } 
        }
        int health;
        public int Health 
        {
            get { return health; }
            private set { health = value; }
        }
        public int speed = 5;
        int successiveFailedMoves;
        /// <summary>
        /// Number of TryMoves attempted in a row that have failed.
        /// Resets every time TryMove succeeds.
        /// </summary>
        public int SuccessiveFailedMoves
        {
            get { return successiveFailedMoves; }
            private set { successiveFailedMoves = value; }
        }
        int forceMovesPerformed;
        /// <summary>
        /// Number of ForceMoves performed by the tank when NoCollide is enabled.
        /// Resets when NoCollide is disabled.
        /// </summary>
        public int ForceMovesPerformed
        {
            get { return forceMovesPerformed; }
            private set { forceMovesPerformed = value; }
        }
        const int PlayerHealth = 100;
        const int EnemyHealth = 50;

        public Utils.CardinalDirections direction = Utils.CardinalDirections.North;
        public bool goLeft = false;
        public bool goRight = false;
        public bool goUp = false;
        public bool goDown = false;
        public bool gameOver;

        public const int PlayerFireRate = 450;
        public const int AIFireRate = 1200;
        bool canShoot = true;
        Size originalSize;
        Timer rofTimer = new();
        #endregion
        #region References
        Collider col;
        public Collider Col { get { return col; } }
        Faction faction;
        /// <summary> Faction this tank belongs to. </summary>
        public Faction SelfFaction { get { return faction; } }
        Image[] tankSprites = EnemyTankSprites;
        /// <summary> Sprites that this tank should use. </summary>
        public Image[] TankSprites 
        {
            set { tankSprites = value; }
            get { return tankSprites; } 
        }
        GameHandler gh;
        PictureBox pictureBox;
        /// <summary> PictureBox being used to render this Tank. </summary>
        public PictureBox Pic { get { return pictureBox; } }
        public static readonly Image[] PlayerTankSprites =
        {
            Properties.Resources.PlayerTankUp,
            Properties.Resources.PlayerTankDown,
            Properties.Resources.PlayerTankRight,
            Properties.Resources.PlayerTankLeft
        };
        public static readonly Image[] EnemyTankSprites =
        {
            Properties.Resources.EnemyTankUp,
            Properties.Resources.EnemyTankDown,
            Properties.Resources.EnemyTankRight,
            Properties.Resources.EnemyTankLeft
        };
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
        /// <param name="faction"> Faction this tank should belong to. </param>
        /// <param name="firerate">Minimum amount of milliseconds that must elapse between successive shots before the tank can fire again.</param>
        public Tank(Collider selfCollider, GameHandler gh, PictureBox pic, Faction faction, int fireRate)
        {
            col = selfCollider;
            this.gh = gh;
            pictureBox = pic;
            originalSize = pic.Size;
            this.faction = faction;

            // Determine starting health based on faction
            switch (SelfFaction)
            {
                case Faction.Player:
                    health = PlayerHealth;
                    break;
                case Faction.Enemy:
                    health = EnemyHealth;
                    break;
            }

            rofTimer.Interval = fireRate;
            rofTimer.Tick += GunCooldown;
        }
        #endregion
        /// <summary> 
        /// <include file='Authors.XML' path='Docs/Author[@name="Team"]/*' />
        /// Player moves the tank in the specified direction. 
        /// </summary>
        public void PlayerMove(Utils.CardinalDirections dir)
        {
            direction = dir;
            Point moveTo = pictureBox.Location;
            switch (direction)
            {
                case Utils.CardinalDirections.North:
                    if (pictureBox.Top > 0)
                        moveTo.Y -= speed;
                    break;
                case Utils.CardinalDirections.South:
                    if (pictureBox.Bottom > 0)
                        moveTo.Y += speed;
                    break;
                case Utils.CardinalDirections.West:
                    if (pictureBox.Left > 0)
                        moveTo.X -= speed;
                    break;
                case Utils.CardinalDirections.East:
                    if (pictureBox.Right > 0)
                        moveTo.X += speed;
                    break;
            }
            Move(moveTo);
        }
        /// <summary>
        /// <include file='Authors.XML' path='Docs/Author[@name="Dustin"]/*' />
        /// Turns the tank the current direction it should be facing
        /// by switching width and height.
        /// </summary>
        public void TurnToDirection()
        {
            if (direction == Utils.CardinalDirections.North
                || direction == Utils.CardinalDirections.South)
                Pic.Size = originalSize;
            else
            {
                Size flippedSize = new(originalSize.Height, originalSize.Width);
                Pic.Size = flippedSize;
            }
            // Change image
            int iDir = (int)direction;
            switch (direction)
            {
                case Utils.CardinalDirections.North:
                    pictureBox.Image = TankSprites[iDir];
                    break;
                case Utils.CardinalDirections.South:
                    pictureBox.Image = TankSprites[iDir];
                    break;
                case Utils.CardinalDirections.West:
                    pictureBox.Image = TankSprites[iDir];
                    break;
                case Utils.CardinalDirections.East:
                    pictureBox.Image = TankSprites[iDir];
                    break;
            }
        }
        /// <summary>
        /// <include file='Authors.XML' path='Docs/Author[@name="Team"]/*' />
        /// Moves the tank object to the specified location.
        /// </summary>
        /// <param name="loc"> Location to move the tank to. </param>
        void Move(Point loc)
        {
            Collider colAtPos = null;
            if (NoCollide)
            { 
                col.ForceMove(loc);
                ForceMovesPerformed++;
                /* Disable NoCollide when set amount of ForceMoves are conducted.
                 * Assumes the tank will have gotten unstuck by then. */
                if (ForceMovesPerformed >= 7)
                    NoCollide = false;
            }
            else
                colAtPos = col.TryMove(loc);

            // Only turn the tank if moving succeeded to prevent getting stuck in rocks
            if (colAtPos == null)
            {
                SuccessiveFailedMoves = 0;
                TurnToDirection();
            }
            else
            {
                SuccessiveFailedMoves++;

                // Test if stuck when failing to move numerous times
                if (SuccessiveFailedMoves > 5)
                {
                    // If the tank is stuck then allow ForceMove to escape
                    NoCollide = Col.IsStuck(speed);
                }
            }
        }
        /// <summary>
        /// <include file='Authors.XML' path='Docs/Author[@name="Team"]/*' />
        /// Allows for the tank to shoot a projectile depending on the direction.
        /// </summary>
        public void Shoot()
        {
            if (!canShoot)
                return;

            canShoot = false;
            rofTimer.Start();

            Bullet bullet = new(gh, this, SelfFaction);
        }
        /// <summary>
        /// <include file='Authors.XML' path='Docs/Author[@name="Dustin"]/*' />
        /// Cooldown timer event before the tank can be fired again. 
        /// </summary>
        void GunCooldown(object sender, EventArgs e)
        {
            canShoot = true;
            rofTimer.Stop();
        }
        /// <summary>
        /// <include file='Authors.XML' path='Docs/Author[@name="Kaiden"]/*' />
        /// When a tank is hit cause it to take damage
        /// </summary>
        /// <param name="damage"> How much damage a tank will take. </param>
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
                Death();
        }
        /// <summary>
        /// <include file='Authors.XML' path='Docs/Author[@name="Team"]/*' />
        /// Tank is destroyed or killed.
        /// Disposes of all associated components and removes the tank from the form.
        /// </summary>
        void Death()
        {
            rofTimer.Stop();
            rofTimer.Dispose();

            Col.Enabled = false;
            Col.Destroy();
            OnDeath?.Invoke(this, EventArgs.Empty);
        }
    }
}
