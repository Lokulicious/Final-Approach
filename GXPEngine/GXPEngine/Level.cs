using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using Physics;

class Level : GameObject
{
    int levelNumber;



    Background bg;

    Player player;

    int amountOfCrates;
    Crate crate1;
    Crate crate2;
    Crate crate3;

    public Level(int _levelNumber)
    {
        levelNumber = _levelNumber;

        switch (levelNumber)
        {
			case 1:
				GenerateLevel1();
				break;
			case 2:
				GenerateLeve2();
				break;
			case 3:
				GenerateLeve3();
				break;
        }


    }



	void GenerateLevel1()
    {
		//add bg
		Background bg = new Background();
		AddChild(bg);

		//add player
		Player player = new Player(new Vec2(game.width / 2, 200), amountOfCrates);
		AddChild(player);

		//add charge bar
		ChargeBar PushChargeBar = new ChargeBar(player, true);
		AddChild(PushChargeBar);


		//add platforms
		Platform platform = new Platform(player, new Vec2(250, 400), 10, 1);
		Platform platform2 = new Platform(player, new Vec2(700, 600), 10, 1);
		AddChild(platform);
		AddChild(platform2);

		//add crates
		crate1 = new Crate(player, new Vec2(450, -100));
		crate2 = new Crate(player, new Vec2(700, -100));
		AddChild(crate1);
		AddChild(crate2);


		//add polarity switchers
		PolaritySwitcher polarity = new PolaritySwitcher(player, 1050, 500);
		AddChild(polarity);

		//crate array
		amountOfCrates = 2;
		player.crates = GetCrates();
	}


	void GenerateLeve2()
    {
		//add bg
		Background bg = new Background();
		AddChild(bg);

		//add player
		Player player = new Player(new Vec2(70, game.height - 80), amountOfCrates);
		AddChild(player);

		//add charge bar
		ChargeBar PushChargeBar = new ChargeBar(player, true);
		AddChild(PushChargeBar);

		//add floor
		Platform floor = new Platform(player, new Vec2(game.width / 2, game.height + 32), 50, 1);
		AddChild(floor);

		//add platforms
		Platform platform1 = new Platform(player, new Vec2(400, game.height - 150), 5, 1);
		Platform platform2 = new Platform(player, new Vec2(750, game.height - 300), 6, 1);
		Platform platform3 = new Platform(player, new Vec2(650, game.height - 650), 2f, 1);
		Platform platform4 = new Platform(player, new Vec2(1100, game.height - 550), 3f, 1);
		Platform platform5 = new Platform(player, new Vec2(1500, game.height - 300), 3f, 1);
		Platform platform6 = new Platform(player, new Vec2(1550, game.height - 490), 1f, 0.7f);
		Platform platform7 = new Platform(player, new Vec2(1614, game.height - 535), 1f, 0.7f);
		Platform platform8 = new Platform(player, new Vec2(1678, game.height - 580), 1f, 0.7f);
		Platform platform9 = new Platform(player, new Vec2(1774	, game.height - 625), 2f, 0.7f);
		AddChild(platform1);
		AddChild(platform2);
		AddChild(platform3);
		AddChild(platform4);
		AddChild(platform5);
		AddChild(platform6);
		AddChild(platform7);
		AddChild(platform8);
		AddChild(platform9);

		//add walls
		Platform wall1 = new Platform(player, new Vec2(850, game.height - 500), 0.7f, 2.5f);
		Platform wall2 = new Platform(player, new Vec2(1300, game.height - 600), 0.3f, 9f);
		AddChild(wall1);
		AddChild(wall2);


		//add crates
		crate1 = new Crate(player, new Vec2(850, game.height - 364));
		crate2 = new Crate(player, new Vec2(1150, game.height - 614));
		crate3 = new Crate(player, new Vec2(1450, game.height - 364));
		AddChild(crate1);
		AddChild(crate2);
		AddChild(crate3);


		//add polarity switch
		PolaritySwitcher ps = new PolaritySwitcher(player, 650, game.height - 714);
		AddChild(ps);


/*        Wall wall1 = new Wall(player, new Vec2(850, game.height - 500), 3);
        AddChild(wall1);*/

        amountOfCrates = 3;
        player.crates = GetCrates();
    }



	void GenerateLeve3()
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
		crateList[2] = crate3;

		return crateList;
	}

}
