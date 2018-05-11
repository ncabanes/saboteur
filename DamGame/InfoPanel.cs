/// InfoPanel - The panel in the lower part of the game screen, displaying
/// energy, time, items carried and so on

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.04. 11-may-2018, Nacho: Time & Pay are public, also Energy; 
 *      added framesPerTimeUnit
 * 0.03, 10-may-2018, Guillermo Pastor, Brandon Blasco, Javier Cases: 
 *      Animated;  Time & Pay
 * 0.01, 09-may-2018, Nacho: First version, empty skeleton
 */

class InfoPanel
{
    Image background;
    Font fontTime;
    Font fontPay;
    Font fontEnergy;

    int frame;
    int framesPerTimeUnit;

    public int Time { get; set; }
    public int Pay { get; set; }
    public int Energy { get; set; }

    public InfoPanel()
    {
        background = new Image("data/imgRetro/infoPanel.png");
        fontTime = new Font("data/Joystix.ttf", 46);
        fontPay = new Font("data/Joystix.ttf", 36);
        fontEnergy = new Font("data/Joystix.ttf", 40);
        Time = 90;
        Pay = 0;
        Energy = 100;
        frame = 1;
        framesPerTimeUnit = 400;  // 20 seconds at 20 fps
    }

    public void Draw()
    {
        SdlHardware.DrawHiddenImage(background, 0, 544);
        SdlHardware.WriteHiddenText(Time.ToString(), 733, 595,
            255, 255, 255, fontTime);
        SdlHardware.WriteHiddenText(Pay.ToString("0000000"), 470, 570,
            255, 255, 255, fontPay);
        // TO DO: Change for a decreasing bar
        SdlHardware.WriteHiddenText(Energy.ToString(), 420, 650,
            255, 255, 255, fontEnergy);
    }

    public void Animate()
    {
        frame++;
        if (frame > framesPerTimeUnit)
        {
            frame = 1;
            Time--;
        }
    }
}

