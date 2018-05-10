/// CreditsScreen - The Credits Screen, of course ;-)

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.03, 10-may-2018, Raul Gogna, Miguel Pastor, implement CreditsScreen
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 */

class CreditsScreen
{
    protected string[] names = { "Original game: Clive Townsend",
        "Raul Gogna",
        "Miguel Pastor","Angel Rebollo", "Almudena López", "Querubin Santana",
        "Marcos Cervantes", "Moisex Encinas", "Cesar Martin", "Daniel Miquel",
        "Gillermo Pastor", "Javier Cases", "Renata Pestena", "Brrandom Blasco",
        "Jose Vilaplana", "Gonzalo Martínez", "Miguel Garcia Gil",
        "Victor Tébar", "Luis Selles", "Miguel Puerta", "Iroquos Pliskin", "Javier Saorin",
        "Luis Martinez-Montalvo Giner", "Christian Cabrera Cerna",
        "Pedro Coloma", "Boss Project: Nacho Cabanes"};
    protected short yText = 40;
    public void Run()
    {
        Font font24 = new Font("data/Joystix.ttf", 24);
        Font font18 = new Font("data/Joystix.ttf", 18);
        Image background = new Image("data/imgRetro/menuBackground.png");
        SdlHardware.ClearScreen();
        SdlHardware.DrawHiddenImage(background, 0, 0);
        SdlHardware.WriteHiddenText("Credits",
            512, 10,
            0x20, 0xCC, 0x20,
            font24);
        for (int i = 0; i < names.Length; i++)
        {
            SdlHardware.WriteHiddenText(names[i],
            500, yText,
            0xCC, 0xCC, 0x00,
            font18);
            yText += 22;
        }
        SdlHardware.WriteHiddenText("Press Space to continue...",
            500, (short)(yText+15),
            0x00, 0xFF, 0x00,
            font18);
        SdlHardware.ShowHiddenScreen();
        do
        {
            SdlHardware.Pause(50);  // To avoid 100% CPU usage
        }
        while (!SdlHardware.KeyPressed(SdlHardware.KEY_SPC));
    }
}