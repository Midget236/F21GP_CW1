using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowd : MonoBehaviour
{
    
    public Rigidbody currCrowd;
    public player currPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        currCrowd = GetComponent<Rigidbody>();
        GameObject playerObj = GameObject.Find("player");
        currPlayer = playerObj.GetComponent<player>();
    }

    void OnTriggerEnter(Collider obj)
    {

        //IF PLAYER LOSES: STOP JUMPING
        if (currPlayer.lives == 0)
        {
            currCrowd.constraints = RigidbodyConstraints.FreezePosition;
        }
        //ELSE: JUMP ON LANDING
        else
        {
            Vector3 jumpVel = new Vector3(0.0f, 5.0f, 0.0f);
            currCrowd.velocity = currCrowd.velocity + jumpVel;
        }
    }
}
