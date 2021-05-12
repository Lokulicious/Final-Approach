using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using Physics;

class Level2 : GameObject
{
    int levelNumber;



    Background bg;

    
	Player player;



	Platform platform1;
	Platform platform2;
	Platform platform3;
	Platform platform4;
	Platform platform5;
	Platform platform6;
	Platform platform7;
	Platform platform8;
	Platform platform9;




	int amountOfCrates;
    Crate crate1;
    Crate crate2;
    Crate crate3;

	Crate doubleCrate1;


	public bool hasGenerated;

/*	DoubleCrate dcrate1;*/


    public Level2()
    {

		/*		GenerateLevel();*/
		hasGenerated = false;
		amountOfCrates = 3;

    }



	public void GenerateLevel()
    {
		//add bg
		Background bg = new Background("background_concept.png");
		AddChild(bg);

		//create player
		Player player = new Player(new Vec2(70, game.height - 80), amountOfCrates);


		//add floor
		Platform floor = new Platform(player, new Vec2(game.width / 2, game.height + 10f), 50, 1);
		AddChild(floor);


		//add platforms
/*		platform1 = new Platform(player, new Vec2(300, game.height - 200), 1f, 2f);
		AddChild(platform1);*/

		//add player
		AddChild(player);


		crate1 = new Crate(player, new Vec2(300, game.height - 300), "newcrate.png");
		crate2 = new Crate(player, new Vec2(600, game.height - 300), "newcrate.png");
		crate3 = new Crate(player, new Vec2(900, game.height - 300), "newcrate.png");
		AddChild(crate1);
		AddChild(crate2);
		AddChild(crate3);

		//add charge bar
		ChargeBar PushChargeBar = new ChargeBar(player, true);
		AddChild(PushChargeBar);

		player.crates = GetCrates();

		hasGenerated = true;
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
