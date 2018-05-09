/// MenuScreen - The screen in which the user can choose to Play,
/// to see the Credits, Help and the High Scores

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 * 0.02, 09-may-2018, Victor, Miguel, Gonzalo: Second version with attributes 
 * and method GetChosenOption() added.
 */

class MenuScreen
{
    public int OptionGame { get; set; }
    public int OptionHelp { get; set; }
    public int OptionCredits { get; set; }
    public int OptionHiScores { get; set; }

    public void Run()
    {
        Font font18 = new Font("data/Joystix.ttf", 18);
        SdlHardware.ClearScreen();

        SdlHardware.WriteHiddenText("Saboteur",
            40, 10,
            0x22, 0x22, 0xFF,
            font18);

        SdlHardware.WriteHiddenText("1. Start mission",
            40, 40,
            0xFF, 0xFA, 0x00,
            font18);

        SdlHardware.WriteHiddenText("2. Help",
            40, 60,
            0xFF, 0xFA, 0x00,
            font18);

        SdlHardware.WriteHiddenText("3. Credits",
            40, 80,
            0xFF, 0xFA, 0x00,
            font18);

        SdlHardware.WriteHiddenText("4. HiScores",
            40, 100,
            0xFF, 0xFA, 0x00,
            font18);

        SdlHardware.WriteHiddenText("Press Space to continue...",
            40, 120,
            0x22, 0x22, 0xFF,
            font18);

        SdlHardware.ShowHiddenScreen();
        do
        {
            SdlHardware.Pause(50);  // To avoid 100% CPU usage
        }
        while (!SdlHardware.KeyPressed(SdlHardware.KEY_SPC));
    }

    public int GetChosenOption(int num)
    {
        // TODO
        return 1;
    }
}