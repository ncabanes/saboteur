using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;

// Map generator V 02
// Rooms with ground in the lowest row, first column and R in first tile

class SaboteurMapGenerator02
{
    static bool ContainsImage(Bitmap big, Bitmap small, int x, int y)
    {
        for (int i = 0; i < 8; i++) // 8x8 pixels
        {
            for (int j = 0; j < 8; j++)
            {
                Color colorBig = big.GetPixel(x + i, y + j);
                Color colorSmall = small.GetPixel(i, j);
                if (colorBig != colorSmall)
                    return false;
            }
        }
        return true;
    }


    static void Main(string[] args)
    {
        Bitmap bigImage = new Bitmap("SaboteurMap2.png");

        Bitmap imageGround = new Bitmap("imageG.png");
        Bitmap imageBrick = new Bitmap("imageB.png");
        Bitmap imageEmpty = new Bitmap("image0.png");
        Bitmap imageL = new Bitmap("imageL.png");
        Bitmap imageD = new Bitmap("imageD.png");
        Bitmap imageH = new Bitmap("imageH.png");
        Bitmap imageI = new Bitmap("imageI.png");
        Bitmap imageSea = new Bitmap("imageSea.png");
        Bitmap imageWH = new Bitmap("imageWH.png");
        Bitmap imageWV = new Bitmap("imageWV.png");
        Bitmap imageBlue = new Bitmap("imageBlue.png");
        Bitmap imageRed = new Bitmap("imageRed.png");

        int width = 3366 / 8;
        int height = 2589 / 8;
        int topMargin = 3;

        char[,] map = new char[width, height];
        for (int row = 0; row < height; row++)
            for (int col = 0; col < width; col++)
                map[col, row] = ' ';

        // Step 1: Let's check the big image against all the tiles
        for (int row = 0; row < height; row ++)
        {
            for (int col = 0; col < width; col ++)
            {
                //Console.Write("({0},{1}) ", col, row);
                int startX = col * 8 + 1;
                int startY = row * 8 + topMargin + 1;
                if (ContainsImage(bigImage, imageEmpty, startX, startY))
                    map[col, row] = '.';
                else if (ContainsImage(bigImage, imageGround, startX, startY))
                    map[col, row] = 'g';
                else if (ContainsImage(bigImage, imageBrick, startX, startY))
                    map[col, row] = '+';
                else if (ContainsImage(bigImage, imageL, startX, startY))
                    map[col, row] = 'L';
                else if (ContainsImage(bigImage, imageD, startX, startY))
                    map[col, row] = 'D';
                else if (ContainsImage(bigImage, imageH, startX, startY))
                    map[col, row] = 'H';
                else if (ContainsImage(bigImage, imageI, startX, startY))
                    map[col, row] = 'I';
                else if (ContainsImage(bigImage, imageSea, startX, startY))
                    map[col, row] = 's';
                else if (ContainsImage(bigImage, imageWH, startX, startY))
                    map[col, row] = 'w';
                else if (ContainsImage(bigImage, imageWV, startX, startY))
                    map[col, row] = 'W';
                else if (ContainsImage(bigImage, imageBlue, startX, startY))
                    map[col, row] = '-';
                else if (ContainsImage(bigImage, imageRed, startX, startY))
                    map[col, row] = 'R';
            }
            Console.Write(row + " (" +row * 100 / height + "%) ");
        }

        // Step 2: Let's dump to file the resulting map
        StreamWriter mapFile = new StreamWriter("mapFile.dat");
        {
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    mapFile.Write(map[col, row]);
                }
                mapFile.WriteLine();
            }
        }
        mapFile.Close();
    }
}
