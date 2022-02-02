using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        const int interval = 100;
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
        List<Rock> rocks = new();
        /// <summary> All rocks in the map. </summary>
        public List<Rock> Rocks
        {
            get { return rocks; }
            private set { rocks = value; }
        }
        Timer timer;
        #endregion
        #region Events
        /// <summary> Called each time a GameHandler interval occurs. </summary>
        public event EventHandler OnIntervalTick;
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
            timer.Tick += TickGameInterval;
            timer.Start();

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
            foreach (Control control in CurrentForm.Controls)
                // Set all panels on the form to rocks
                if (control != null && control.GetType() == typeof(Panel))
                {
                    Panel panel = (Panel)control;
                    Rock rock = new
                        (
                            this,
                            panel
                        );
                    Rocks.Add(rock);
                    Debug.WriteLine($"Rock added at {rock.Pos}");
                }
        }
        /// <summary>
        /// Instantiates <b>enemy</b> tanks as specified in a Map object.
        /// </summary>
        /// <remarks> Should be called on an interval to continually spawn in enemies. </remarks>
        void InstantiateTanks()
        {
            // TODO: Do this after tanks have been implemented
        }
        /// <summary>
        /// Destroys any rocks that are still present in the scene/level.
        /// </summary>
        void DestroyRocks()
        {
            // TODO
        }
        #endregion
        void TickGameInterval(object sender, EventArgs e)
        {
            OnIntervalTick?.Invoke(this, EventArgs.Empty);
        }
    }
}
