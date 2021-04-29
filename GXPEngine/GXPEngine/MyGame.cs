using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
	Player player;

	public MyGame() : base(800, 600, false)
	{
		Player player = new Player();
		AddChild(player);


		ChargeBar PullChargeBar = new ChargeBar(player, true, 50, "barblue.png");
		AddChild(PullChargeBar);
		
		ChargeBar PushChargeBar = new ChargeBar(player, false, 100, "barred.png");
		AddChild(PushChargeBar);

		Platform platform = new Platform(player, 250, 0);
		AddChild(platform);
		
		Platform platform2 = new Platform(player, -150, 200);
		AddChild(platform2);

		Crate crate = new Crate(player, 0, 0);
		AddChild(crate);

		Crate crate2 = new Crate(player, -250, 0);
		AddChild(crate2);

		PolaritySwitcher polarity = new PolaritySwitcher(player, (game.width / 4) * 4, game.height / 2);
		AddChild(polarity);
	}

    void Update()
	{


	}

	static void Main()
	{
		new MyGame().Start();
	}
}