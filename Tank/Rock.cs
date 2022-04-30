using System.Drawing;
using System.Windows.Forms;

namespace Tank
{
    /// <summary> 
    /// <include file='Authors.XML' path='Docs/Author[@name="Dustin"]/*' />
    /// A rock world object that other tanks can collide with. 
    /// </summary>
    internal class Rock
    {
        #region Attributes
        Color color;
        /// <summary> Color of the rock. </summary>
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        public Point Pos 
        { 
            get { return col.Location; }
            set { col.Location = value; }
        }
        #endregion
        #region References
        Collider col;
        /// <summary> Collider being used by this rock. </summary>
        public Collider Collider
        { get { return col; } }
        GameHandler gh;
        #endregion


        #region Initial
        /// <summary>
        /// <include file='Authors.XML' path='Docs/Author[@name="Dustin"]/*' />
        /// Constructs a basic rock with an associated collider.
        /// </summary>
        /// <param name="gh"> GameHandler creating this rock. </param>
        /// <param name="pic"> PictureBox being used to display this rock to the UI. </param>
        internal Rock(GameHandler gh, PictureBox pic)
        {
            this.gh = gh;

            col = new(gh, pic);
        }
        #endregion
    }
}
