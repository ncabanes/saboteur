/// Complex - Represents the whole building to be visited, 
/// consisting on a series of rooms

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.07, 14-may-2018, Nacho: Retro/updated look changeable
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton, only one room
 */


class Complex
{
    Room currentRoom;

    public Complex(bool retroLook)
    {
        currentRoom = new Room(retroLook);
    }

    public Room GetCurrentRoom()
    {
        return currentRoom;
    }
}
