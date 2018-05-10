/// Enemy - One of the (harmful, pseudo-intelligent, non-static) 
/// items in the game

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.03, 10-may-2018, Guillermo Pastor, Brandon Blasco, Javier Cases: constructor
 * 0.02, 09-may-2018, Raul Gogna, Brandon Blasco, Javier Cases: constructor
 * 0.01, 09-may-2018, Nacho: First version, empty skeleton
 */

class Enemy : Sprite
{
    protected bool die;
    int frame;

    public Enemy()
    {
        LoadImage("data/imgRetro/enemyStatic.png");
        xSpeed = -1;

        frame = 1;
        LoadSequence(RIGHT,
            new string[] { "data/imgRetro/enemyWalking1r.png",
                "data/imgRetro/enemyWalking2r.png",
                "data/imgRetro/enemyWalking3r.png"});

        LoadSequence(LEFT,
            new string[] { "data/imgRetro/enemyWalking1l.png",
                "data/imgRetro/enemyWalking2l.png",
                "data/imgRetro/enemyWalking3l.png"});
    }

    public override void Move()
    {
        // TO DO: Define real logic

        //Change direction
        if (x < 900 - width && x > 0)
            x += xSpeed;
        else
        {
            currentDirection = currentDirection == RIGHT ? LEFT : RIGHT;
            xSpeed *= -1;
            x += xSpeed;
        }

        //Speed
        frame++;
        if (frame > 10)
        {
            NextFrame();
            frame = 1;
        }
    }
}
