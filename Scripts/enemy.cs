using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{

    public NavMeshAgent agent;
    player currPlayer;
    public Vector3 currStartPos;    //HOLDS THIS ENEMY'S START POSITION
    public bool caught;             //FLAG TO RESET POSITION
    public int counter;             //USED FOR PAUSES
    public bool start;              //FLAG FOR WHEN ENEMY TO MOVE AFTER RESTART
    public bool pause;              //FLAG FOR WHEN ENEMY TO MOVE AFTER COIN COLLECTION


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject playerObj = GameObject.Find("player");
        currPlayer = playerObj.GetComponent<player>();

        //SET START POSITION
        currStartPos = transform.position;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //IF PLAYER WINS
        if (currPlayer.win)
        {
            transform.position = new Vector3(transform.position.x, -23.62f, transform.position.z);
            agent.SetDestination(transform.position);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x + 90, transform.eulerAngles.y, transform.eulerAngles.z);

        //IF PLAYER LOSES
        }else if (currPlayer.lives==0)
        {
            agent.SetDestination(transform.position);

        //IF PLAYER IS CAUGHT
        }else if (caught)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            agent.SetDestination(currStartPos);
            transform.position = currStartPos;
            caught = false;
            start = false;

        //IF WAITING TO START MOVING
        } else if (!start)
        {
            if (counter == 1000)
            {
                start = true;
                counter = 0;
            }
            else
            {
                counter += 1;
                transform.position = currStartPos;
            }

        //IF PAUSED DUE TO COIN COLLECTION
        }else if (pause)
        {
            
            if (counter == 250)
            {
                pause = false;
                counter = 0;
            }
            else
            {
                counter += 1;
                agent.SetDestination(transform.position);
            }
        }

        //ELSE: CHASE PLAYER
        else
        {
             agent.SetDestination(currPlayer.transform.position);
        }

    }

    //WHEN PLAYER IS CAUGHT
    void OnTriggerEnter(Collider obj)
    {
        if (obj.name == "player")
        {
            currPlayer.caught = true;
            caught = true;
        }
    }
}
