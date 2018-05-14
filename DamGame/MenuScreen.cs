/// MenuScreen - The screen in which the user can choose to Play,
/// to see the Credits, Help and the High Scores

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.07, 14-may-2018, Nacho:
 *      Menu data as an array: added option to change graphics quality
 *      (repetitive code to be fixed)
 * 0.03, 10-may-2018, Victor, Gonzalo:
 *      Menu screen fully functional
 * 0.02, 09-may-2018, Victor, Miguel, Gonzalo: 
 *      Attributes and method GetChosenOption() added, but not finished
 *      Background image
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 */

class MenuScreen
{
    public enum MenuOption { Menu, Game, Help, Credits, Scores , Exit};
    private MenuOption chosenOption;
    public bool RetroLook { get; set;  }

    public void Run()
    {
        chosenOption = MenuOption.Menu;
        Font font32 = new Font("data/Joystix.ttf", 32);
        Font font24 = new Font("data/Joystix.ttf", 24);
        Image background = new Image("data/imgRetro/menuBackground.png");
        RetroLook = true;

        SdlHardware.ClearScreen();
        SdlHardware.DrawHiddenImage(background, 0, 0);

        string[] options = {  "1. Start mission",
            "2. Help", "3. Credits","4. Hi-Scores",
            "5. Graphics: retro", "0. Quit" };

        SdlHardware.WriteHiddenText("Saboteur",
            500, 80,
            0xff, 0x00, 0x00,
            font32);
        for (int i = 0; i < options.Length; i++)
        {
            SdlHardware.WriteHiddenText(options[i],
            500, (short) (140+i*40),
            0xFF, 0xFA, 0x00,
            font24);
        }

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
                if (RetroLook)
                {
                    options[4] = "5. Graphics: updated";
                    RetroLook = false;
                    //background = new Image("data/imgUpdated/menuBackground.png");
                }
                else
                {
                    options[4] = "5. Graphics: retro";
                    RetroLook = true;
                    //background = new Image("data/imgRetro/menuBackground.png");
                }
                SdlHardware.ClearScreen();
                SdlHardware.DrawHiddenImage(background, 0, 0);
                SdlHardware.WriteHiddenText("Saboteur",
                    500, 80,
                    0xff, 0x00, 0x00,
                    font32);
                for (int i = 0; i < options.Length; i++)
                {
                    SdlHardware.WriteHiddenText(options[i],
                    500, (short)(140 + i * 40),
                    0xFF, 0xFA, 0x00,
                    font24);
                }
                SdlHardware.ShowHiddenScreen();
            }
            else if (SdlHardware.KeyPressed(SdlHardware.KEY_0))
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