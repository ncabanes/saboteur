using System.IO;

/// Complex - Represents the whole building to be visited, 
/// consisting on a series of rooms

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.17, 31-may-2018, Nacho: Only one big map, first approach
 * 0.07, 14-may-2018, Nacho: Retro/updated look changeable
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton, only one room
 */

class Complex
{
    Room currentRoom;
    string[] mapData;
    int roomRows = 19; // Rows of rooms
    int roomCols = 14; // Columns of rooms
    int tileRows = 17; // Rows of tiles in a room
    int tileCols = 32; // Rows of tiles in a room

    public Complex(bool retroLook)
    {
        mapData = File.ReadAllLines("data\\map.dat");
        currentRoom = new Room(this, retroLook);
        // currentRoom.Set
    }

    public char[,] GetRoomData(int row, int col)
    {
        char[,] data = new char[tileCols, tileRows];
        int startRow = row * tileRows;
        int startCol = col * tileCols;
        for (int r = 0; r < tileRows; r++)
        {
            for (int c = 0; c < tileCols; c++)
            {
                data[c, r] = mapData[startRow + r][startCol + c];
            }
        }
        return data;
    }

    public Room GetCurrentRoom()
    {
        return currentRoom;
    }
}
