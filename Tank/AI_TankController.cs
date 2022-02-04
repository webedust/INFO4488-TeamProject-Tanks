using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank
{
    /// <summary> Handles thinking for the enemy AI tanks. </summary>
    internal class AI_TankController
    {
        #region References
        GameHandler gh;
        Tank tank;
        #endregion


        #region Initial
        /// <summary> Attaches AI thinking to the specified tank. </summary>
        /// <param name="gh"> Overhead game handler. </param>
        /// <param name="tank"> Tank this AI should be controlling. </param>
        internal AI_TankController(GameHandler gh, Tank tank)
        {
            this.gh = gh;
            this.tank = tank;

            // Make an initial decision
            MakeDecision();
            // TODO: When/if AI gets more advanced then add a loop here
            // to call MakeDecision() on a timer so the AI can change their course of action.
        }
        #endregion
        /// <summary> AI makes a decision on how they should act. </summary>
        void MakeDecision()
        {
            // TODO
        }
        /// <summary>
        /// Calculates a distance to move towards between the AI's current position
        /// and the specified point.
        /// </summary>
        /// <param name="pt"> Point to move towards. Generally will be the player's position. </param>
        void MoveToPoint(Point pt)
        {
            Point current = tank.PictureBox.PointToClient(pt);
            // TODO
            Point newPos = ;
            tank.PictureBox.Location = newPos;
        }
    }
}
