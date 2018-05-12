
/* Part of Saboteur Remake
 * 
 * Changes:
 * 
 * 0.06, 12-may-2018, Nacho: room data was loaded in Draw, now in constructor
 *          LoadRoom receives room number, instead of filename
 * 0.05b, 11-may-2018, Daniel Miquel, Luis Martin: Room with stairs. 
 * 0.05, 11-may-2018, Santana, Saorin, Sabater: Save data info of close rooms from a file. 
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
    Image tileStairLeft;
    Image tileStairRight;
    int roomWidth;
    int roomHeight;
    int currentRoom;
    int leftRoom;
    int rightRoom;
    int upRoom;
    int bottomRoom;

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
        tileStairLeft = new Image("data/imgRetro/tileStairLeft.png");
        tileStairRight = new Image("data/imgRetro/tileStairRight.png");
        LoadRoom(65);  // Starting room
    }

    public void LoadRoom(int n)
    {
        string levelFileName = "data/room" + n.ToString("000")+ ".dat";
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
                        case '<':
                            background[col, row] = '<';
                            break;
                        case '>':
                            background[col, row] = '>';
                            break;
                        default:
                            break;
                    }
                }
                row++;
            }
        }
        // Read and parse extra room details

        string roomNumber = input.ReadLine().Split('=')[1];
        currentRoom = int.Parse(roomNumber);

        roomNumber = input.ReadLine().Split('=')[1];
        if (roomNumber.ToUpper() != "NOT")
            leftRoom = int.Parse(roomNumber);
        else
            leftRoom = -1;

        roomNumber = input.ReadLine().Split('=')[1];
        if (roomNumber.ToUpper() != "NOT")
            rightRoom = int.Parse(roomNumber);
        else
            rightRoom = -1;

        roomNumber = input.ReadLine().Split('=')[1];
        if (roomNumber.ToUpper() != "NOT")
            upRoom = int.Parse(roomNumber);
        else
            upRoom = -1;

        roomNumber = input.ReadLine().Split('=')[1];
        if (roomNumber.ToUpper() != "NOT")
            bottomRoom = int.Parse(roomNumber);
        else
            bottomRoom = -1;

        input.Close();      
    }

    public void Draw()
    {
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
                    case '<':
                        SdlHardware.DrawHiddenImage(tileStairLeft, i * 32, j * 32);
                        break;
                    case '>':
                        SdlHardware.DrawHiddenImage(tileStairRight, i * 32, j * 32);
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

    /// Return the number of the next room if is accesible, if it is not return -1.
    public int CheckIfNewRoom(Player player)
    {
        if (player.GetX() >= (roomWidth * 32) + (player.GetWidth() / 2))
            return rightRoom;
        else if (player.GetX() <= 0 - (player.GetWidth() / 2))
            return leftRoom;
        else if (player.GetY() <= 0 - (player.GetHeight() / 2))
            return upRoom;
        else if(player.GetY() >= (roomHeight * 17) + (player.GetHeight() / 2))
            return bottomRoom;
        else
        return -1;
        // TODO: go up or down checking stairs.
    }
}
