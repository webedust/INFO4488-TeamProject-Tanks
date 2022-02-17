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
            get { return col.Pos; }
            set { col.Pos = value; }
        }
        #endregion
        #region References
        /// <summary> Collider being used by this rock. </summary>
        Collider col;
        GameHandler gh;
        #endregion


        #region Initial
        void DrawElementOnForm()
        {
            Button button = new();
            button.Location = col.Pos;

            gh.CurrentForm.Controls.Add(button);

            // TODO: Remove debug when thoroughly tested.
            // Currently this adds a button to the form where the rock is.
            button.Text = "Rock";
            button.Size = col.Size;
            button.BackColor = Color.BlanchedAlmond;
        }
        internal Rock(GameHandler gh, Panel panel)
        {
            this.gh = gh;

            // Convert panel's square width to a circle radius
            float rad = panel.Width / 2;

            // To-do: Change from panel to PictureBox
            col = new(gh, rad, panel);

            DrawElementOnForm();
        }
        #endregion
    }
}
