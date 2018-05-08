/**
 * DamGame.cs - Basic Game Skeleton
 * 
 * Changes:
 * 0.01, 01-nov-2014: Initial version, drawing player 2, enemies, 
 *   allowing the user to move to the right
 */

using System;

namespace DamGame
{
    class Game
    {
        static void Main(string[] args)
        {
            bool fullScreen = false;
            SdlHardware.Init(1024, 768, 24, fullScreen);
            Font font18 = new Font("data/Joystix.ttf", 18);

            Image player = new Image("data/player.png");
            int playerX = 50;
            int playerY = 120;
            int playerSpeed = 4;
            int playerWidth = 32;
            int playerHeight = 64;

            Random rnd = new Random();
            int numEnemies = 2;
            int[] enemyX = new int[numEnemies];
            int[] enemyY = new int[numEnemies];
            int[] enemySpeedX = new int[numEnemies];
            for (int i = 0; i < numEnemies; i++)
            {
                enemyX[i] = rnd.Next(200, 800);
                enemyY[i] = rnd.Next(50, 600);
                enemySpeedX[i] = rnd.Next(1, 5);
            }
            int enemyWidth = 64;
            int enemyHeight = 64;
            Image enemy = new Image("data/enemy.png");

            bool finished = false;

            // Game Loop
            do
            {
                // Update screen
                SdlHardware.ClearScreen();

                SdlHardware.WriteHiddenText("Score: ",
                    40, 10,
                    0xCC, 0xCC, 0xCC,
                    font18);

                SdlHardware.DrawHiddenImage(player, playerX, playerY);
                for (int i = 0; i < numEnemies; i++)
                    SdlHardware.DrawHiddenImage(enemy, enemyX[i], enemyY[i]);
                SdlHardware.ShowHiddenScreen();


                // Check input by the user
                if (SdlHardware.KeyPressed(SdlHardware.KEY_RIGHT))
                    playerX += playerSpeed;
                // TO DO: Complete with remaining keys

                if (SdlHardware.KeyPressed(SdlHardware.KEY_ESC))
                    finished = true;

                // Move enemies, background, etc 
                // TO DO

                // Check collisions and apply game logic
                // TO DO

                // Pause till next frame (20 ms = 50 fps)
                SdlHardware.Pause(20);
            }
            while (!finished);
        }
    }
}
