/// InfoPanel - The panel in the lower part of the game screen, displaying
/// energy, time, items carried and so on

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.01, 09-may-2018, Nacho: First version, empty skeleton
 */

class InfoPanel
{
    Image background;

    public InfoPanel()
    {
        background = new Image("data/imgRetro/infoPanel.png");
    }

    public void Draw()
    {
        // TO DO: Fill with relevant information
        SdlHardware.DrawHiddenImage(background, 0, 544);
    }
}

