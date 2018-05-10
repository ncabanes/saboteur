/// HiScoresScreen - A screen to display the high scores

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.03, 10-may-2018, Daniel Miquel, Pedro Coloma: AddNewHiScore
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton

 */
using System.Collections;

class HiScoresScreen
{
    protected SortedList hiScores = new SortedList();

    public void Run()
    {
        
        Font font18 = new Font("data/Joystix.ttf", 18);
        SdlHardware.ClearScreen();

        SdlHardware.WriteHiddenText("Hi Scores...",
            40, 10,
            0x22, 0xFF, 0x22,
            font18);
        for (int i = 0; i <= hiScores.Count; i++)
        {
            SdlHardware.WriteHiddenText(hiScores.GetKey(i)+" "
                +hiScores.GetByIndex(i),
                40,(short) (15+(i*5)),
                0x22, 0xFF, 0x22,
                font18);
        }
        SdlHardware.ShowHiddenScreen();
        SdlHardware.Pause(1000);
    }

    public void AddNewHiScore (int points, string name)
    {
        hiScores.Add(name, points);
    }
}