using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank
{
    /// <summary> Common functions for use in Windows Forms applications. </summary>
    public static class Utils
    {
        /// <summary> Calculates the distance in pixels between two points. </summary>
        /// <param name="a"> Point to start measurement from. </param>
        /// <param name="b"> Point to end measurement at. </param>
        /// <returns> Distance between two points as an integer amount of pixels. </returns>
        public static int Distance(Point a, Point b)
        {
            return (int)MathF.Sqrt((b.X - a.X)^2 + (b.Y - a.Y)^2);
        }
        /// <summary>
        /// Moves point a closer to point b,
        /// but only as close as provided by the maxDistance parameter.
        /// </summary>
        /// <param name="a"> Point to start measurement from. </param>
        /// <param name="b"> Point to end measurement at. </param>
        /// <param name="maxDistance"> Maximum distance that can be moved. </param>
        /// <returns> New point closer to point b. </returns>
        public static Point MoveToward(Point a, Point b, int maxDistance)
        {
            // Get total distance between the two points
            int distX = b.X - a.X;
            int distY = b.Y - a.Y;
            int distTotal = Distance(a, b);

            // Output
            int xPos = (a.X + distX / distTotal * maxDistance);
            int yPos = (a.Y + distY / distTotal * maxDistance);
            return new(xPos, yPos);
        }
    }
}
