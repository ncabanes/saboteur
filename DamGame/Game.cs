
/// Game.cs - Game logic for Saboteur

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.01, 09-may-2018: 
 *      Namespace removed
 *      Init moved to class Saboteur
 *      Added CurrentRoom, InfoPanel and a Dog
 * 0.00, 08-may-2018: Initial version, drawing player 2, enemies, 
 *      allowing the user to move to the right
 * 0.02, 08-may-2018: Convert the variables in atributes and put the game loop in a function
 *      Jose Vilaplana, Moises Encinas, Marcos Cervantes.
 */

using System;

class Game
{
    Complex complex;
    InfoPanel info;
    Dog dog;
    int playerX;
    int playerY;
    int playerSpeed;
    int playerWidth;
    int playerHeight;
    Image player;
    Font font18;
    int[] enemyX;
    int[] enemyY;
    int[] enemySpeedX;
    bool finished;
    Image enemy;
    int numEnemies;


    public void Run()
    {
        font18 = new Font("data/Joystix.ttf", 18);
        player = new Image("data/imgRetro/playerStaticr.png");
        playerX = 50;
        playerY = 120;
        playerSpeed = 4;
        playerWidth = 32;
        playerHeight = 64;

        Random rnd = new Random();
        numEnemies = 2;
        enemyX = new int[numEnemies];
        enemyY = new int[numEnemies];
        enemySpeedX = new int[numEnemies];
        for (int i = 0; i < numEnemies; i++)
        {
            enemyX[i] = rnd.Next(200, 800);
            enemyY[i] = rnd.Next(50, 600);
            enemySpeedX[i] = rnd.Next(1, 5);
        }
        int enemyWidth = 64;
        int enemyHeight = 64;
        enemy = new Image("data/imgRetro/enemyStatic.png");

        complex = new Complex();
        info = new InfoPanel();
        dog = new Dog();
        dog.MoveTo(400, 200);

        finished = false;

        // Game Loop
        MainLoop();
    }

    public void MainLoop()
    {
        do
        {
            // Update screen
            SdlHardware.ClearScreen();

            complex.GetCurrentRoom().Draw();
            info.Draw();
            dog.DrawOnHiddenScreen();

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
            dog.Move();

            // Check collisions and apply game logic
            // TO DO

            // Pause till next frame (20 ms = 50 fps)
            SdlHardware.Pause(20);
        }
        while (!finished);
    }
}

