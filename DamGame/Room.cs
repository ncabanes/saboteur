/// Room - Represents one of the rooms that the user can visit

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.02, 09-may-2018, Santana,Saorin: Replace with tiles for the real map 
 *      of the room (started)
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 */

class Room
{
    Image tmpBackground;
    char[,] background;
    Image brick;
    Image ground;
    Image window;
    Image door;

    public Room()
    {
        tmpBackground = new Image("data/imgRetro/exampleRoom.png");
        background = new char[30,17];
        brick = new Image("data/imgRetro/tileWall1.png");
        ground = new Image("data/imgRetro/tileFloor.png");
        window = new Image("data/imgRetro/tileWall2.png");
        door = new Image("data/imgRetro/tileWall3.png");
    }

    public void Draw()
    {
        // TO DO: Replace with tiles for the real map of the room
        SdlHardware.DrawHiddenImage(tmpBackground, 32, 0);

        // TO DO: This part is not finished, as the array is still empty
        for (int i=0;i<30;i++)
        {
            for(int j=0;j<17;j++)
            {
                switch (background[i,j])
                {
                    case 'b':
                        SdlHardware.DrawHiddenImage(brick, i*32, j*32);
                        break;
                    case 'g':
                        SdlHardware.DrawHiddenImage(ground, i * 32, j * 32);
                        break;
                    case 'w':
                        SdlHardware.DrawHiddenImage(window, i * 32, j * 32);
                        break;
                    case 'd':
                        SdlHardware.DrawHiddenImage(door, i * 32, j * 32);
                        break;
                    default:
                        break;
                }
            }
        }

        
    }

    public bool CanMoveTo(int x1, int y1, int x2, int y2)
    {
        return true;
    }
}
