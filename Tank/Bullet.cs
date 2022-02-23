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
            leftFrame = bullet.Left;
            topFrame = bullet.Top;

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

           
        }

        public void OnCollision(Collider collisionType)
        {

        }


    }
}
