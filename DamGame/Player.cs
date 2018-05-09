/// Player - The user-controlled character

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.01, 09-may-2018, Nacho: First version, empty skeleton
 * 0.02, 09-may-2018, Luis and Cesar: Second version, added attributes and methods to this class.
 */

namespace DamGame
{
    class Player : Sprite
    {
        protected int playerX = 50;
        protected int playerY = 120;
        protected int playerSpeed = 4;
        protected int playerWidth = 32;
        protected int playerHeight = 64;

        public Player()
        {

        }

        public Player(int playerX, int playerY, int playerSpeed,
            int playerWidth, int playerHeight)
        {
            this.playerX = playerX;
            this.playerY = playerY;
            this.playerSpeed = playerSpeed;
            this.playerWidth = playerWidth;
            this.playerHeight = playerHeight;
        }
        

        public static void MoveRight(int playerX, int playerSpeed)
        {
            playerX += playerSpeed;
        }

        public int GetPlayerX()
        {
            return playerX;
        }

        public void SetPlayerX(int playerX)
        {
            this.playerX = playerX;
        }

        public int GetPlayerY()
        {
            return playerY;
        }

        public void SetPlayerY(int playerY)
        {
            this.playerY = playerY;
        }

        public int GetPlayerSpeed()
        {
            return playerSpeed;
        }

        public void SetPlayerSpeed(int playerSpeed)
        {
            this.playerSpeed = playerSpeed;
        }

        public int GetPlayerWidth()
        {
            return playerWidth;
        }

        public void SetPlayerWidth(int playerWidth)
        {
            this.playerWidth = playerWidth;
        }

        public int GetPlayerHeight()
        {
            return playerHeight;
        }

        public void SetPlayerHeight(int playerHeight)
        {
            this.playerHeight = playerHeight;
        }
    }
}
