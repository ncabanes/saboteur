/// Player - The user-controlled character

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.01, 09-may-2018, Nacho: First version, empty skeleton
 * 0.02, 09-may-2018, Luis and Cesar, corrections by Nacho:
 *      Constructor + MoveLeft, MoveRight
 */

class Player : Sprite
{
    public Player()
    {
        LoadImage("data/imgRetro/playerStaticr.png");
        x = 50;
        y = 200;
        width = 64;
        height = 180;
        xSpeed = 4;
    }        

    public void MoveRight()
    {
        x += xSpeed;
    }

    public void MoveLeft()
    {
        x -= xSpeed;
    }

}
