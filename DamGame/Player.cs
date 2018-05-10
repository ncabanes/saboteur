/// Player - The user-controlled character

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.01, 09-may-2018, Nacho: First version, empty skeleton
 * 0.02, 09-may-2018, Luis and Cesar, corrections by Nacho:
 *      Constructor + MoveLeft, MoveRight
 * 0.03, 10-may-2018, Luis and Cesar, Loading the ImageSequence of the player.
 */

class Player : Sprite
{

    int frame;
    string[] rightJump = { "data/imgRetro/playerJump1r.png",
                "data/imgRetro/playerJump2r.png",};

    public Player()
    {
        LoadImage("data/imgRetro/playerStaticr.png");
        
        x = 50;
        y = 200;
        width = 64;
        height = 180;
        xSpeed = 4;
        ySpeed = 4;
        frame = 1;
        LoadSequence(RIGHT,
            new string[] { "data/imgRetro/playerWalking1r.png",
                "data/imgRetro/playerWalking2r.png",
                "data/imgRetro/playerWalking3r.png"});

        LoadSequence(LEFT,
            new string[] { "data/imgRetro/playerWalking1l.png",
                "data/imgRetro/playerWalking2l.png",
                "data/imgRetro/playerWalking3l.png"});

        LoadSequence(UP,
            new string[] { "data/imgRetro/playerJump1l.png",
                "data/imgRetro/playerJump2l.png"});
        currentDirection = RIGHT;

        LoadSequence(DOWN,
            new string[] { "data/imgRetro/playerDuck.png" });
    }        

    public void MoveRight()
    {
        x += xSpeed;
        ChangeDirection(RIGHT);
        frame++;
        if (frame > 5)
        {
            NextFrame();
            frame = 1;
        }
    }

    public void MoveLeft()
    {
        x -= xSpeed;

        ChangeDirection(LEFT);
        frame++;
        if (frame > 5)
        {
            NextFrame();
            frame = 1;
        }
    }

    public void Jump()
    {
        ChangeDirection(UP);
        frame++;
        if (frame > 5)
        {
            NextFrame();
            frame = 1;
        }
    }

    public void Duck()
    {
        ChangeDirection(DOWN);
    }

}
