using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
	Player player;

	int amountOfCrates;


	Crate crate1;
	Crate crate2;

	public MyGame() : base(1920, 1080, false)
	{
		Player player = new Player(new Vec2(game.width / 2, 200), amountOfCrates);
		AddChild(player);


		ChargeBar PullChargeBar = new ChargeBar(player, true, 50, "barblue.png");
		AddChild(PullChargeBar);
		
		ChargeBar PushChargeBar = new ChargeBar(player, false, 100, "barred.png");
		AddChild(PushChargeBar);

		Platform platform = new Platform(player, new Vec2(250, 400));
		AddChild(platform);
		
		Platform platform2 = new Platform(player, new Vec2(700, 600));
		AddChild(platform2);

		crate1 = new Crate(player, new Vec2(450, -100));
		AddChild(crate1);

		crate2 = new Crate(player, new Vec2(700, -100));
		AddChild(crate2);

		PolaritySwitcher polarity = new PolaritySwitcher(player, 500, 500);
		AddChild(polarity);

		amountOfCrates = 2;

		player.crates = GetCrates();

	}

    void Update()
	{


	}



	public GameObject[] GetCrates()
    {

        /*		List<GameObject> crateList = new List<GameObject>();
                crateList.Add(crate1);
                crateList.Add(crate2);*/

        GameObject[] crateList = new GameObject[amountOfCrates];
		
		crateList[0] = crate1;
		crateList[1] = crate2;

		return crateList;
	}




	static void Main()
	{
		new MyGame().Start();
	}
}