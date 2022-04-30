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
    /// <summary> 
    /// <include file='Authors.XML' path='Docs/Author[@name="Dustin"]/*' />
    /// Allows world objects to have collisions between them. 
    /// </summary>
    public class Collider
    {
        #region Attributes
        bool enabled = true;
        /// <summary> Toggles collisions with this collider. </summary>
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
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
        /// <summary> 
        /// <include file='Authors.XML' path='Docs/Author[@name="Dustin"]/*' />
        /// Creates a new collider object with the specified shape. 
        /// </summary>
        /// <param name="gh"> GameHandler object. </param>
        /// <param name="ctrl"> Windows Form control to use for this collider's world space coordinates. </param>
        internal Collider(GameHandler gh, Control ctrl)
        {
            this.gh = gh;
            gh.Colliders.Add(this);
            Control = ctrl;
        }
        #endregion
        /// <summary>
        /// <include file='Authors.XML' path='Docs/Author[@name="Dustin"]/*' />
        /// Checks whether this collider can move in any cardinal direction
        /// to determine if it is stuck.
        /// </summary>
        /// <param name="moveBy">
        /// Maximum pixel distance to test each possible movement direction.
        /// In most cases this will be the speed the collider can be moved at.
        /// </param>
        /// <returns> True if the collider can't move in any cardinal direction. </returns>
        public bool IsStuck(int moveBy)
        {
            Point[] movePts =
            {
                new(Location.X, Location.Y + moveBy), // North
                new(Location.X, Location.Y - moveBy), // South
                new(Location.X + moveBy, Location.Y), // East
                new(Location.X - moveBy, Location.Y) // West
            };
            Collider north = TryMove(movePts[0]);
            Collider south = TryMove(movePts[1]);
            Collider east = TryMove(movePts[2]);
            Collider west = TryMove(movePts[3]);

            return north != null && south != null && east != null && west != null;
        }
        /// <summary> 
        /// <include file='Authors.XML' path='Docs/Author[@name="Dustin"]/*' />
        /// Attempts to move to the specified position. 
        /// </summary>
        /// <param name="moveTo"> Position to move towards. </param>
        /// <returns>
        /// The collider at the point that is being attempted to be moved to,
        /// or null if no colliders are blocking the move point.
        /// </returns>
        public Collider TryMove(Point moveTo)
        {
            Collider obstacleCol = IsColliderAtPoint(moveTo);

            // Set new position if no obstacles are in the way
            if (obstacleCol == null)
                Control.Location = moveTo;

            return obstacleCol;
        }
        /// <summary> 
        /// <include file='Authors.XML' path='Docs/Author[@name="Dustin"]/*' />
        /// Moves to the specified position even if another collider is there. 
        /// </summary>
        /// <param name="moveTo"> Position to move towards. </param>
        public void ForceMove(Point moveTo) => Control.Location = moveTo;
        /// <summary>
        /// <include file='Authors.XML' path='Docs/Author[@name="Dustin"]/*' />
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
                // Skip disabled colliders
                if (!col.Enabled)
                    continue;

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
        /// <summary> 
        /// <include file='Authors.XML' path='Docs/Author[@name="Dustin"]/*' />
        /// Destroys this collider and all references associated with it. 
        /// </summary>
        public void Destroy()
        {
            gh.Colliders.Remove(this);
            gh.CurrentForm.Controls.Remove(Control);
            Control.Dispose();
        }
    }
}
