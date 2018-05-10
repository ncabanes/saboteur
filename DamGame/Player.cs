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
    string[] rightMove = { "data/imgRetro/playerWalking1r.png",
                "data/imgRetro/playerWalking2r.png",
                "data/imgRetro/playerWalking3r.png"};

    string[] leftMove = { "data/imgRetro/playerWalking1l.png",
                "data/imgRetro/playerWalking2l.png",
                "data/imgRetro/playerWalking3l.png"};

    string[] leftJump = { "data/imgRetro/playerJump1l.png",
                "data/imgRetro/playerJump2l.png",};

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
        currentDirection = RIGHT;
        LoadSequence(RIGHT,
            new string[] { "data/imgRetro/playerWalking1r.png",
                "data/imgRetro/playerWalking2r.png",
                "data/imgRetro/playerWalking3r.png"});

        LoadSequence(LEFT,
            new string[] { "data/imgRetro/playerWalking1l.png",
                "data/imgRetro/playerWalking2l.png",
                "data/imgRetro/playerWalking3l.png"});

    }        

    public void MoveRight()
    {

        x += xSpeed;
        LoadSequence(RIGHT, rightMove);
    }

    public void MoveLeft()
    {
        x -= xSpeed;
        LoadSequence(RIGHT, leftMove);
    }

    public void Jump()
    {
        y -= ySpeed;
        LoadSequence(UP, leftJump);
    }

    public void Duck()
    {
        y += xSpeed;
        LoadSequence(DOWN, rightJump);
    }

}
