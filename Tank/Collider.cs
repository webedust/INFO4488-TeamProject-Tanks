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
        /// <summary> Shapes a collider can take. </summary>
        public enum Shapes
        {
            Rectangle,
            Circle
        }
        #region Attributes
        /// <summary> World position of the collider from the upper-left edge. </summary>
        public Point Pos
        {
            get { return panel.Location; }
            set { panel.Location = value; }
        }
        Shapes shape = Shapes.Rectangle;
        /// <summary> The shape of this collider. </summary>
        /// <remarks> After being created a collider's shape should never change. </remarks>
        public Shapes Shape
        {
            get { return shape; }
        }
        Size size;
        /// <summary> Size of the collider. </summary>
        /// <remarks>
        /// If using a circle collider then the 
        /// x and y will represent the radius and will always be equal.
        /// </remarks>
        public Size Size
        {
            get { return size; }
            private set { size = value; }
        }
        #endregion
        #region References
        GameHandler gh;
        /// <summary>
        /// Invisible panel associated with this collider.
        /// Used to track the collider's world space position.
        /// </summary>
        Panel panel;
        #endregion
        #region Events
        /// <summary>
        /// Called whenever the collider object detects a collision with another collider.
        /// </summary>
        public event EventHandler OnCollide;
        #endregion


        #region Initial
        /// <summary>
        /// Base function all other constructors should call
        /// at the start of their respective functions.
        /// </summary>
        /// <param name="gh"> GameHandler object. </param>
        /// <param name="shape"> Shape the collider should take. </param>
        /// <param name="size"> How large the collider should be in pixels. </param>
        /// <param name="panel"> Windows Form panel to use for this collider's world space coordinates. </param>
        void BaseConstruct(GameHandler gh, Shapes shape, Size size, Panel panel)
        {
            this.gh = gh;
            this.shape = shape;
            this.size = size;
            this.panel = panel;

            ConnectGameHandler();
        }
        /// <summary> Creates a new collider object with the specified shape. </summary>
        /// <param name="gh"> GameHandler object. </param>
        /// <param name="shape"> Shape the collider should take. </param>
        /// <param name="size"> How large the collider should be in pixels. </param>
        /// <param name="panel"> Windows Form panel to use for this collider's world space coordinates. </param>
        internal Collider(GameHandler gh, Shapes shape, Size size, Panel panel)
            => BaseConstruct(gh, shape, size, panel);
        /// <summary> Creates a circlular collider object. </summary>
        /// <param name="gh"> GameHandler object. </param>
        /// <param name="radius"> Radius (size) of the circle collider. </param>
        /// <param name="panel"> Windows Form panel to use for this collider's world space coordinates. </param>
        internal Collider(GameHandler gh, float radius, Panel panel)
        {
            // Convert float to a vector to pass as a valid parameter
            int irad = (int)radius;
            Size vSize = new(irad, irad);
            BaseConstruct(gh, Shapes.Circle, vSize, panel);
        }
        #endregion
        #region Event connections
        void ConnectGameHandler() => gh.OnIntervalTick += CheckForCollisions;
        #endregion
        #region Events
        void CheckForCollisions(object sender, EventArgs e)
        {
            foreach (Collider col in gh.Colliders)
            {
                // TODO: Optimize on distance
                if (col == this)
                    return;

                // TODO: Put calculations for the collider's coordinates here
                // when they're added.
            }
        }
        #endregion
    }
}
