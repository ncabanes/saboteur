/// Saboteur - The main class, to launch the Menu, Game and other screens

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.01, 09-may-2018, Nacho: 
 *     First version, displays all screens in sequence
 */

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

        CreditsScreen credits = new CreditsScreen();
        credits.Run();

        HelpScreen help = new HelpScreen();
        help.Run();

        HiScoresScreen hiScores = new HiScoresScreen();
        hiScores.Run();

        MenuScreen menu = new MenuScreen();
        menu.Run();

        Game g = new Game();
        g.Run();
    }

    // -------

    static void Main(string[] args)
    {
        Saboteur s = new Saboteur();
        s.Run();
    }
}