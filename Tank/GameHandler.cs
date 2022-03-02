using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tank.Properties;

namespace Tank
{
    /// <summary>
    /// Controls the game's flow
    /// and instantiates objects into the game world as needed.
    /// </summary>
    internal class GameHandler
    {
        #region Attributes
        /// <summary> Amount of time in <b>milliseconds</b> between each interval tick. </summary>
        const int interval = 5000;
        #endregion
        #region References
        Form currentForm;
        /// <summary> Form being used for the game. </summary>
        public Form CurrentForm
        {
            get { return currentForm; }
            set { currentForm = value; }
        }
        List<Collider> cols = new();
        /// <summary> All colliders currently present in the map. </summary>
        public List<Collider> Colliders
        {
            get { return cols; }
            private set { cols = value; }
        }
        Tank player;
        /// <summary> Player object being used. </summary>
        public Tank Player
        {
            get { return player; }
            set { player = value; }
        }
        Timer timer;
        #endregion


        #region Initial
        /// <summary>
        /// Handles all variable setting when the GameHandler is constructed.
        /// </summary>
        void BaseConstruct(Form currentForm)
        {
            this.currentForm = currentForm;
        }
        /// <summary> Initializes the GameHandler object. </summary>
        void Initialize()
        {
            timer = new();
            timer.Interval = interval;
            timer.Tick += AISpawnInterval;
            timer.Start();

            InstantiatePlayer();
            InstantiateRocks();
        }
        /// <summary> Constructs a new GameHandler for the form. </summary>
        /// <param name="currentForm"> The form to start the GameHandler on. </param>
        internal GameHandler(Form currentForm)
        {
            BaseConstruct(currentForm);
            Initialize();
        }
        #endregion
        #region Instantiation and Destruction
        /// <summary>
        /// Instantiates rocks as specified in a Map object.
        /// </summary>
        /// <remarks> Should only be called once at the start to create the map/level/scene. </remarks>
        void InstantiateRocks()
        {
            foreach (Control ctrl in CurrentForm.Controls)
                // Set all panels on the form to rocks
                if (ctrl != null && (string)ctrl.Tag == "Rock")
                {
                    PictureBox pic = (PictureBox)ctrl;
                    Rock rock = new
                        (
                            this,
                            pic
                        );
                }
        }
        /// <summary>
        /// Instantiates the player game logic on the form control named <c>playerTank</c>.
        /// This is case-sensitive.
        /// </summary>
        void InstantiatePlayer()
        {
            foreach (Control ctrl in CurrentForm.Controls)
                if (ctrl != null && ctrl.Name == "playerTank")
                {
                    Collider col = new(this, ctrl);
                    player = new(col, this, (PictureBox)ctrl);
                    return;
                }
        }
        /// <summary>
        /// Maximum amount of tanks that can be onscreen at once
        /// before preventing more from spawning for performance concerns
        /// </summary>
        /// <remarks>
        /// This value is checked at the <b>start</b> of the <c>InstantiateTanks()</c> function.
        /// Later in the function a random number of enemy tanks are spawned,
        /// at which point the total number of enemy tanks may exceed this "cap".
        /// This is not a bug, and therefore this number should be thought of as a softcap only.
        /// </remarks>
        readonly int maxTanksAtOnce = 30;
        /// <summary> Number of alive enemy tanks currently on the screen. </summary>
        int currentTanks;
        /// <summary>
        /// Instantiates <b>enemy</b> tanks as specified in a Map object.
        /// </summary>
        /// <remarks> Should be called on an interval to continually spawn in enemies. </remarks>
        void InstantiateTanks()
        {
            if (currentTanks > maxTanksAtOnce)
                return;

            Random rand = new();
            int tanks = rand.Next(1, 4);
            for (int i = 0; i < tanks; i++)
            {
                PictureBox pic = new();
                pic.Image = Resources.EnemyTankUp;
                pic.Size = new(50, 75);
                // To-do: Change to spawn off-screen, just 0 for testing
                pic.Location = new(0, 0);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                CurrentForm.Controls.Add(pic);

                Collider col = new(this, pic);
                Colliders.Add(col);

                Tank tank = new(col, this, pic);

                AI_TankController ai = new(this, tank);

                currentTanks++;
            }
        }
        /// <summary>
        /// Call whenever an AI-controlled tank has been killed/destroyed
        /// to remove reference to it in the GameHandler.
        /// </summary>
        public void OnAITankDeath()
        {
            currentTanks--;

            if (currentTanks < 0)
                throw new ArithmeticException("Number of current tanks should never be negative.");
        }
        #endregion
        void AISpawnInterval(object sender, EventArgs e)
            => InstantiateTanks();
    }
}
