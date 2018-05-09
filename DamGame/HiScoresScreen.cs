/// HiScoresScreen - A screen to display the high scores

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 */

class HiScoresScreen
{
    public void Run()
    {
        Font font18 = new Font("data/Joystix.ttf", 18);
        SdlHardware.ClearScreen();

        SdlHardware.WriteHiddenText("Hi Scores...",
            40, 10,
            0x22, 0xFF, 0x22,
            font18);

        SdlHardware.ShowHiddenScreen();
        SdlHardware.Pause(1000);
    }
}