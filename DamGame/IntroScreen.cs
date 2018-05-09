/// IntroScreen - The screen shown for a when the game is launched

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 * 0.02  09-may-2018, Luis Martin, Renata, Miguel Pastor: background screen displayer
 */

class IntroScreen
{
    public void Run()
    {
        Font font18 = new Font("data/Joystix.ttf", 18);
        SdlHardware.ClearScreen();
        Image background;

        background = new Image("data/imgRetro/infoPanel.png");
        SdlHardware.DrawHiddenImage(background, 0, 544);
        SdlHardware.WriteHiddenText("Intro...",
            40, 10,
            0xCC, 0xCC, 0xCC,
            font18);

        SdlHardware.ShowHiddenScreen();
        SdlHardware.Pause(3000);
    }
}
