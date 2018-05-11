using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 0.04. 11-may-2018, Rebollo, Lopez:
 *      Load image
 */
class Brick : ThrowableItem
{

    public Brick()
    {
        xSpeed = 2;
        width = 34;
        height = 24;
        LoadImage("data/imgRetro/objTBrick.png");
    }
}

