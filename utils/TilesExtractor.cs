using System;
using System.Diagnostics;

// Utility to extract all tiles from the game map
// Beware: it will generate over 130K files, as
//   dups are not checked. You can use any
//   "duplicates remover" later, such as CloneSpy.
// Uses "nconvert", from xnview.com
class SaboteurTilesExtractor
{
    static void Main(string[] args)
    {
        int width = 3366 / 8;
        int height = 2589 / 8;
        int topMargin = 3;

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                int startX = col * 8;
                int startY = row * 8;
                string options = "-out png -crop " +
                    (startX+1) + " " + (startY+topMargin+1) + " 8 8 " +
                    "-o tile-" + col.ToString("000") + "-" +
                    row.ToString("000") +
                    " SaboteurMap2.png";
                Console.WriteLine(options);
                Process p = Process.Start("nconvert.exe",
                    options);
            }
        }
    }
}
