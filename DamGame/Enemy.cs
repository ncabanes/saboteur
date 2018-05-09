/// Enemy - One of the (harmful, pseudo-intelligent, non-static) 
/// items in the game

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.01, 09-may-2018, Nacho: First version, empty skeleton
 * 0.02, 09-may-2018, Raul Gogna, Brandom Blasco, Javier Cases:
 */

namespace DamGame
{
    class Enemy : Sprite
    {
        protected bool die;
        protected string[] images = {"enemyWalking1l", "enemyWalking1r",
            "enemyWalking2l", "enemyWalking2r", "enemyWalking3l",
            "enemyWalking3r" };

        public Enemy(string image) : base(image)
        {
            image = "enemyStatic";
        }

        public Enemy(string[] images) : base(images)
        {
            this.images = images;
        }

        public void Move() { }
    }
}