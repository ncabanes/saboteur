/// Dog - One of the (harmful) moving items in the game

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.02. 09-may-2018, López, Rebollo: Implemented movement and sprites
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 */

class Dog : Sprite
{
    int frame;

    public Dog()
    {
        frame = 1;
        LoadSequence(RIGHT,
            new string[] { "data/imgRetro/dog1r.png",
                "data/imgRetro/dog2r.png",
                "data/imgRetro/dog3r.png"});

        LoadSequence(LEFT,
            new string[] { "data/imgRetro/dog1l.png",
                "data/imgRetro/dog2l.png",
                "data/imgRetro/dog3l.png"});

        currentDirection = RIGHT;
        width = 128;
        height = 80;
        xSpeed = 2;
    }

    public override void Move()
    {
        //Change direction
        if (x < 1024 - width && x > 0)
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
