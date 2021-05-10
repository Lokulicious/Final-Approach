using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{

	Level level1;
	Level level2;

	public MyGame() : base(1920, 1080, true)
	{

        /*        level1 = new Level(1);
                AddChild(level1);
        */
        level2 = new Level(2);
        AddChild(level2);
    }

    void Update()
	{


	}



	static void Main()
	{
		new MyGame().Start();
	}
}