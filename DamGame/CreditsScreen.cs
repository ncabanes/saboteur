/// CreditsScreen - The Credits Screen, of course ;-)

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.07, 14-may-2018, Nacho: Retro/updated look changeable
 * 0.06, 12-may-2018, Nacho: yText is reset; some code cleaning,
 *          names are displayed alphabetically: typos fixed
 * 0.05, 11-may-2018, Luis and Cesar: Half of the "Star wars" logic.
 * 0.03, 10-may-2018, Raul Gogna, Miguel Pastor, implement CreditsScreen
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 */

class CreditsScreen
{
    Image background;
    Font font18, font24;

    public CreditsScreen(bool retroLook)
    {
        if (retroLook)
        {
            background = new Image("data/imgRetro/menuBackground.png");
            font18 = new Font("data/Joystix.ttf", 18);
            font24 = new Font("data/Joystix.ttf", 24);
        }
        else
        {
            background = new Image("data/imgUpdated/menuBackground.png");
            font18 = new Font("data/VeraSansBold.ttf", 18);
            font24 = new Font("data/VeraSansBold.ttf", 24);
        }
    }
    protected string[] names = { "Original game: Clive Townsend",
        " ", "  Remakers:",
        "Brandon Blasco",
        "Javier Cases",
        "Marcos Cervantes",
        "Pedro Coloma",
        "Raul Gogna",
        "Moises Encinas",
        "Miguel Garcia Gil",
        "Almudena Lopez",
        "Cesar Martin",
        "Luis Martinez-Montalvo",
        "Gonzalo Martinez",
        "Daniel Miquel",
        "Guillermo Pastor",
        "Miguel Pastor",
        "Renata Pestana",
        "Angel Rebollo",
        "Querubin Santana",
        "Javier Saorin",
        "Luis Selles",
        "Victor Tebar", 
        "Jose Vilaplana",
        "  ", "Project Boss: Nacho Cabanes"};
    protected short yText = 40;
    protected short startY = 600;
    protected bool finished = false;
    protected bool nextName = false;
    public void Run()
    {
        /*
        Font font22 = new Font("data/Joystix.ttf", 22);
        Font font16 = new Font("data/Joystix.ttf", 16);
        Font font26 = new Font("data/Joystix.ttf", 26);
        Font font28 = new Font("data/Joystix.ttf", 28);
        Font font14 = new Font("data/Joystix.ttf", 14);
        */

        while (!finished)
        {
            nextName = false;

            SdlHardware.ClearScreen();
            SdlHardware.DrawHiddenImage(background, 0, 0);
            SdlHardware.WriteHiddenText("Credits",
                512, 10,
                0x20, 0xCC, 0x20,
                font24);
            yText = 40;
            for (int i = 0; i < names.Length; i++)
            {
                SdlHardware.WriteHiddenText(names[i],
                    500, (short)(startY + yText),
                    0xCC, 0xCC, 0x00,
                    font18);
                yText += 22;
            }

            SdlHardware.WriteHiddenText("Press Space to return...",
                10, (short)(yText + 15),
                0x00, 0xFF, 0x00,
                font18);
            SdlHardware.ShowHiddenScreen();

            SdlHardware.Pause(20);  // To avoid 100% CPU usage
            if (SdlHardware.KeyPressed(SdlHardware.KEY_SPC))
                finished = true;
            if (startY < -800)
                finished = true;

            startY -= 2;
        }
    }
}