/// Game.cs - Game logic for Saboteur

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.09b,18-may-2018, Nacho: Player can climb side stairs (to the right)
 * 0.09, 18-may-2018, Nacho: Player.Move receives the room, to check gravity
 * 0.08, 17-may-2018, Nacho: 
 *      Collisions with the room are checked when moving right
 *      Cheat mode to get full energy again (keys C+E)
 * 0.07, 14-may-2018, Nacho: Retro/updated look changeable
 * 0.06, 12-may-2018, Nacho: room can be switched
 * 0.05. 11-may-2018, Rebollo, Lopez: Added shuriken
 * 0.04. 11-may-2018, Nacho: 
 *      Simple collisions with the dog
 *      InfoPanel is animated to display energy and time
 * 0.03, 10-may-2018, Jose Vilaplana, Moises Encinas, Marcos Cervantes: 
 *      Split in function and implement player up, down move and fire check.
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
    Shuriken weapon;
    bool retroLook;

    public Game(bool retroLook)
    {
        this.retroLook = retroLook;
    }

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

        complex = new Complex(retroLook);
        info = new InfoPanel();
        dog = new Dog();
        dog.MoveTo(400, 200);

        finished = false;
        weapon = null;

        // Game Loop
        MainLoop();
    }

    public void MainLoop()
    {
        do
        {
            // Update screen
            drawElements();

            // Check input by the user
            checkInput();

            // Move enemies, background, etc 
            moveElements();

            // Check collisions and apply game logic
            checkCollisions();

            // Pause till next frame (20 ms = 50 fps)
            pauseTillNextFrame(20);
            
        }
        while (!finished);
    }

    private void checkCollisions()
    {
        //TO DO: Complete with elements in a room
        if (player.CollisionsWith(dog))
            info.Energy--;

        if ((info.Energy == 0) || (info.Time == 0))
            finished = true;
    }

    private void pauseTillNextFrame(int ms)
    {
        SdlHardware.Pause(ms);
    }

    private void moveElements()
    {
        // TO DO: Animate all elements in a Room
        dog.Move();
        enemies[0].Move();
        info.Animate();
        player.Move(complex.GetCurrentRoom());
        if (weapon != null)
            weapon.Move();
    }

    private void checkInput()
    {
        if (SdlHardware.KeyPressed(SdlHardware.KEY_RIGHT))
        {
            // TO DO: Simplify code and move to another function
            if (complex.GetCurrentRoom().CanMoveTo(
                    player.GetX() + player.GetSpeedX(),
                    player.GetY(),
                    player.GetX() + player.GetSpeedX() + player.GetWidth(),
                    player.GetY() + player.GetHeight())
                    )
            {
                player.MoveRight();
            }
            else
            {
                if (complex.GetCurrentRoom().CanMoveTo(
                        player.GetX() + player.GetSpeedX(),
                        player.GetY() - 32,
                        player.GetX() + player.GetSpeedX() + player.GetWidth(),
                        player.GetY() + player.GetHeight() - 32)
                    )
                {
                    player.MoveTo(player.GetX(), player.GetY() - 32);
                    player.MoveRight();
                }
            }
           
            int nextRoom = complex.GetCurrentRoom().CheckIfNewRoom(player);
            if (nextRoom != -1)
            {
                complex.GetCurrentRoom().LoadRoom(nextRoom);
                player.MoveTo(0, player.GetY());
            }
        }

        if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT))
        {
            player.MoveLeft();
            int nextRoom = complex.GetCurrentRoom().CheckIfNewRoom(player);
            if (nextRoom != -1)
            {
                complex.GetCurrentRoom().LoadRoom(nextRoom);
                player.MoveTo(1024-player.GetWidth(), player.GetY());
            }
        }
        if (SdlHardware.KeyPressed(SdlHardware.KEY_SPC))
        {
            weapon = new Shuriken();
            weapon.MoveTo(player.GetX() + 40, player.GetY() + 40);
        }
        if (SdlHardware.KeyPressed(SdlHardware.KEY_UP))
            player.Jump();
        if (SdlHardware.KeyPressed(SdlHardware.KEY_DOWN))
            player.Duck();
        if (SdlHardware.KeyPressed(SdlHardware.KEY_ESC))
            finished = true;
        // Cheat 1: C+E to get full energy
        if (SdlHardware.KeyPressed(SdlHardware.KEY_C)
            && SdlHardware.KeyPressed(SdlHardware.KEY_E))
            info.Energy = 100;
    }

    private void drawElements()
    {
        SdlHardware.ClearScreen();

        complex.GetCurrentRoom().Draw();
        info.Draw();
        dog.DrawOnHiddenScreen();
        player.DrawOnHiddenScreen();
        if(weapon != null)
            weapon.DrawOnHiddenScreen();
        for (int i = 0; i < numEnemies; i++)
            enemies[i].DrawOnHiddenScreen();
        SdlHardware.ShowHiddenScreen();
    }
}

