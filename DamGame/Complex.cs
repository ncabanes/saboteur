/// Complex - Represents the whole building to be visited, 
/// consisting on a series of rooms

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton, only one room
 */


class Complex
{
    Room currentRoom;

    public Complex()
    {
        currentRoom = new Room();
    }

    public Room GetCurrentRoom()
    {
        return currentRoom;
    }
}
