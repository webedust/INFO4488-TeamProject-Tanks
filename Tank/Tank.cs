using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank
{
    internal class Tank
    {
        // To-do: Merge this with Kaiden's Tank object. Add code here to it.
        #region References
        // To-do: GH will need to be added to constructor
        GameHandler gh;
        PictureBox pictureBox;
        public PictureBox PictureBox
        {
            /// <summary> PictureBox being used to render this Tank. </summary>
            get { return pictureBox; }
        }
        #endregion


        /// <summary> Attempts to move towards the specified position. </summary>
        /// <param name="a"> Current position. </param>
        /// <param name="b"> Position to move towards. </param>
        /// <returns> True if successfully moved. False if there's an obstacle in the way. </returns>
        public bool TryMove(Point a, Point b)
        {
            // Convert point. May not be needed so commented out
            // uncomment if movement and collision testing seems odd.
            //a = PictureBox.PointToClient(a);

            foreach (Collider col in gh.Colliders)
            {
                // Ignore any distant colliders to save memory usage
                if (// To-do: Write a utils function for distance here)

                // To-do: Collision testing will go here
            }

            // Set new position if no colliders are in the way
            PictureBox.Location = b;
            return true;
        }
    }
}
