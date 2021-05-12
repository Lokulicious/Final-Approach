using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;


class MainMenu : GameObject
{
    //main menu
    Background menubg;
    PlayButton playButton;
    int menuState;


    //level selector
    Background levelSelectorbg1;
    Background levelSelectorbg2;
    Stage2Locked st2l;
    Stage1Select st1l;
    ArrowButton ab;

    LevelButton levelButton1;
    LevelButton levelButton2;
    
    int stage;

    bool isStarting;



    //levels
    Level level1;
    Level2 level2;

    //cursor
    Cursor cursor;

    public MainMenu()
    {
        GenerateMainMenu();
        /*LevelSelector();*/

        //add cursor
        cursor = new Cursor();
        AddChild(cursor);

        level1 = new Level();
        level2 = new Level2();

        stage = 1;
        menuState = 1;
        isStarting = false;
    }


    void Update()
    {
        CheckClick();

        switch (menuState)
        {
            case 1:
                GenerateMainMenu();
                break;
            case 2:
                LevelSelector();
                break;
        }


        StartGame();
    }


    void GenerateMainMenu()
    {
        //add menu bg
        menubg = new Background("menubg.jpg");
        AddChild(menubg);

        //add buttons
        playButton = new PlayButton(new Vec2(game.width / 2, game.height / 2 - 50));
        AddChild(playButton);
    }


    void DeleteMainMenu()
    {

    }

    //364, game.height / 2 - 100

    void LevelSelector()
    {
        switch (stage)
        {
            case 1:
                foreach (GameObject child in GetChildren())
                {
                    child.LateDestroy();
                }
                /*                RemoveChild(levelSelectorbg2);*/
                levelSelectorbg1 = new Background("Stage_1.png");
                ab = new ArrowButton(new Vec2(game.width - 100, game.height / 2), false);
                st1l = new Stage1Select(game.width / 2, game.height / 2);

                levelButton1 = new LevelButton(new Vec2(265, game.height / 2 - 175));
                levelButton2 = new LevelButton(new Vec2(500, game.height / 2 - 175));
                

                AddChild(levelSelectorbg1);
                AddChild(ab);
                AddChild(st1l);
                AddChild(levelButton1);
                AddChild(levelButton2);


                if (levelButton1.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
                {
                    isStarting = true;
                    stage = 3;
                }
                
                if (levelButton2.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
                {
                    isStarting = true;
                    stage = 4;
                }


                break;
            case 2:
                foreach (GameObject child in GetChildren())
                {
                    child.LateDestroy();
                }
                RemoveChild(levelSelectorbg1);
                levelSelectorbg2 = new Background("Stage_2.png");
                st2l = new Stage2Locked(new Vec2(game.width /2, game.height / 2));
                AddChild(levelSelectorbg2);
                AddChild(st2l);
                ab = new ArrowButton(new Vec2(100, game.height / 2), true);
                AddChild(ab);
                break;
            case 3:
/*                foreach (GameObject child in GetChildren())
                {
                    child.LateDestroy();
                }*/
/*                level2.LateDestroy();*/
                AddChild(level1);
                if (!level1.hasGenerated)
                {
                    level1.GenerateLeve2();
                }
                break;
            case 4:
                /*                level1.LateDestroy();*/
                AddChild(level2);
                if (!level2.hasGenerated)
                {
                    level2.GenerateLevel();
                }

                break;
        }


        if (ab.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
        {
            Console.WriteLine("arrowbuttonhover");
            if (stage == 1)
            {
                stage = 2;
                RemoveChild(levelSelectorbg1);
                RemoveChild(st1l);
            }
            else if (stage == 2)
            {
                stage = 1;
                RemoveChild(levelSelectorbg2);
                RemoveChild(st2l);
                RemoveChild(levelButton1);
                RemoveChild(levelButton2);
            }
        }

    }


    void CheckClick()
    {

        if (playButton.HitTestPoint(Input.mouseX, Input.mouseY))
        {
            Console.WriteLine("playbuttonhover");
            playButton.SetCycle(1, 1);
            if (Input.GetMouseButtonDown(0))
            {
                /*                StartGame();*/
                /*LevelSelector();*/
                menuState = 2;
                /*                LevelSelector();*/

            }
        }



    }


    
    void StartGame()
    {
        if (isStarting)
        {
            foreach (GameObject child in GetChildren())
            {
                child.LateDestroy();
            }
            /*            AddChild(level1);*/
            isStarting = false;
        }
    }




    

}
