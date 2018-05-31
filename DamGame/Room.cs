
/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.18, 31-may-2018, Nacho: Can move left, right, up & down in big map
 *       Row and column switched in GetRoomData
 *       Bricks are represented with "+" in the map
 * 0.17, 31-may-2018, Nacho: Only one big map, first approach
 * 0.15, 29-may-2018, Nacho: Added CanMoveEnemyTo(x1, y1, x2, y2)
 * 0.13, 24-may-2018, Nacho: Player can move upstairs and downstairs,
 *      even to different rooms (remaining: collisions on end of stairs) 
 * 0.12, 23-may-2018, Nacho: IsThereVerticalStair implemented (bouncing boxes)
 * 0.10, 21-may-2018, Nacho: 
 *      try-catch for error handling in LoadRoom
 *      The room can contain enemies and dogs
 * 0.09, 18-may-2018, Nacho: Fine tuned right and left margins for the player
 * 0.08, 17-may-2018, Nacho: CanMoveTo implemented (bouncing boxes)
 * 0.07, 14-may-2018, Nacho: Retro/updated look changeable
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

using System.Collections.Generic;
using System.IO;
using System;

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
    List<Enemy> enemies;
    List<Dog> dogs;
    int roomWidth;
    int roomHeight;
    int currentRoom;
    int currentCol;
    int currentRow;
    int leftRoom;
    int rightRoom;
    int upRoom;
    int bottomRoom;
    int screenWidth = 1024;
    Complex myComplex;

    public Room(Complex c, bool retroLook)
    {
        roomWidth = 32;
        roomHeight = 17;
        string folder = "imgRetro";
        if (!retroLook)
            folder = "imgUpdated";
        tmpBackground = new Image("data/" + folder + "/exampleRoom.png");
        background = new char[roomWidth, roomHeight];
        brick = new Image("data/" + folder + "/tileWall1.png");
        ground = new Image("data/" + folder + "/tileFloor.png");
        window = new Image("data/" + folder + "/tileWall2.png");
        door = new Image("data/" + folder + "/tileWall3.png");
        tileStairLeft = new Image("data/" + folder + "/tileStairLeft.png");
        tileStairRight = new Image("data/" + folder + "/tileStairRight.png");
        currentCol = 6;  // Starting room
        currentRow = 9;
        myComplex = c;
        Load(myComplex, currentCol, currentRow); 
        enemies = new List<Enemy>();
        dogs = new List<Dog>();
    }

    public void Load(Complex c, int col, int row)
    {
        background = c.GetRoomData(col, row);
    }

    public void MoveToRoomRight()
    {
        currentCol++;
        Load(myComplex, currentCol, currentRow);
    }

    public void MoveToRoomLeft()
    {
        currentCol--;
        Load(myComplex, currentCol, currentRow);
    }

    public void MoveToRoomUp()
    {
        currentRow--;
        Load(myComplex, currentCol, currentRow);
    }

    public void MoveToRoomDown()
    {
        currentRow++;
        Load(myComplex, currentCol, currentRow);
    }

    /*
    /// <summary>
    /// Loads the data for a room from file 
    /// </summary>
    /// <param name="n">Number of room</param>
    public void Load(int n)
    {
        try
        {
            string levelFileName = "data/room" + n.ToString("000") + ".dat";
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

            dogs = new List<Dog>();
            string[] dogDetails = input.ReadLine().Split('=');
            int numDogs = Convert.ToInt32(dogDetails[1]);
            for (int i = 0; i < numDogs; i++)
            {
                Dog d = new Dog();
                string[] posDetails = dogDetails[2 + i].Split(',');
                int x = Convert.ToInt32(posDetails[0]);
                int y = Convert.ToInt32(posDetails[1]);
                dogs.Add(d);
                d.MoveTo(x, y);
            }

            enemies = new List<Enemy>();
            string[] enemiesDetails = input.ReadLine().Split('=');
            int numEnemies = Convert.ToInt32(enemiesDetails[1]);
            for (int i = 0; i < numEnemies; i++)
            {
                Enemy e = new Enemy();
                string[] posDetails = enemiesDetails[2 + i].Split(',');
                int x = Convert.ToInt32(posDetails[0]);
                int y = Convert.ToInt32(posDetails[1]);
                enemies.Add(e);
                e.MoveTo(x, y);
            }

            input.Close();
        }
        catch (Exception e)
        {
            File.WriteAllLines("roomError.log",
                new string[] { "Error loading room: ", e.Message });
        }
    }
    */

    public void Draw()
    {
        for (int i = 0; i < roomWidth; i++)
        {
            for (int j = 0; j < roomHeight; j++)
            {
                switch (background[i,j])
                {
                    case '+':
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

    public bool CanMoveEnemyTo(int x1, int y1, int x2, int y2)
    {
        if (x1 < 0)
            return false;

        if (x2 > screenWidth)
            return false;

        return CanMoveTo(x1, y1, x2, y2);
    }

    public bool CanMoveTo(int x1, int y1, int x2, int y2)
    {
        

        // Let's assume only background (tile "g") cannot be crossed now
        for (int i = 0; i < roomWidth; i++)
        {
            for (int j = 0; j < roomHeight; j++)
            {
                char tile = background[i, j];
                if (tile == 'g')
                {
                    int x1t = i * 32;
                    int y1t = j * 32;
                    int x2t = x1t + 32;
                    int y2t = y1t + 32;
                    if ((x1t < x2) &&
                        (x2t > x1) &&
                        (y1t < y2) &&
                        (y2t > y1) // Collision as bouncing boxes
                        )
                        return false;
                }
            }
        }
        return true;
    }

    public bool IsThereVerticalStair(int x1, int y1, int x2, int y2)
    {
        // "<" and ">" are the symbols for the stairs
        for (int i = 0; i < roomWidth; i++)
        {
            for (int j = 0; j < roomHeight; j++)
            {
                char tile = background[i, j];
                if ((tile == '<') || (tile == '>'))
                {
                    int x1t = i * 32;
                    int y1t = j * 32;
                    int x2t = x1t + 32;
                    int y2t = y1t + 32;
                    if ((x1t < x2) &&
                        (x2t > x1) &&
                        (y1t < y2) &&
                        (y2t > y1) // Collision as bouncing boxes
                        )
                        return true;
                }
            }
        }
        return false;
    }

    /// Return the number of the next room if is accesible, if it is not return -1.
    public int CheckIfNewRoom(Player player)
    {
        if (player.GetX() >= roomWidth * 32 - player.GetWidth())
            return rightRoom;
        else if (player.GetX() < 0)
            return leftRoom;
        else if (player.GetY() <= 20)
            return upRoom;
        else if(player.GetY() >= roomHeight * 32 - player.GetHeight())
            return bottomRoom;
        else
            return -1;
    }

    public List<Dog> GetDogs()
    {
        return dogs;
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }
}
