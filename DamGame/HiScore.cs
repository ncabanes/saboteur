/// HiScores

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.03, 10-may-2018, Daniel Miquel, Pedro Coloma: Crete class HiScore
 */

class HiScore
{
    protected int points;
    protected string name;

    public HiScore(int points, string name)
    {
        this.points = points;
        this.name = name;
    }

    public int GetPoints()
    {
        return points;
    }

    public void SetPoints(int p)
    {
        points = p;
    }

    public string GetName()
    {
        return name;
    }

    public void SetName(string n)
    {
        name = n;
    }
}

