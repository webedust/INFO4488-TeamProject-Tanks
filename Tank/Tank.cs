using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank
{
    class Tank
    {
        public static float speed;
        public static float playerHealth;
        public static float enemyHealth;
        public static float fireRate;
        public static float projectileDamage;
        public static bool isDead = false;
        public static bool goLeft;
        public static bool goRight;
        public static bool goUp;
        public static bool goDown;




        public void takeDamage(float projectileDamage)
        {
            //Add logic to determine which entity got hit
            playerHealth -= projectileDamage;

            enemyHealth -= projectileDamage;
        }

        private void playerDeath()
        {
            if(playerHealth <= 0)
            {
                isDead = true;
                //Display game over 
            }
        }

        private void enemyDeath()
        {
            if(enemyHealth <= 0)
            {
                isDead = true;
                //Remove dead enemy from the map
            }
        }

        private void shoot()
        {
            //Add code for firing the projectile 
        }
    }
}
