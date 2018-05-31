using System;
using System.IO;

// Map generator V 01
// Rooms with ground in the lowest row, first column and R in first tile
class MapGenerator01
{
    static void Main(string[] args)
    {
        Console.WriteLine("Generating example maze...");
        int roomRows = 19; // Rows of rooms
        int roomCols = 14; // Columns of rooms
        int tileRows = 17; // Rows of tiles in a room
        int tileCols = 32; // Rows of tiles in a room

        StreamWriter output = new StreamWriter("map.dat");

        for (int roomRow = 0; roomRow < roomRows; roomRow++)
        {
            for (int tileRow = 0; tileRow < tileRows; tileRow++)

            {
                for (int roomCol = 0; roomCol < roomCols; roomCol++)
                {
                    for (int tileCol = 0; tileCol < tileCols; tileCol++)
                    {
                        if ((tileRow == 0) && (tileCol == 0))
                            output.Write("R");
                        else if ((tileRow == tileRows - 1) || (tileCol == 0))
                            output.Write("g");
                        else
                            output.Write(".");
                    }
                }
                output.WriteLine();
            }

        }
        output.Close();
        Console.WriteLine("Done!");
    }
}
