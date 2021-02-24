using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    public enemy currEnemy;
    public GameObject enemyObj;


    //ALL OPERATIONS TO BE DONE ON COLLSION WITH THE PLAYER

    //CALLED ON COLLISION WITH OTHER OBJECT
    void OnTriggerEnter(Collider obj)
    {
        //CHECK COLLISION IS WITH PLAYER
        if (obj.name == "player")
        {
            //INCREMENT SCORE
            player currPlayer = obj.GetComponent<player>();
            currPlayer.score += 1;

            //IF END OF LEVEL 1
            if (currPlayer.score == 5)
            {
                //TRIGGER NEXT LEVEL
                currPlayer.nextLevel = true;
                enemyObj = GameObject.Find("enemy2");
                currEnemy = enemyObj.GetComponent<enemy>();
                currEnemy.start = false;

            //IF END OF LEVEL 2
            } else if (currPlayer.score == 11)
            {
                //PLAYER WINS
                currPlayer.win = true;
            }

            //IF DURING LEVEL 2
            else if(currPlayer.score > 5)
            {
                enemyObj = GameObject.Find("enemy2");
                currEnemy = enemyObj.GetComponent<enemy>();
                //TRIGGER ENEMY PAUSE
                currEnemy.pause = true;
                currEnemy.counter = 0;

            }

            //IF DURING LEVEL 1
            else
            {
                enemyObj = GameObject.Find("enemy1");
                currEnemy = enemyObj.GetComponent<enemy>();
                //TRIGGER ENEMY PAUSE
                currEnemy.pause = true;
                currEnemy.counter = 0;
            }
            
            //DESTROY THIS COIN OBJECT
            Destroy(gameObject);
        }
    }
}
