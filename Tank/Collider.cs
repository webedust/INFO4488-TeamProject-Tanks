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
        readonly GameHandler gh;
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
            Collider obstacleCol = IsColliderAtPoint(moveTo);

            // Set new position if no obstacles are in the way
            if (obstacleCol == null)
                Control.Location = moveTo;

            return obstacleCol;
        }
        /// <summary> Moves to the specified position even if another collider is there. </summary>
        /// <param name="moveTo"> Position to move towards. </param>
        public void ForceMove(Point moveTo) => Control.Location = moveTo;
        /// <summary>
        /// Iterates through all colliders currently present on the form
        /// and checks if any are intersecting with this collider
        /// if it were to be moved to the specified point.
        /// </summary>
        /// <param name="pt"> Point to check for colliders existing. </param>
        /// <returns>
        /// Null if no collider is at the point,
        /// otherwise the collider occupying that space is returned. 
        /// </returns>
        public Collider IsColliderAtPoint(Point pt)
        {
            // Set if there's a collider where attempting to move.
            Collider obstacleCol = null;
            foreach (Collider col in gh.Colliders)
            {
                // Skip if evaluating against self
                if (col == this)
                    continue;

                // Ignore any distant colliders to save memory usage
                const int distant = 125;
                if (Utils.Distance(pt, col.Location) > distant)
                    continue;

                // Check each edge for collision
                Rectangle movePos = new
                    (
                        pt.X,
                        pt.Y,
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
                if (colRect.IntersectsWith(movePos) 
                    || colRect.Contains(movePos)
                    || movePos.Contains(colRect))
                {
                    obstacleCol = col;
                    break;
                }
            }

            return obstacleCol;
        }
        /// <summary> Destroys this collider and all references associated with it. </summary>
        public void Destroy()
        {
            gh.Colliders.Remove(this);
            Control.Dispose();
        }
    }
}
