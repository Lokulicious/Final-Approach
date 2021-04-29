using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{

	

	public MyGame() : base(800, 600, false)
	{
		Player player = new Player();
		AddChild(player);


		ChargeBar chargeBar = new ChargeBar(player);
		AddChild(chargeBar);

		Platform platform = new Platform(player, 250, 0);
		AddChild(platform);
		
		Platform platform2 = new Platform(player, -150, 100);
		AddChild(platform2);

		Crate crate = new Crate(player, 0, 0);
		AddChild(crate);

		Crate crate2 = new Crate(player, -250, 0);
		AddChild(crate2);
	}

    void Update()
	{

	}

	static void Main()
	{
		new MyGame().Start();
	}
}