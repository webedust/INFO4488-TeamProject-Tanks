using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank
{
    /// <summary> Common functions for use in Windows Forms applications. </summary>
    public static class Utils
    {
        public enum CardinalDirections
        {
            North,
            South,
            East,
            West
        }
        /// <summary> Calculates the distance in pixels between two points. </summary>
        /// <param name="a"> Point to start measurement from. </param>
        /// <param name="b"> Point to end measurement at. </param>
        /// <returns> Distance in pixels between two points as an integer. </returns>
        public static int Distance(Point a, Point b)
        {
            int distX = b.X - a.X;
            int distY = b.Y - a.Y;
            /* Multiplying distances by themselves rather than squaring (^2)
             * because squaring is somehow breaking everything. */
            return (int)MathF.Sqrt(distX * distX + distY * distY);
        }
        /// <summary>
        /// Moves closer to a destination point,
        /// but only as close as provided by the maxDistance parameter.
        /// </summary>
        /// <param name="current"> Point to start measurement from. </param>
        /// <param name="destination"> Point to end measurement at. </param>
        /// <param name="maxDistance"> Maximum distance that can be moved. </param>
        /// <returns> New point closer to point the destination. </returns>
        public static Point MoveToward(Point current, Point destination, int maxDistance)
        {
            // Get distances between points and total distance
            int distX = destination.X - current.X;
            int distY = destination.Y - current.Y;
            int distance = Distance(current, destination);

            // Output
            int xPos = current.X + distX / distance * maxDistance;
            int yPos = current.Y + distY / distance * maxDistance;
            return new(xPos, yPos);
        }
    }
}
