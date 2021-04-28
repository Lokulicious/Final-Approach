using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{

	

	public MyGame() : base(800, 600, false)
	{
		Player player = new Player();
		AddChild(player);

		Platform platform = new Platform(player);
		AddChild(platform);

		Crate crate = new Crate(player);
		AddChild(crate);
    }

    void Update()
	{

	}

	static void Main()
	{
		new MyGame().Start();
	}
}