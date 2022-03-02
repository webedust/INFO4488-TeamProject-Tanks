using System.Drawing;
using System.Windows.Forms;

namespace Tank
{
    /// <summary> A rock world object that other tanks can collide with. </summary>
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
        internal Rock(GameHandler gh, PictureBox pic)
        {
            this.gh = gh;

            col = new(gh, pic);
        }
        #endregion
    }
}
