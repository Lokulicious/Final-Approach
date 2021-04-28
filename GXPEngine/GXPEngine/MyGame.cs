using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{

	

	public MyGame() : base(800, 600, false)
	{
		Player player = new Player();
		AddChild(player);
		Platform platform = new Platform();
		AddChild(platform);
    }

    void Update()
	{

	}

	static void Main()
	{
		new MyGame().Start();
	}
}