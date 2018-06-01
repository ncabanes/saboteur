/// HelpScreen - The Help Screen, of course ;-)

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.20, 01-jun-2018, Nacho: Help includes pause key (ESC)
 * 0.16, 30-may-2018, Nacho: "Saboteur" name included. 
 *      More compact help text. ESC to return
 * 0.07, 14-may-2018, Nacho: Retro/updated look changeable
 * 0.03, 11-may-2018, Nacho: keypress to return instead of timed pause
 * 0.02, 10-may-2018, López, Rebollo: display help
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 */

using System;
class HelpScreen
{
    Image background;
    Font font18;
    Font font32;

    public HelpScreen(bool retroLook)
    {
        if (retroLook)
        {
            background = new Image("data/imgRetro/menuBackground.png");
        }
        else
        {
            background = new Image("data/imgUpdated/menuBackground.png");
        }
        font18 = new Font("data/Joystix.ttf", 18);
        font32 = new Font("data/Joystix.ttf", 32);
    }
    
    public void Run()
    {
        short x = 100;
        short y = 100;

        SdlHardware.ClearScreen();
        SdlHardware.DrawHiddenImage(background, 0, 0);

        SdlHardware.WriteHiddenText("Saboteur",
            500, 80,
            0xff, 0x00, 0x00,
            font32);

        string[] texts = { 
        "Controls"," ",
        "KEYBOARD JOYSTICK        ACTION",
        "-------- --------------- ----------------------------------------",
        "UP       Joystick UP     CLIMB UP if on ladder, or KICK if still",
        "DOWN     Joystick DOWN   CLIMB DOWN if on ladder, or DUCK if still",
        "RIGHT    Joystick RIGHT  MOVE RIGHT,",
        "LEFT     Joystick LEFT   MOVE LEFT",
        "SPACE    Joystick FIRE   THROW/USE/TAKE object, or PUNCH if none",
        "ESC      (None)          Pause / Quit game",
        " ",
        "Press ESC to return..."};
        
        for (int i = 0; i < texts.Length; i++)
        {
            y += 25;
            SdlHardware.WriteHiddenText(texts[i],
                x, y,
                0xFF, 0xFA, 0x00,
                font18);
        }

        SdlHardware.ShowHiddenScreen();
        do
        {
            SdlHardware.Pause(50);  // To avoid 100% CPU usage
        }
        while (!SdlHardware.KeyPressed(SdlHardware.KEY_ESC));
    }
}