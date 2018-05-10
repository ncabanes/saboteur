/// InfoPanel - The panel in the lower part of the game screen, displaying
/// energy, time, items carried and so on

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.02, 10-may-2018, Guillermo Pastor, Brandon Blasco, Javier Cases: Animated Time
 * 0.01, 09-may-2018, Nacho: First version, empty skeleton
 */

class InfoPanel
{
    Image background;
    Font font;
    int time { get; set; }
    int frame;

    public InfoPanel()
    {
        background = new Image("data/imgRetro/infoPanel.png");
        font = new Font("data/Joystix.ttf", 46);
        time = 90;
        frame = 1;
    }

    public void Draw()
    {
        // TO DO: Fill with relevant information
        SdlHardware.DrawHiddenImage(background, 0, 544);
        SdlHardware.WriteHiddenText(time.ToString(), 735, 590, 255, 255, 255, font);
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

