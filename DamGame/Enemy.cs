/// Enemy - One of the (harmful, pseudo-intelligent, non-static) 
/// items in the game

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.02, 09-may-2018, Raul Gogna, Brandom Blasco, Javier Cases: constructor
 * 0.01, 09-may-2018, Nacho: First version, empty skeleton
 */

class Enemy : Sprite
{
    protected bool die;
    protected string[] images = {"enemyWalking1l", "enemyWalking1r",
        "enemyWalking2l", "enemyWalking2r", "enemyWalking3l",
        "enemyWalking3r" };

    public Enemy()
    {
        LoadImage("data/imgRetro/enemyStatic.png");
        xSpeed = -1;
    }

    public Enemy(string[] images) : base(images)
    {
        this.images = images;
    }

    public override void Move()
    {
        // TO DO: Define real logic
        x += xSpeed;
    }
}
