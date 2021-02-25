using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour
{
    public player currPlayer;
    public Text resultText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("player");
        currPlayer = obj.GetComponent<player>();
        resultText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //IF PLAYER WINS
        if (currPlayer.win)
        {
            resultText.text = "YOU WIN";
        }
        //IF PLAYER LOSES
        else if (currPlayer.lives == 0)
        {
            resultText.text = "YOU LOSE";
        }
    }
}
