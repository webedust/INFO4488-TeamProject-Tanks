using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank
{
    class Tank
    {
        public float speed;
        public float playerHealth;
        public float enemyHealth;
        public float fireRate;
        public float projectileDamage;
        
        public bool goLeft;
        public bool goRight;
        public bool goUp;
        public bool goDown;




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
               
                //Display game over 
            }
        }

        private void enemyDeath()
        {
            if(enemyHealth <= 0)
            {
              
                //Remove dead enemy from the map
            }
        }

        private void shoot()
        {
            //Add code for firing the projectile 
        }
    }
}
