using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lose : MonoBehaviour
{
    public player currPlayer;
    public Text loseText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("player");
        currPlayer = obj.GetComponent<player>();
        loseText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currPlayer.lives==0)
        {
            loseText.text = "YOU LOSE";
        }
    }
}
