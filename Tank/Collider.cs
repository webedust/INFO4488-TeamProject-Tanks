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
        #endregion
        #region Events
        /// <summary>
        /// Called whenever the collider object detects a collision with another collider.
        /// </summary>
        public event EventHandler OnCollide;
        #endregion


        #region Initial
        /// <summary> Creates a new collider object with the specified shape. </summary>
        /// <param name="gh"> GameHandler object. </param>
        /// <param name="ctrl"> Windows Form control to use for this collider's world space coordinates. </param>
        internal Collider(GameHandler gh, Control ctrl)
        {
            gh.Colliders.Add(this);
            Control = ctrl;
        }
        #endregion
    }
}
