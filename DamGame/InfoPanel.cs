/// InfoPanel - The panel in the lower part of the game screen, displaying
/// energy, time, items carried and so on

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.02, 10-may-2018, Guillermo Pastor, Brandon Blasco, Javier Cases: Animated
 *   Time & Pay
 * 0.01, 09-may-2018, Nacho: First version, empty skeleton
 */

class InfoPanel
{
    Image background;
    Font fontTime;
    Font fontPay;
    int time { get; set; }
    int pay { get; set; }
    int frame;

    public InfoPanel()
    {
        background = new Image("data/imgRetro/infoPanel.png");
        fontTime = new Font("data/Joystix.ttf", 46);
        fontPay = new Font("data/Joystix.ttf", 36);
        time = 90;
        pay = 0;
        frame = 1;
    }

    public void Draw()
    {
        // TO DO: Fill with relevant information
        SdlHardware.DrawHiddenImage(background, 0, 544);
        SdlHardware.WriteHiddenText(time.ToString(), 733, 595,
            255, 255, 255, fontTime);
        SdlHardware.WriteHiddenText(pay.ToString("0000000"), 470, 570,
            255, 255, 255, fontPay);

    }

    public void Animated()
    {
        frame++;
        if (frame > 20)
        {
            frame = 1;
            time--;
        }
    }
}

