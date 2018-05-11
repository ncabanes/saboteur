using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 0.04. 11-may-2018, Rebollo, Lopez:
 *       Added method move
 * 0.03, 10-may-2018, Jose Vilaplana, Moises Encinas, Marcos Cervantes, 
 * Almudena Lopez, Angel Rebollo: 
 * Create the clas ThrowableItem, the constructor and the method throw*/

class ThrowableItem : Sprite
{

    public ThrowableItem()
    {
    }

    public override void Move()
    {
        x += xSpeed;
    }
}

