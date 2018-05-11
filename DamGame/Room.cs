
/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.04. 11-may-2018, Nacho: Rooms with more detailed definition can be read from file
 * 0.03, 10-may-2018, Pestana, Saorin: Load map from a file. 
 *  
 * 0.02, 09-may-2018, Santana,Saorin: Replace with tiles for the real map 
 *      of the room (started)
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 */

using System.IO;

/// Room - Represents one of the rooms that the user can visit
class Room
{
    Image tmpBackground;
    char[,] background;
    Image brick;
    Image ground;
    Image window;
    Image door;
    int roomWidth;
    int roomHeight;

    public Room()
    {
        roomWidth = 33;
        roomHeight = 17;
        tmpBackground = new Image("data/imgRetro/exampleRoom.png");
        background = new char[roomWidth, roomHeight];
        brick = new Image("data/imgRetro/tileWall1.png");
        ground = new Image("data/imgRetro/tileFloor.png");
        window = new Image("data/imgRetro/tileWall2.png");
        door = new Image("data/imgRetro/tileWall3.png");      
    }

    private void LoadRoom(string levelFileName)
    {
        StreamReader input = new StreamReader(levelFileName);
        string line = "";
        int row = 0;
        for (int l = 0; l < roomHeight; l++)
        {
            line = input.ReadLine();
            if (line != null)
            {
                for (int col = 0; col < line.Length; col++)
                {
                    switch (line[col])
                    {
                        case 'b':
                            background[col, row] = 'b';
                            break;
                        case 'g':
                            background[col, row] = 'g';
                            break;
                        case 'w':
                            background[col, row] = 'w';
                            break;
                        case 'd':
                            background[col, row] = 'd';
                            break;
                        default:
                            break;
                    }
                }
                row++;
            }
        }
        // TO DO: Read and parse extra room details

        input.Close();      
    }

    public void Draw()
    {
        // TO DO: Replace with tiles for the real map of the room
        // SdlHardware.DrawHiddenImage(tmpBackground, 32, 0);
        LoadRoom("data/room065.dat");
        // TO DO: This part is not finished, as the array is still empty
        for (int i = 0; i < roomWidth; i++)
        {
            for (int j = 0; j < roomHeight; j++)
            {
                switch (background[i,j])
                {
                    case 'b':
                        SdlHardware.DrawHiddenImage(brick, i * 32, j * 32);
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
