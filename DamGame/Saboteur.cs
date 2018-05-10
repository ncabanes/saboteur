
/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.03, 10-may-2018 Victor,Gonzalo:
 *     Displays the intro screen and menu screen.
 *     Lets the user choose the screen.
 * 
 * 0.01, 09-may-2018, Nacho: 
 *     First version, displays all screens in sequence
 */

/// Saboteur - The main class, to launch the Menu, Game and other screens
class Saboteur
{
    public Saboteur()
    {
        bool fullScreen = false;
        SdlHardware.Init(1024, 768, 24, fullScreen);
    }

    public void Run()
    {
        // TO DO: Create a real Menu, instead of showing all the screens

        IntroScreen intro = new IntroScreen();
        intro.Run();

        MenuScreen menu = new MenuScreen(); 

        do
        {
            menu.Run();
            switch (menu.GetChosenOption())
            {
                case MenuScreen.MenuOption.Game:
                    Game g = new Game();
                    g.Run();
                    break;

                case MenuScreen.MenuOption.Help:
                    HelpScreen help = new HelpScreen();
                    help.Run();
                    break;

                case MenuScreen.MenuOption.Credits:
                    CreditsScreen credits = new CreditsScreen();
                    credits.Run();
                    break;

                case MenuScreen.MenuOption.Scores:
                    HiScoresScreen hiScores = new HiScoresScreen();
                    hiScores.Run();
                    break;
            }
        } while (menu.GetChosenOption() != MenuScreen.MenuOption.Exit);
    }

    // -------

    static void Main(string[] args)
    {
        Saboteur s = new Saboteur();
        s.Run();
    }
}