/// MenuScreen - The screen in which the user can choose to Play,
/// to see the Credits, Help and the High Scores

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.03, 10-may-2018, Victor, Gonzalo:
 *      Menu screen fully functional
 * 
 * 0.02, 09-may-2018, Victor, Miguel, Gonzalo: 
 *      Attributes and method GetChosenOption() added, but not finished
 *      Background image
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 */

class MenuScreen
{
    public enum MenuOption { Menu, Game, Help, Credits, Scores , Exit};
    private MenuOption chosenOption;

    public void Run()
    {
        chosenOption = MenuOption.Menu;
        Font font32 = new Font("data/Joystix.ttf", 32);
        Font font24 = new Font("data/Joystix.ttf", 24);
        Image background = new Image("data/imgRetro/menuBackground.png");
        SdlHardware.ClearScreen();
        SdlHardware.DrawHiddenImage(background, 0, 0);

        SdlHardware.WriteHiddenText("Saboteur",
            500, 80,
            0xff, 0x00, 0x00,
            font32);

        SdlHardware.WriteHiddenText("1. Start mission",
            500, 140,
            0xFF, 0xFA, 0x00,
            font24);

        SdlHardware.WriteHiddenText("2. Help",
            500, 180,
            0xFF, 0xFA, 0x00,
            font24);

        SdlHardware.WriteHiddenText("3. Credits",
            500, 220,
            0xFF, 0xFA, 0x00,
            font24);

        SdlHardware.WriteHiddenText("4. Hi-Scores",
            500, 260,
            0xFF, 0xFA, 0x00,
            font24);

        SdlHardware.WriteHiddenText("5. Quit",
            500, 300,
            0xFF, 0xFA, 0x00,
            font24);

        SdlHardware.ShowHiddenScreen();

        do
        {
            SdlHardware.Pause(50);  // To avoid 100% CPU usage

            if (SdlHardware.KeyPressed(SdlHardware.KEY_1))
            {
                chosenOption = MenuOption.Game;
            }
            else if (SdlHardware.KeyPressed(SdlHardware.KEY_2))
            {
                chosenOption = MenuOption.Help;
            }
            else if (SdlHardware.KeyPressed(SdlHardware.KEY_3))
            {
                chosenOption = MenuOption.Credits;
            }
            else if (SdlHardware.KeyPressed(SdlHardware.KEY_4))
            {
                chosenOption = MenuOption.Scores;
            }
            else if (SdlHardware.KeyPressed(SdlHardware.KEY_5))
            {
                chosenOption = MenuOption.Exit;
            }
        }
        while (chosenOption == MenuOption.Menu);
    }

    public MenuOption GetChosenOption()
    {
        return chosenOption;
    }
}