using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank
{
    class Bullet
    {

        public int damage;
        public int bulletSpeed = 3;
        Collider bulletCollider;
        private PictureBox bullet = new PictureBox();
        public int leftFrame;
        public int topFrame;
        private Timer timer = new Timer();
        public string bulletDirection;

        public void CreateBullet(Form form)
        {
            bullet.BackColor = Color.Red;
            bullet.Size = new Size(7, 7);
            bullet.Left = leftFrame;
            bullet.Top = topFrame;
          

            form.Controls.Add(bullet);

            //Create timer event for bullet to travel across screen
            timer.Interval = bulletSpeed;
            timer.Tick += new EventHandler(BulletTravelEvent);
            timer.Start();
        }

       
        public void BulletTravelEvent(object sender, EventArgs e)
        {
            switch (bulletDirection)
            {
                case "left":
                    bullet.Left -= bulletSpeed;
                    break;

                case "right":
                    bullet.Left += bulletSpeed;
                    break;

                case "up":
                    bullet.Top -= bulletSpeed;
                    break;

                case "down":
                    bullet.Top += bulletSpeed;
                    break;
            }

            //Delete bullet if it collides with something or if it travels off the screen
            if (bullet.Left < 10 || bullet.Left > 1200 || bullet.Top < 10 || bullet.Top > 700)
            {
                timer.Stop();
                timer.Dispose();
                bullet.Dispose();
            }
        }

        public void OnCollision(Collider collisionType)
        {

        }


    }
}
