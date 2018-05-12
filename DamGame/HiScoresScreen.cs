/// HiScoresScreen - A screen to display the high scores

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.05, 11-may-2018, Pedro Coloma, Miguel Pastor: 
 *      Save and read scores in files (no error checking)
 * 0.03, 10-may-2018, Daniel Miquel, Pedro Coloma: AddNewHiScore and CompareScore
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 */
using System;
using System.Collections.Generic;
using System.IO;

class HiScoresScreen
{
    protected List<HiScore> hiScores = new List<HiScore>();

    public void Run()
    {

        Font font18 = new Font("data/Joystix.ttf", 18);
        SdlHardware.ClearScreen();

        SdlHardware.WriteHiddenText("Hi Scores...",
            40, 10,
            0x22, 0xFF, 0x22,
            font18);
        /*
        AddNewHiScore(100, "Jose");
        AddNewHiScore(250, "dfg");
        AddNewHiScore(342, "asf");

        ReadHiScoreFile();
        */
        for (int i = 0; i < hiScores.Count; i++)
        {
            SdlHardware.WriteHiddenText(hiScores[i].GetName() + " "
                + hiScores[i].GetPoints(),
                40, (short)(30 + (i * 20)),
                0x22, 0xFF, 0x22,
                font18);
        }


        SdlHardware.ShowHiddenScreen();
        do
        {
            SdlHardware.Pause(50);  // To avoid 100% CPU usage
        }
        while (!SdlHardware.KeyPressed(SdlHardware.KEY_SPC));
    }

    /*
    public void AddNewHiScore(int points, string name)
    {
        StreamWriter scores = File.AppendText("HiScore.dat");
        scores.WriteLine(points + ":" + name);
        scores.Close();
    }

    public void ReadHiScoreFile()
    {
        StreamReader scores = new StreamReader("HiScore.dat");

        string line;
        string[] data;
        do
        {
            line = scores.ReadLine();
            if (line != null)
            {
                data = line.Split(':');
                HiScore score = new HiScore(Convert.ToInt32(data[0]), data[1]);
                hiScores.Add(score);
            }
        } while (line != null);
        scores.Close();

        hiScores.Sort(CompareScore);

    }
    */

    public int CompareScore(HiScore s1, HiScore s2)
    {
        return s2.GetPoints() - s1.GetPoints();
    }
}