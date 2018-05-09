/// HelpScreen - The Help Screen, of course ;-)

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 */

using System;
class HelpScreen
{
    public void Run()
    {
        Font font18 = new Font("data/Joystix.ttf", 18);
        SdlHardware.ClearScreen();

        SdlHardware.WriteHiddenText("Help...",
            40, 10,
            0x22, 0x22, 0xFF,
            font18);

        SdlHardware.ShowHiddenScreen();
        SdlHardware.Pause(1000);
    }
}