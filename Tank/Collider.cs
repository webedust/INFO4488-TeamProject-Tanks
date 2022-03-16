using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank
{
    /// <summary> Allows world objects to have collisions between them. </summary>
    internal class Collider
    {
        #region Attributes
        /// <summary> World position of the collider from the upper-left edge. </summary>
        public Point Location
        {
            get { return ctrl.Location; }
            set { ctrl.Location = value; }
        }
        public Size Size
        {
            get { return ctrl.Size; }
            private set { ctrl.Size = value; }
        }
        #endregion
        #region References
        Control ctrl;
        /// <summary>
        /// Windows form control associated with this collider.
        /// Used to track the collider's world space position.
        /// </summary>
        public Control Control
        {
            get { return ctrl; }
            private set { ctrl = value; }
        }
        GameHandler gh;
        #endregion


        #region Initial
        /// <summary> Creates a new collider object with the specified shape. </summary>
        /// <param name="gh"> GameHandler object. </param>
        /// <param name="ctrl"> Windows Form control to use for this collider's world space coordinates. </param>
        internal Collider(GameHandler gh, Control ctrl)
        {
            this.gh = gh;
            gh.Colliders.Add(this);
            Control = ctrl;
        }
        #endregion
        /// <summary> Attempts to move to the specified position. </summary>
        /// <param name="moveTo"> Position to move towards. </param>
        /// <returns> Null if successfully moved.
        /// If this collider cannot be moved then the blocking collider is returned. </returns>
        public Collider TryMove(Point moveTo)
        {
            // Set if there's a collider where attempting to move.
            Collider obstacleCol = null;
            foreach (Collider col in gh.Colliders)
            {
                // Skip if evaluating against self
                if (col == this)
                    continue;

                // Ignore any distant colliders to save memory usage
                const int distant = 80;
                if (Utils.Distance(Control.Location, col.Location) > distant)
                    continue;

                // Check each edge for collision
                Rectangle movePos = new
                    (
                        moveTo.X,
                        moveTo.Y,
                        Control.Size.Width,
                        Control.Size.Height
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
                    obstacleCol = col;
                    break;
                }
            }

            // Set new position if no obstacles are in the way
            if (obstacleCol == null)
                Control.Location = moveTo;

            return obstacleCol;
        }
        /// <summary> Destroys this collider and all references associated with it. </summary>
        public void Destroy()
        {
            gh.Colliders.Remove(this);
            ctrl.Dispose();
        }
    }
}
