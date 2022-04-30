using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tank
{
    /// <summary>
    /// <include file='Authors.XML' path='Docs/Author[@name="Team"]/*' />
    /// Bullet to be fired from tanks.
    /// </summary>
    public class Bullet
    {
        #region Attributes
        const int Damage = 25;
        public const int Speed = 3;
        Timer timer;
        #endregion
        #region References
        Collider col;
        public Collider Col { get { return col; } }
        /// <summary> Direction this bullet is being fired. </summary>
        Utils.CardinalDirections dir;
        #endregion
        #region References
        GameHandler gh;
        PictureBox pic;
        Tank.Faction faction;
        #endregion


        #region Initial
        /// <summary> 
        /// <include file='Authors.XML' path='Docs/Author[@name="Team"]/*' />
        /// Creates and fires a bullet from the specified tank.
        /// </summary>
        /// <param name="gh"> Overhead game handler for the current form. </param>
        /// <param name="origin"> Tank this bullet has been fired from. </param>
        /// <param name="faction"> Faction of the tank firing this bullet. </param>
        public Bullet(GameHandler gh, Tank origin, Tank.Faction faction)
        {
            this.gh = gh;
            gh.Bullets.Add(this);
            this.faction = faction;
            dir = origin.direction;

            pic = new();
            pic.BackColor = Color.Red;
            pic.Size = new(7, 7);

            /* Set location to the shooter's location + an offset
             * to prevent immediate self-collision. */
            Point spawnPos = origin.Pic.Location;
            // Pixel offset to apply to the bullet on instantiation
            const int offset = 5;
            switch (origin.direction)
            {
                case Utils.CardinalDirections.North:
                    // X is modified to adjust the bullet to fire from the center
                    spawnPos.X += origin.Pic.Size.Width / 2;
                    spawnPos.Y -= offset;
                    break;
                case Utils.CardinalDirections.South:
                    spawnPos.X += origin.Pic.Size.Width / 2;
                    spawnPos.Y += origin.Pic.Size.Height + offset;
                    break;
                case Utils.CardinalDirections.East:
                    spawnPos.X += origin.Pic.Size.Width + offset;
                    spawnPos.Y += origin.Pic.Size.Height / 2;
                    break;
                case Utils.CardinalDirections.West:
                    spawnPos.X -= offset;
                    spawnPos.Y += origin.Pic.Size.Height / 2;
                    break;
            }
            pic.Location = spawnPos;

            gh.CurrentForm.Controls.Add(pic);

            col = new(gh, pic);

            //Create timer event for bullet to travel across screen
            timer = new();
            timer.Interval = Speed;
            timer.Tick += new EventHandler(BulletTravelEvent);
            timer.Start();
        }
        #endregion
        public void BulletTravelEvent(object sender, EventArgs e)
        {
            Point moveTo = pic.Location;
            switch (dir)
            {
                case Utils.CardinalDirections.North:
                    moveTo.Y -= Speed;
                    break;
                case Utils.CardinalDirections.South:
                    moveTo.Y += Speed;
                    break;
                case Utils.CardinalDirections.East:
                    moveTo.X += Speed;
                    break;
                case Utils.CardinalDirections.West:
                    moveTo.X -= Speed;
                    break;
            }

            // Test for collision
            Collider obstacle = Col.TryMove(moveTo);
            if (obstacle != null)
            {
                // If colliding with another bullet then fly through it
                if (gh.GetBulletFromCollider(obstacle) != null)
                    Col.ForceMove(moveTo);
                else
                    OnCollision(obstacle);
                return;
            }

            // Delete bullet if travels off-screen
            if (pic.Left < 10 || pic.Left > 1200 || pic.Top < 10 || pic.Top > 700)
                Destroy();
        }
        void OnCollision(Collider other)
        {
            // Check if the bullet hit a tank, and make it take damage if so.
            Tank hit = gh.GetTankFromCollider(other);
            // Check if player
            if (hit == null && other == gh.Player.Col)
                hit = gh.Player;

            // Ignore friendly fire
            if (hit != null && hit.SelfFaction != faction)
                hit.TakeDamage(Damage);

            // Create the hit effect at the center of this bullet's hit location
            Bitmap hitEffectBmp = BulletHitEffect.AnimSequence[0];
            int xOffset = hitEffectBmp.Width / 2;
            int yOffset = hitEffectBmp.Height / 2;
            Point effectPos = new(pic.Location.X - xOffset, pic.Location.Y - yOffset);
            _ = new BulletHitEffect(effectPos, gh);

            Destroy();
        }
        void Destroy()
        {
            timer.Stop();
            timer.Dispose();

            gh.Bullets.Remove(this);

            Col.Destroy();
        }
    }
}
