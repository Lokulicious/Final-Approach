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

	Crate doubleCrate1;

/*	DoubleCrate dcrate1;*/


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
		Background bg = new Background("background_concept.png");
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
		crate1 = new Crate(player, new Vec2(450, -100), "squareanim.png");
		crate2 = new Crate(player, new Vec2(700, -100), "squareanim.png");
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
		Background bg = new Background("background_concept.png");
		AddChild(bg);

		//add player
		Player player = new Player(new Vec2(70, game.height - 80), amountOfCrates);
		


		//add floor
		Platform floor = new Platform(player, new Vec2(game.width / 2, game.height + 10f), 50, 1);
		AddChild(floor);

		//add platforms
		Platform platform1 = new Platform(player, new Vec2(310, game.height - 150), 5, 1);
		Platform platform2 = new Platform(player, new Vec2(640, game.height - 280), 6, 1);
		Platform platform3 = new Platform(player, new Vec2(550, game.height - 600), 2f, 1);
		Platform platform4 = new Platform(player, new Vec2(1000, game.height - 530), 3f, 1);
		Platform platform5 = new Platform(player, new Vec2(1350, game.height - 280), 4f, 1);
		Platform platform6 = new Platform(player, new Vec2(1400, game.height - 530), 1f, 0.7f);
		Platform platform7 = new Platform(player, new Vec2(1480, game.height - 575), 1f, 0.7f);
		Platform platform8 = new Platform(player, new Vec2(1530, game.height - 620), 1f, 0.7f);
		Platform platform9 = new Platform(player, new Vec2(1625	, game.height - 665), 2f, 0.7f);
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
		Platform wall1 = new Platform(player, new Vec2(740, game.height - 480), 0.7f, 3f);
		Platform wall2 = new Platform(player, new Vec2(1150, game.height - 600), 0.3f, 15f);
		AddChild(wall1);
		AddChild(wall2);


		//add crates
		crate1 = new Crate(player, new Vec2(770, game.height - 350), "newcrate.png");
		crate2 = new Crate(player, new Vec2(1050, game.height - 600), "newcrate.png");
		crate3 = new Crate(player, new Vec2(1350, game.height - 364), "newcrate.png");
		AddChild(crate1);
		AddChild(crate2);
		AddChild(crate3);


		//create double crates
		doubleCrate1 = new Crate(player, new Vec2(0, 0), "doublesquareanim.png");
/*        dcrate1 = new DoubleCrate(player, new Vec2(0, 0));*/

        //add polarity switch
        PolaritySwitcher ps = new PolaritySwitcher(player, 505, game.height - 683);
		AddChild(ps);


        //add goal
        Goal goal = new Goal(player, new Vec2(1625, game.height - 710));
        AddChild(goal);

		AddChild(player);

		//add charge bar
		ChargeBar PushChargeBar = new ChargeBar(player, true);
		AddChild(PushChargeBar);

		/*        Wall wall1 = new Wall(player, new Vec2(850, game.height - 500), 3);
                AddChild(wall1);*/

		amountOfCrates = 4;
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
		crateList[3] = doubleCrate1;


		return crateList;
	}


	void SwitchCrates()
    {
/*		crateList = new GameObject[amountOfCrates];
		crateList = GetCrates();*/

        foreach (Crate crate in player.crates)
        {
            if (crate.isTouchingCrate)
            {
				doubleCrate1 = new Crate(player, new Vec2(crate.x, crate.y), "doublesquareanim.png");
				AddChild(doubleCrate1);
				crate.LateDestroy();
			}
        }
	}



}
