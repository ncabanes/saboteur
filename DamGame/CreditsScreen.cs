/// CreditsScreen - The Credits Screen, of course ;-)

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 */

class CreditsScreen
{
    public void Run()
    {
        Font font24 = new Font("data/Joystix.ttf", 24);
        SdlHardware.ClearScreen();

        SdlHardware.WriteHiddenText("Credits...",
            40, 10,
            0xCC, 0xCC, 0x00,
            font24);

        SdlHardware.ShowHiddenScreen();
        SdlHardware.Pause(1000);
    }
}