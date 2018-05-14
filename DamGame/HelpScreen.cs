/// HelpScreen - The Help Screen, of course ;-)

/* Part of Saboteur Remake
 * 
 * Changes:
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

    public HelpScreen(bool retroLook)
    {
        if (retroLook)
        {
            background = new Image("data/imgRetro/menuBackground.png");
            font18 = new Font("data/Joystix.ttf", 18);
        }
        else
        {
            background = new Image("data/imgUpdated/menuBackground.png");
            font18 = new Font("data/VeraSansBold.ttf", 18);
        }
    }
    
    public void Run()
    {
        short x = 100;
        short y = 100;

        string[] texts = { "Controls: "," ","-----------------"," ","UP - Jump/climb up",
        "DOWN - Duck/climb down", "LEFT - Walk left","RIGHT - walk right",
        "FIRE - Throw/pickup object", " ",
        "Standard Controls:"," ","-----------------"," ",
        "A       Joystick UP     CLIMB UP if on ladder, or KICK if still",
        "Z       Joystick DOWN   CLIMB DOWN if on ladder, or DUCK if still",
        "M       Joystick RIGHT  MOVE RIGHT,",
        "N       Joystick LEFT   MOVE LEFT",
        "SPACE   Joystick FIRE   THROW/USE/TAKE object, or PUNCH if none",
        " ",
        "Press space to return..."};

        SdlHardware.ClearScreen();
        SdlHardware.DrawHiddenImage(background, 0, 0);
        
        for (int i = 0; i < texts.Length; i++)
        {
            y += 20;
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
        while (!SdlHardware.KeyPressed(SdlHardware.KEY_SPC));
    }
}