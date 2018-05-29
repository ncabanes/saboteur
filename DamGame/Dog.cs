/// Dog - One of the (harmful) moving items in the game

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.15, 29-may-2018, Nacho: Uses Room.CanMoveEnemyTo(x1, y1, x2, y2)
 * 0.04. 11-may-2018, Nacho: Uses "SetGameUpdatesPerFrame" from Sprite
 * 0.03. 10-may-2018, López, Rebollo: Implemented change of direction
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
        SetGameUpdatesPerFrame(10);
    }

    public void Move(Room r)
    {
        // @@@@@@@@@@@@@@@@@@@
        NextFrame();

        //Change direction (still no collisions checked)
        if (r.CanMoveEnemyTo(x + xSpeed, y, x + xSpeed + width, y + height))
            x += xSpeed;
        else
        {
            currentDirection = currentDirection == RIGHT ? LEFT : RIGHT;
            xSpeed *= -1;
            x += xSpeed;
        }
    }
}
