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
    class Bullet
    {
        #region Attributes
        // To-do: Probably change damage. It's set as 5 for testing purposes.
        public int damage = 5;
        public const int Speed = 3;
        Timer timer;
        #endregion
        #region References
        Collider col;
        public Collider Col { get { return col; } }
        /// <summary> PictureBox in use by this bullet. </summary>
        /// <summary> Direction this bullet is being fired. </summary>
        Utils.CardinalDirections dir;
        #endregion
        #region References
        GameHandler gh;
        PictureBox pic;
        Tank shooter;
        #endregion


        #region Initial
        /// <summary> Creates and fires a bullet from the specified tank. </summary>
        /// <param name="gh"> Overhead game handler for the current form. </param>
        /// <param name="shooter"> Tank this bullet has been fired from. </param>
        public Bullet(GameHandler gh, Tank shooter)
        {
            this.gh = gh;
            this.shooter = shooter;
            dir = shooter.direction;

            pic = new();
            pic.BackColor = Color.Red;
            pic.Size = new(7, 7);

            /* Set location to the shooter's location + an offset
             * to prevent immediate self-collision. */
            Point spawnPos = shooter.Pic.Location;
            // Pixel offset to apply to the bullet on instantiation
            const int offset = 5;
            switch (shooter.direction)
            {
                case Utils.CardinalDirections.North:
                    // X is modified to adjust the bullet to fire from the center
                    spawnPos.X += shooter.Pic.Size.Width / 2;
                    spawnPos.Y -= offset;
                    break;
                case Utils.CardinalDirections.South:
                    spawnPos.X += shooter.Pic.Size.Width / 2;
                    spawnPos.Y += shooter.Pic.Size.Height + offset;
                    break;
                case Utils.CardinalDirections.East:
                    spawnPos.X += shooter.Pic.Size.Width + offset;
                    spawnPos.Y += shooter.Pic.Size.Height / 2;
                    break;
                case Utils.CardinalDirections.West:
                    spawnPos.X -= offset;
                    spawnPos.Y += shooter.Pic.Size.Height / 2;
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
                OnCollision(obstacle);

            // Delete bullet if travels off-screen
            if (pic.Left < 10 || pic.Left > 1200 || pic.Top < 10 || pic.Top > 700)
            {
                Destroy();
            }
        }
        void OnCollision(Collider other)
        {
            // Check if the bullet hit a tank, and make it take damage if so.
            Tank hit = gh.GetTankFromCollider(other);
            if (hit != null)
                hit.TakeDamage(damage);

            Destroy();
        }
        void Destroy()
        {
            timer.Stop();
            timer.Dispose();
            Col.Destroy();
        }
    }
}
