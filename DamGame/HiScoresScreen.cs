/// HiScoresScreen - A screen to display the high scores

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.03, 10-may-2018, Daniel Miquel, Pedro Coloma: AddNewHiScore
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 */
using System.Collections.Generic;

class HiScoresScreen
{
    
    struct Score
    {
        public string name;
        public int points;
    }

    private List<Score> hiScores = new List<Score>();
    
    public void Run()
    {
        
        Font font18 = new Font("data/Joystix.ttf", 18);
        SdlHardware.ClearScreen();

        SdlHardware.WriteHiddenText("Hi Scores...",
            40, 10,
            0x22, 0xFF, 0x22,
            font18);
        AddNewHiScore(50, "Pepe");
        AddNewHiScore(80, "Juan");
        AddNewHiScore(70, "Lolo");
        AddNewHiScore(30, "jojo");
        /*
        for (int i = 0; i < hiScores.Count; i++)
        {

            SdlHardware.WriteHiddenText(hiScores[i].name + " "
                + hiScores[i].points,
                40, (short)(15 + (i * 5)),
                0x22, 0xFF, 0x22,
                font18);

        }
        */
        
        SdlHardware.ShowHiddenScreen();
        SdlHardware.Pause(1000);
    }
    
    public void AddNewHiScore(int points, string name)
    {
        /*Score temp;
        temp.name = name;
        temp.points = points;
        hiScores.Add(temp);
        //hiScores.Sort();*/
    }
    
}