using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        #region Attributes
        const int MovementInterval = 25;
        #endregion
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
            t.Interval = MovementInterval;
            t.Tick += MakeDecisionLoop;
            t.Start();
        }
        #endregion
        #region Event connections
        void ConnectEvents() => tank.OnDeath += Die;
        #endregion
        #region Events
        void MakeDecisionLoop(object sender, EventArgs e) => MakeDecision();
        /// <summary> AI's tank is destroyed. </summary>
        void Die(object sender, EventArgs e) => gh.OnAITankDeath();
        #endregion
        /// <summary> AI makes a decision on how they should act. </summary>
        void MakeDecision()
        {
            Point current = tank.PictureBox.Location;
            Point playerPos = gh.Player.PictureBox.Location;

            // Don't move if within the stopping distance
            const int StopDistance = 60;
            if (Utils.Distance(current, playerPos) > StopDistance)
                MoveToPoint(playerPos);

            // TODO: Add shooting here when it has been created
        }
        /// <summary>
        /// Calculates a distance to move towards between the AI's current position
        /// and the specified point.
        /// </summary>
        /// <param name="destination"> 
        /// Desired end point to move towards.
        /// Generally will be the player's position. 
        /// </param>
        void MoveToPoint(Point destination)
        {
            Point current = tank.PictureBox.Location;
            Point nextPos = Utils.MoveToward(current, destination, tank.speed);
            // Movement is blocked, therefore try obstacle resolution
            if (!tank.TryMove(nextPos))
                MoveAroundObstacle();
        }
        /// <summary>
        /// Attempts to prevent AI-obstacle collisions by navigating diagonally
        /// around the obstacle.
        /// </summary>
        void MoveAroundObstacle()
        {
            // To-do: Remove the return later. Using to debug other parts
            return;

            Debug.WriteLine("Attempting move around obstacle");
            Point current = tank.PictureBox.Location;

            // Randomly choose a direction to try to move around the obstacle
            Point destination = current;
            Random r = new();
            // Ensure this is always equal to the length of the # of cases in the switch
            const int NumOfDecisions = 4;
            int decision = r.Next(NumOfDecisions);
            // Amount to move in each decision in the x and y directions
            const int xMove = 25;
            const int yMove = 25;
            switch (decision)
            {
                case 0: // Try to move diagonally up and right
                    destination.X += xMove;
                    destination.Y += yMove;
                    break;
                case 1: // Try to move diagonally up and left
                    destination.X -= xMove;
                    destination.Y += yMove;
                    break;
                case 2: // Try to move diagonally down and right
                    destination.X += xMove;
                    destination.Y -= yMove;
                    break;
                case 3: // Try to move diagonally down and left
                    destination.X -= xMove;
                    destination.Y -= yMove;
                    break;
            }

            Point nextPos = Utils.MoveToward(current, destination, tank.speed);
            // Re-run if failed to resolve collision
            if (!tank.TryMove(nextPos))
                MoveAroundObstacle();
            // Otherwise return to normal decision making.
            else
                MakeDecision();
        }
    }
}
