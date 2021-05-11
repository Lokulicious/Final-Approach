using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
	MainMenu mainMenu;

	Level level1;
	Level level2;



	public MyGame() : base(1920, 1080, false)
	{
		mainMenu = new MainMenu();
		AddChild(mainMenu);

        /*        level1 = new Level(1);
                AddChild(level1);
        */
/*        level2 = new Level(2);
        AddChild(level2);*/
        targetFps = 60;
		
		

    }

    void Update()
	{

		targetFps = 10;
	}



	static void Main()
	{
		new MyGame().Start();
	}
}