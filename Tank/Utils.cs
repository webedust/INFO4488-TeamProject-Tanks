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

            // Set maximums
            // Divide maximum by 2 as it will be split between the x and y
            int splitMax = maxDistance / 2;
            // If x or y is negative then use negative instead
            int negSplitMax = -splitMax;
            if (distX < 0 && distX < negSplitMax)
                distX = negSplitMax;
            if (distY < 0 && distY < negSplitMax)
                distY = negSplitMax;
            // Positive
            if (distX > splitMax)
                distX = splitMax;
            if (distY > splitMax)
                distY = splitMax;

            // Calculate new position to move to
            int xPos = current.X + distX;
            int yPos = current.Y + distY;
            return new(xPos, yPos);
        }
        /// <summary>
        /// Determines the direction to make the starting point face the end point.
        /// </summary>
        /// <param name="start"> Starting point of the calculation. </param>
        /// <param name="end"> End point to calculate the direction to. </param>
        /// <returns> Cardinal direction the point should face. </returns>
        /// <remarks>
        /// In the event that the start and end points are diagonal from each other,
        /// then the x or y coordinate that is a greater distance will take precedence for
        /// the direction that is returned.
        /// </remarks>
        public static CardinalDirections DirectionFromPoint(Point start, Point end)
        {
            int xDiff = end.X - start.X;
            int yDiff = end.Y - start.Y;
            int xDiffAbs = Math.Abs(xDiff);
            int yDiffAbs = Math.Abs(yDiff);
            // < 0 means the direction must be North
            if (yDiff < 0)
            {
                /* Determine whether to return North or East/West.
                 * If East/West needs to be returned then it's calculated later. */
                if (yDiffAbs > xDiffAbs)
                    return CardinalDirections.North;
            }
            else
            {
                if (yDiffAbs > xDiffAbs)
                    return CardinalDirections.South;
            }
            // Determine whether East/West should be returned.
            // > 0 means direction must be East as it's positive
            if (xDiff > 0)
                return CardinalDirections.East;
            else
                return CardinalDirections.West;
        }
    }
}
