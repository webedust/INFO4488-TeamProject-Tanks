using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank
{
    internal class BitmapAnimation
    {
        #region Attributes
        /// <summary>
        /// Index of the bitmap that is currently playing the animation sequence.
        /// </summary>
        int currentIndex;
        int interval = 1000;
        #endregion
        #region References
        /// <summary> Animation sequence of how bitmaps should be displayed. </summary>
        Bitmap[] sequence;
        public Bitmap[] Sequence
        {
            get { return sequence; }
            private set { sequence = value; }
        }
        Form currentForm;
        PictureBox pic;
        Timer timer = new();
        #endregion


        /// <summary>
        /// Constructs a new bitmap animation that plays the specified sequence
        /// at the given interval.
        /// </summary>
        /// <param name="currentForm"> Form to display this animation to. </param>
        internal BitmapAnimation(Bitmap[] sequence, int interval, Form currentForm)
        {
            Sequence = sequence;
            this.interval = interval;
            this.currentForm = currentForm;

            // Set initial image
            SetImageToCurrentIndex();

            timer.Interval = interval;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            currentIndex++;

            // Ensure the index doesn't go beyond the sequence.
            if (currentIndex >= sequence.Length - 1)
            {
                timer.Stop();
                return;
            }

            SetImageToCurrentIndex();
        }
        /// <summary> Sets the Picture Box's image to the bitmap at the current index. </summary>
        void SetImageToCurrentIndex() => pic.Image = sequence[currentIndex];
        /// <summary> Dispose of this bitmap animation object. </summary>
        public void Dispose()
        {
            currentForm.Controls.Remove(pic);
            pic.Dispose();
            timer.Dispose();
        }
    }
}
