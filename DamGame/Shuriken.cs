using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 0.04. 11-may-2018, Rebollo, Lopez:
 *      Load image
 * 0.03, 10-may-2018, Jose Vilaplana, Moises Encinas, Marcos Cervantes, 
 * Almudena Lopez, Angel Rebollo: 
 * Create the clas Shuriken and the constructor*/

class Shuriken : ThrowableItem
{
    public Shuriken()
    {
        xSpeed = 3;
        width = 28;
        height = 30;
        LoadImage("data/imgRetro/objTShuriken.png");
    }
}

