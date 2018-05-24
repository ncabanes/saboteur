/// Player - The user-controlled character

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.13, 24-may-2018, Nacho: Player can move upstairs and downstairs,
 *      even to different rooms (remaining: collisions on end of stairs) 
 * 0.12, 23-may-2018, Nacho: 
 *      Added TryToMoveUp, TryToMoveDown, climbing sequence & control boolean
 * 0.11, 22-may-2018, Nacho: Added TryToMoveLeft, TryToMoveRight
 * 0.09, 18-may-2018, Nacho: Added gravity
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
    int standardHeight;
    protected bool jumping, climbing;
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
        standardHeight = 160; // used when trying to leave a vertical stair
        xSpeed = 4;
        ySpeed = 4;
        jumpFrame = 1;
        jumping = false;
        climbing = false;
        LoadSequence(RIGHT,
            new string[] { "data/imgRetro/playerWalking1r.png",
                "data/imgRetro/playerWalking2r.png",
                "data/imgRetro/playerWalking3r.png"});

        LoadSequence(LEFT,
            new string[] { "data/imgRetro/playerWalking1l.png",
                "data/imgRetro/playerWalking2l.png",
                "data/imgRetro/playerWalking3l.png"});

        LoadSequence(UP,
            new string[] { "data/imgRetro/playerClimb1.png",
                "data/imgRetro/playerClimb2.png",
            });

        LoadSequence(JUMPING,
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
        if (!jumping)
        {
            climbing = false;
            height = 160;
            x += xSpeed;
            ChangeDirection(RIGHT);
            NextFrame();
        }
    }

    public void MoveLeft()
    {
        if (!jumping)
        {
            climbing = false;
            height = 160;
            x -= xSpeed;
            ChangeDirection(LEFT);
            NextFrame();
        }
    }

    public void MoveUp()
    {
        y -= (244 - height);
        height = 244;
        y -= ySpeed;
        ChangeDirection(UP);
        NextFrame();
    }

    public void MoveDown()
    {
        height = 244;
        y += ySpeed;
        ChangeDirection(UP);
        NextFrame();
    }

    public void Jump()
    {
        if (!jumping)
        {
            ChangeDirection(JUMPING);
            y -= 50;
            height = 180;
            jumping = true;
        }
    }

    public void Move(Room r)
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
        // If not jumping nor climbing, let's check gravity
        else if (!climbing)
        {
            if (r.CanMoveTo(x, y + 4, x + width, y + height + 4))
                MoveTo(x, y + 4);
        }
    }


    public void Duck()
    {
        ChangeDirection(DOWN);
    }


    public void TryToMoveRight(Room r)
    {
        // If we can move right, let's do it
        if (r.CanMoveTo(x + xSpeed, y, x + xSpeed + width,y + standardHeight))
        {
            MoveRight();
        }
        else
        {
            // If there is a side stair to climb, let's do it
            if (r.CanMoveTo(x + xSpeed, y - 32, 
                    x + xSpeed + width, y + height - 32))
            {
                y -= 32;
                MoveRight();
            }
        }

        int nextRoom = r.CheckIfNewRoom(this);
        if (nextRoom != -1)
        {
            r.Load(nextRoom);
            MoveTo(0, y);
        }
    }

    public void TryToMoveLeft(Room r)
    {
        // If we can move left, let's do it
        if (r.CanMoveTo(x - xSpeed, y, x - xSpeed + width, y + standardHeight))
        {
            MoveLeft();
        }
        else
        {
            // If there is a side stair to climb, let's do it
            if (r.CanMoveTo(x - xSpeed, y - 32,
                    x - xSpeed + width, y + height - 32))
            {
                y -= 32;
                MoveLeft();
            }
        }

        int nextRoom = r.CheckIfNewRoom(this);
        if (nextRoom != -1)
        {
            r.Load(nextRoom);
            MoveTo(1024-width, y);
        }
    }

    public void TryToMoveUp(Room r)
    {
        // If there is a stair upwards, let's climb it
        if (r.IsThereVerticalStair(x, y - ySpeed, x + width, y + height - ySpeed))
        {
            // TO DO: Check if there is ground over the stair
            climbing = true;
            MoveUp();
        }
        else
        {
            climbing = false;
            Jump();
        }

        int nextRoom = r.CheckIfNewRoom(this);
        if (nextRoom != -1)
        {
            r.Load(nextRoom);
            MoveTo(x, 17*32-height);
        }
    }

    public void TryToMoveDown(Room r)
    {
        // If there is a stair downwards, let's use it
        if (r.IsThereVerticalStair(x, y + ySpeed, x + width, y + height + ySpeed))
        {
            // TO DO: Check if there is ground under the stair
            climbing = true;
            MoveDown();
        }
        else
        {
            climbing = false;
            Duck();
        }

        int nextRoom = r.CheckIfNewRoom(this);
        if (nextRoom != -1)
        {
            r.Load(nextRoom);
            MoveTo(x, 0);
        }
    }
}
