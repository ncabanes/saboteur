﻿/// Dog - One of the (harmful) moving items in the game

/* Part of Saboteur Remake
 * 
 * Changes:
 * 0.01, 09-may-2018, Nacho: First version, almost empty skeleton
 * 0.02. 09-may-2018, López, Rebollo: Implemented movement and sprites
  */

class Dog : Sprite
{
    int frame;

    public Dog()
    {
        frame = 1;
        LoadSequence(RIGHT,
            new string[] { "data/imgRetro/dog1r.png",
                "data/imgRetro/dog2r.png",
                "data/imgRetro/dog3r.png"});

        LoadSequence(LEFT,
            new string[] { "data/imgRetro/dog1l.png",
                "data/imgRetro/dog2l.png",
                "data/imgRetro/dog3l.png"});

        currentDirection = RIGHT;
        width = 128;
        height = 80;
        xSpeed = 2;
    }

    public override void Move()
    {
        x += xSpeed;
        frame++;
        if( frame > 10)
        {
            NextFrame();
            frame = 1;
        }
        
    }
}