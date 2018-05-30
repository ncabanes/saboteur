/// HiScoresScreen - A screen to display the high scores

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.16, 30-may-2018, Nacho: "Saboteur" name included. Background image.
 *      ESC to return
 * 0.07, 14-may-2018, Nacho: Retro/updated look changeable
 * 0.06, 12-may-2018, Nacho: 
 *      Error checking when writing and reading files
 *      New data are added to the data list
 *      All data are saved, instead of appending the new one
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
    Image background;
    Font font18;

    public HiScoresScreen(bool retroLook)
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
        Font font32 = new Font("data/Joystix.ttf", 32);
        SdlHardware.ClearScreen();
        SdlHardware.DrawHiddenImage(background, 0, 0);

        SdlHardware.WriteHiddenText("Saboteur",
            500, 80,
            0xff, 0x00, 0x00,
            font32);

        SdlHardware.WriteHiddenText("Hi Scores...",
            40, 10,
            0x22, 0xFF, 0x22,
            font18);
        
        AddNewHiScore(100, "Jose");
        AddNewHiScore(250, "dfg");
        AddNewHiScore(342, "asf");

        ReadHiScoreFile();

        for (int i = 0; i < hiScores.Count; i++)
        {
            SdlHardware.WriteHiddenText(hiScores[i].GetName() + " "
                + hiScores[i].GetPoints(),
                500, (short)(150 + (i * 20)),
                0x22, 0xFF, 0x22,
                font18);
        }

        SdlHardware.WriteHiddenText("Press ESC to return...",
            50, 600,
            0x00, 0xFF, 0x00,
            font18);

        SdlHardware.ShowHiddenScreen();
        do
        {
            SdlHardware.Pause(50);  // To avoid 100% CPU usage
        }
        while (!SdlHardware.KeyPressed(SdlHardware.KEY_ESC));
    }

    
    public void AddNewHiScore(int points, string name)
    {
        HiScore score = new HiScore(points, name);
        hiScores.Add(score);
        try
        {
            StreamWriter scores = new StreamWriter("HiScore.dat");
            for (int i = 0; i < hiScores.Count; i++)
                scores.WriteLine(hiScores[i].GetPoints() +
                    ":" + hiScores[i].GetName());
            scores.Close();
        }
        catch (Exception)
        {
            // TO DO: Warn the user?
        }
    }

    public void ReadHiScoreFile()
    {
        try
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
        catch (Exception)
        {
            // TO DO: Warn the user?
        }
    }
    

    public int CompareScore(HiScore s1, HiScore s2)
    {
        return s2.GetPoints() - s1.GetPoints();
    }
}