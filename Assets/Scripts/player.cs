using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{

    public int score;
    public int lives;
    public int level;
    public bool caught;     //FLAG TO RESET POSITION WHEN PLAYER CAUGHT
    public bool win;        //FLAG WHEN PLAYER WINS
    public bool nextLevel;  //FLAG TO SIGNAL WHEN CHANGE TO NEXT LEVEL
    public bool end;        //FLAG TO SIGNAL WHEN GAME HAS ENDED

    public Vector3 currStartPos;                                    //HOLDS CURRENT LEVEL'S START POSITION
    public Vector3 startPos1 = new Vector3(167.0f, -23.5f, 33.0f);  //START POSITION FOR LEVEL 1
    public Vector3 startPos2 = new Vector3(-1.0f, -23.5f, 7.0f);    //START POSITION FOR LEVEL 2

    //SET PLAYER'S SPEED
    float speed = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        //INITIAL VALUES
        lives = 3;
        score = 0;
        level = 1;
        currStartPos = startPos1;

    }
    
    // Update is called once per frame
    void Update()
    {
        //KEEP UPDATING WHILE GAME HASN'T ENDED
        if (!end) 
        {
            //IF COLLECTED ALL COINS ON LEVEL
            if (nextLevel)     
            {
                level += 1;
                //SET NEXT LEVEL POSITION
                currStartPos = startPos2;
                transform.position = currStartPos;
                nextLevel = false;
            //IF PLAYER WINS
            }else if (win) {

                //END GAME
                end = true;

            //IF PLAYERS COLLIDES WITH ENEMY
            }else if (caught)  
            {
                //LOSE A LIFE
                lives -= 1;
                //SET TO DEFAULT POSITION
                transform.position = currStartPos;

                //IF PLAYER LOSES
                if (lives == 0)
                {
                    //END GAME
                    end = true;
                }

                caught = false;
            }

            //IF PRESSING ARROWS, MOVE PLAYER
            var v3 = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
            transform.Translate(speed * v3.normalized * Time.deltaTime);

        }
    }
}
