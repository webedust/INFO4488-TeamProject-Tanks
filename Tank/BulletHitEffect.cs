using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank
{
    /// <summary> Visual effect to show when a bullet hits a collider. </summary>
    public class BulletHitEffect
    {
        #region References
        readonly Bitmap[] AnimSequence =
        {
            Properties.Resources.BulletHitEffect1,
            Properties.Resources.BulletHitEffect2,
            Properties.Resources.BulletHitEffect3
        };
        #endregion


        /// <remarks>
        /// Assumes that this hit effect is being instantiated when a bullet
        /// actually hits an object and therefore needs this effect to play out.
        /// </remarks>
        /// <param name="pos"> Position to instantiate this bullet hit effect. </param>
        public BulletHitEffect(Point pos, GameHandler gh)
        {
            _ = new BitmapAnimation(AnimSequence, 100, gh.CurrentForm, pos);
        }
    }
}
