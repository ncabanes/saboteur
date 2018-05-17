/// Player - The user-controlled character

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.08, 17-may-2018, Nacho: 
 *      Correct width and height (for the standard image)
 * 0.05, 11-may-2018,Marcos Cervantes, Jose Vilaplana, Jump
 * 0.03, 10-may-2018, Luis and Cesar, Loading the ImageSequence of the player.
 * 0.02, 09-may-2018, Luis and Cesar, corrections by Nacho:
 *      Constructor + MoveLeft, MoveRight
 * 0.01, 09-may-2018, Nacho: First version, empty skeleton
 */

class Player : Sprite
{

    int jumpFrame;
    protected bool jumping;
   /* string[] rightJump = { "data/imgRetro/playerJump1r.png",
                "data/imgRetro/playerJump2r.png",};
    string[] leftJump = {"data/imgRetro/playerJump1l.png",
                "data/imgRetro/playerJump2l.png",};*/


    public Player()
    {
        LoadImage("data/imgRetro/playerStaticr.png");
        
        x = 50;
        y = 200;
        width = 128;
        height = 160;
        xSpeed = 4;
        ySpeed = 4;
        jumpFrame = 1;
        jumping = false;
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
                "data/imgRetro/playerJump2l.png",
                "data/imgRetro/playerJump1r.png",
                "data/imgRetro/playerJump2r.png",
            });

        currentDirection = RIGHT;

        LoadSequence(DOWN,
            new string[] { "data/imgRetro/playerDuck.png" });

        SetGameUpdatesPerFrame(5);
    }        

    public void MoveRight()
    {
        x += xSpeed;
        ChangeDirection(RIGHT);
        NextFrame();
    }

    public void MoveLeft()
    {
        x -= xSpeed;
        ChangeDirection(LEFT);
        NextFrame();
    }

    public void Jump()
    {
        if (!jumping)
        {
            ChangeDirection(UP);
            y -= 50;
            jumping = true;
        }
    }

    public override void Move()
    {
        if (jumping)
        {
            jumpFrame++;
            if (jumpFrame > 40)
            {
                jumping = false;
                y += 50;
                ChangeDirection(RIGHT);
                jumpFrame = 1;
            }
        }
    }


    public void Duck()
    {
        ChangeDirection(DOWN);
    }

}
