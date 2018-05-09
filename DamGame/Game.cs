
/// Game.cs - Game logic for Saboteur

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.02, 08-may-2018, Jose Vilaplana, Moises Encinas, Marcos Cervantes: 
 *      Convert the variables in atributes and put the game loop in a function
 *      Uses class Player & Enemy
 * 0.01, 09-may-2018, Nacho: 
 *      Namespace removed
 *      Init moved to class Saboteur
 *      Added CurrentRoom, InfoPanel and a Dog
 * 0.00, 08-may-2018: Initial version, drawing player 2, enemies, 
 *      allowing the user to move to the right
 */

using System;

class Game
{
    Complex complex;
    InfoPanel info;
    Dog dog;
    Font font18;
    bool finished;
    Enemy[] enemies;
    int numEnemies;
    Player player;


    public void Run()
    {
        font18 = new Font("data/Joystix.ttf", 18);
        player = new Player();
        player.MoveTo(50, 120);

        Random rnd = new Random();
        numEnemies = 2;
        enemies = new Enemy[numEnemies];
        for (int i = 0; i < numEnemies; i++)
        {
            enemies[i] = new Enemy();
            enemies[i].MoveTo( rnd.Next(200, 800), 
                rnd.Next(50, 400));
            enemies[i].SetSpeed(rnd.Next(1, 5) , 0);
        }

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
            player.DrawOnHiddenScreen();
            for (int i = 0; i < numEnemies; i++)
                enemies[i].DrawOnHiddenScreen();
            SdlHardware.ShowHiddenScreen();


            // Check input by the user
            if (SdlHardware.KeyPressed(SdlHardware.KEY_RIGHT))
                player.MoveRight();
            if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT))
                player.MoveLeft();
            // TO DO: Complete with remaining keys

            if (SdlHardware.KeyPressed(SdlHardware.KEY_ESC))
                finished = true;

            // Move enemies, background, etc 
            // TO DO
            dog.Move();
            enemies[0].Move();

            // Check collisions and apply game logic
            // TO DO

            // Pause till next frame (20 ms = 50 fps)
            SdlHardware.Pause(20);
        }
        while (!finished);
    }
}

