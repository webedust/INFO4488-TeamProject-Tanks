using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            ConnectEvents();

            // Make an initial decision
            MakeDecision();

            Timer t = new();
            t.Interval = 100;
            t.Tick += MakeDecisionLoop;
            t.Start();
        }
        #endregion
        #region Event connections
        void ConnectEvents() => tank.OnDeath += Die;
        #endregion
        #region Events
        void MakeDecisionLoop(object sender, EventArgs e)
        {
            MakeDecision();
        }
        /// <summary> AI's tank is destroyed. </summary>
        void Die(object sender, EventArgs e) => gh.OnAITankDeath();
        #endregion
        /// <summary> AI makes a decision on how they should act. </summary>
        void MakeDecision()
        {
            Point current = tank.PictureBox.Location;
            Point playerPos = gh.Player.PictureBox.Location;

            // Don't move if within the stopping distance
            const int stopDistance = 30;
            if (Utils.Distance(current, playerPos) > stopDistance)
                MoveToPoint(playerPos);

            // TODO: Add shooting here when it has been created
        }
        /// <summary>
        /// Calculates a distance to move towards between the AI's current position
        /// and the specified point.
        /// </summary>
        /// <param name="pt"> Final point to move towards. Generally will be the player's position. </param>
        void MoveToPoint(Point pt)
        {
            Point current = tank.PictureBox.Location;

            Point newPos = Utils.MoveToward(current, pt, tank.speed);
            if (!tank.TryMove(newPos))
                MoveAroundObstacle();
        }
        /// <summary>
        /// Call when the AI cannot path without getting stuck on an obstacle.
        /// This attempts to resolve the collision by navigating diagonally
        /// around the obstacle.
        /// </summary>
        void MoveAroundObstacle()
        {
            Point current = tank.PictureBox.Location;

            // Randomly choose a direction to try to move around the obstacle
            Point move = current;
            Random r = new();
            // Ensure this is always equal to the length of the # of cases in the switch
            const int numOfDecisions = 4;
            int decision = r.Next(numOfDecisions);
            // Amount to move in each decision in the x and y directions
            const int xMove = 25;
            const int yMove = 25;
            switch (decision)
            {
                case 0: // Try to move diagonally up and right
                    move.X += xMove;
                    move.Y += yMove;
                    break;
                case 1: // Try to move diagonally up and left
                    move.X -= xMove;
                    move.Y += yMove;
                    break;
                case 2: // Try to move diagonally down and right
                    move.X += xMove;
                    move.Y -= yMove;
                    break;
                case 3: // Try to move diagonally down and left
                    move.X -= xMove;
                    move.Y -= yMove;
                    break;
            }

            Point newPos = Utils.MoveToward(current, move, tank.speed);
            // Re-run if failed to resolve collision
            if (!tank.TryMove(newPos))
                MoveAroundObstacle();
            // Otherwise return to normal decision making.
            else
                MakeDecision();
        }
    }
}
