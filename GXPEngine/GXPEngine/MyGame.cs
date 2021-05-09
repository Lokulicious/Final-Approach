using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
	Player player;

	public MyGame() : base(800, 600, false)
	{
		Player player = new Player(new Vec2(game.width / 2, 200));
		AddChild(player);


		ChargeBar PullChargeBar = new ChargeBar(player, true, 50, "barblue.png");
		AddChild(PullChargeBar);
		
		ChargeBar PushChargeBar = new ChargeBar(player, false, 100, "barred.png");
		AddChild(PushChargeBar);

		Platform platform = new Platform(player, new Vec2(250, 300));
		AddChild(platform);
		
		Platform platform2 = new Platform(player, new Vec2(600, 500));
		AddChild(platform2);

		Crate crate = new Crate(player, new Vec2(0, -100));
		AddChild(crate);

		Crate crate2 = new Crate(player, new Vec2(-250, -100));
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