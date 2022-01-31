using System;
using System.Collections.Generic;
using System.Linq;
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
        List<Collider> cols;
        /// <summary> All colliders currently present in the map. </summary>
        public List<Collider> Colliders
        {
            get { return cols; }
            private set { cols = value; }
        }
        Timer timer;
        #endregion
        #region Events
        /// <summary> Called each time a GameHandler interval occurs. </summary>
        public event EventHandler OnIntervalTick;
        #endregion


        #region Initial
        /// <summary> Initializes the GameHandler object. </summary>
        void Initialize()
        {
            timer = new();
            timer.Interval = interval;
            timer.Tick += TickGameInterval;
            timer.Start();
        }
        internal GameHandler()
        {
            Initialize();
        }
        #endregion
        #region Instantiation and Destruciton
        void InstantiateRocks()
        {
            // TODO
        }
        void InstantiateTanks()
        {
            // TODO
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
