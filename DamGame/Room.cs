/// Room - Represents one of the rooms that the user can visit

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 * 0.01, 09-may-2018, Santana,Saorin: Replace with tiles for the real map of the room
 */

class Room
{
    char[,] background;
    Image brick;
    Image ground;
    Image window;
    Image door;

    public Room()
    {
        background = new char[30,17];
        brick = new Image("tileWall1.png");
        ground = new Image("tileFloor.png");
        window = new Image("tileWall2.png");
        door = new Image("tileWall3.png");
    }

    public void Draw()
    {
        // TO DO: Replace with tiles for the real map of the room
        for(int i=0;i<30;i++)
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
