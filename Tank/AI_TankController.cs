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
    public class AI_TankController
    {
        #region Attributes
        bool navigatingAroundObstacle;
        const int MakeDecisionInterval = 25;
        #endregion
        #region References
        GameHandler gh;
        Tank tank;
        /// <summary> Tank object this AI is controlling. </summary>
        public Tank SelfTank { get { return tank; } }
        #endregion
        #region References
        Point destination;
        Timer makeDecisionTimer = new();
        /// <summary>
        /// Timer before tank returns to normal navigation from obstacle resolution.
        /// </summary>
        Timer obstacleNavigationTimer = new();
        #endregion


        #region Initial
        /// <summary> Attaches AI thinking to the specified tank. </summary>
        /// <param name="gh"> Overhead game handler. </param>
        /// <param name="tank"> Tank this AI should be controlling. </param>
        internal AI_TankController(GameHandler gh, Tank tank)
        {
            this.gh = gh;
            this.tank = tank;

            // Make an initial decision and set initial target to the player
            destination = gh.Player.Col.Location;
            MakeDecision();

            obstacleNavigationTimer.Interval = 1000;

            makeDecisionTimer.Interval = MakeDecisionInterval;
            makeDecisionTimer.Tick += MakeDecisionLoop;
            makeDecisionTimer.Start();

            ConnectEvents();
        }
        #endregion
        #region Event connections
        void ConnectEvents()
        {
            obstacleNavigationTimer.Tick += ObstacleNavigationTimer_Tick;
            tank.OnDeath += Die;
        }
        #endregion
        #region Events
        /// <summary> AI's tank is destroyed. </summary>
        void Die(object sender, EventArgs e)
        {
            makeDecisionTimer.Stop();
            makeDecisionTimer.Dispose();

            obstacleNavigationTimer.Stop();
            obstacleNavigationTimer.Dispose();

            gh.OnAITankDeath(this);
        }
        void MakeDecisionLoop(object sender, EventArgs e) => MakeDecision();
        /// <summary>
        /// Called when the obstacle navigation timer has a tick, which,
        /// in this use case, indicates that the timer has finished.
        /// Therefore, normal navigation should resume.
        /// </summary>
        void ObstacleNavigationTimer_Tick(object sender, EventArgs e)
        {
            navigatingAroundObstacle = false;
            obstacleNavigationTimer.Stop();
        }
        #endregion
        /// <summary> AI makes a decision on how they should act. </summary>
        void MakeDecision()
        {
            Point current = tank.Pic.Location;
            Point playerPos = gh.Player.Pic.Location;

            // Override standard behavior when navigating around obstacles
            if (navigatingAroundObstacle)
            {
                MoveToPoint();
                return;
            }

            // Don't move if within the stopping distance
            const int StopDistance = 100;
            int distance = Utils.Distance(current, playerPos);
            if (distance > StopDistance)
            {
                destination = playerPos;
                MoveToPoint();
            }
            // Distance before the tank will shoot
            const int ShootDistance = 300;
            if (Utils.Distance(current, playerPos) < ShootDistance)
            {
                SelfTank.direction = Utils.DirectionFromPoint
                    (
                        current,
                        playerPos
                    );
                SelfTank.TurnToDirection();
                SelfTank.Shoot();
            }
        }
        /// <summary>
        /// Calculates a distance to move towards between the AI's current position
        /// and the specified point.
        /// </summary>
        void MoveToPoint()
        {
            Point current = tank.Pic.Location;
            Point nextPos = Utils.MoveToward(current, destination, tank.speed);
            // Movement is blocked, therefore try obstacle resolution
            if (tank.Col.TryMove(nextPos) != null)
                StartObstacleResolution();
        }
        void StartObstacleResolution()
        {
            if (navigatingAroundObstacle)
                return;

            navigatingAroundObstacle = true;
            obstacleNavigationTimer.Start();

            // Randomly choose a direction to try to move around the obstacle
            Point moveTo = tank.Pic.Location;
            Random r = new();
            int decision = r.Next((int)Enum.GetValues(typeof(Utils.CardinalDirections)).Cast<Utils.CardinalDirections>().Max());
            // Convert randomized integer back to the enum
            Utils.CardinalDirections dir = (Utils.CardinalDirections)decision;
            const int moveAmt = 200;
            switch (dir)
            {
                case Utils.CardinalDirections.North:
                    moveTo.Y += moveAmt;
                    break;
                case Utils.CardinalDirections.South:
                    moveTo.Y -= moveAmt;
                    break;
                case Utils.CardinalDirections.East:
                    moveTo.X += moveAmt;
                    break;
                case Utils.CardinalDirections.West:
                    moveTo.X -= moveAmt;
                    break;
            }
            destination = moveTo;
        }
    }
}
