using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tank
{
    /// <summary>
    /// <include file='Authors.XML' path='Docs/Author[@name="Dustin"]/*' />
    /// Plays a sequence of bitmaps at a specified interval to make an animation.
    /// </summary>
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
        /// <summary> Animation sequence of how images should be displayed. </summary>
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
        #region Events
        public event EventHandler OnFinish;
        #endregion


        /// <summary>
        /// <include file='Authors.XML' path='Docs/Author[@name="Dustin"]/*' />
        /// Constructs a new bitmap animation that plays the specified sequence
        /// at the given interval.
        /// </summary>
        /// <param name="sequence"> Bitmap sequence to play as an animation. </param>
        /// <param name="interval"> Milliseconds to show each bitmap before moving to the next one. </param>
        /// <param name="currentForm"> Form to display this animation to. </param>
        /// <param name="pos"> Location to set this Bitmap Animation at on the current form.</param>
        internal BitmapAnimation(Bitmap[] sequence, int interval, Form currentForm, Point pos)
        {
            Sequence = sequence;
            this.interval = interval;
            this.currentForm = currentForm;

            pic = new();
            pic.BackColor = Color.Transparent;
            pic.Location = pos;
            pic.Size = new(sequence[0].Width, sequence[0].Height);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            currentForm.Controls.Add(pic);

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
            if (currentIndex >= sequence.Length)
            {
                timer.Stop();
                OnFinish?.Invoke(this, EventArgs.Empty);
                Dispose();
                return;
            }

            SetImageToCurrentIndex();
        }
        /// <summary> 
        /// <include file='Authors.XML' path='Docs/Author[@name="Dustin"]/*' />
        /// Sets the Picture Box's image to the bitmap at the current index. 
        /// </summary>
        void SetImageToCurrentIndex() => pic.Image = sequence[currentIndex];
        /// <summary> 
        /// <include file='Authors.XML' path='Docs/Author[@name="Dustin"]/*' />
        /// Dispose of this bitmap animation object. 
        /// </summary>
        public void Dispose()
        {
            currentForm.Controls.Remove(pic);
            pic.Dispose();
            timer.Dispose();
        }
    }
}
