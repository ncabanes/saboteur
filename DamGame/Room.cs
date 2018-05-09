/// Room - Represents one of the rooms that the user can visit

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 */

class Room
{
    Image background;

    public Room()
    {
        background = new Image("data/imgRetro/exampleRoom.png");
    }

    public void Draw()
    {
        // TO DO: Replace with tiles for the real map of the room
        SdlHardware.DrawHiddenImage(background, 32, 0);
    }

    public bool CanMoveTo(int x1, int y1, int x2, int y2)
    {
        return true;
    }
}
