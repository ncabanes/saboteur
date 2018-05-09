/// MenuScreen - The screen in which the user can choose to Play,
/// to see the Credits, Help and the High Scores

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 */

class MenuScreen
{
    public void Run()
    {
        Font font18 = new Font("data/Joystix.ttf", 18);
        SdlHardware.ClearScreen();

        SdlHardware.WriteHiddenText("Menu. Space bar to continue...",
            40, 10,
            0x22, 0x22, 0xFF,
            font18);

        SdlHardware.ShowHiddenScreen();
        do
        {
            SdlHardware.Pause(50);  // To avoid 100% CPU usage
        }
        while (!SdlHardware.KeyPressed(SdlHardware.KEY_SPC));
    }
}