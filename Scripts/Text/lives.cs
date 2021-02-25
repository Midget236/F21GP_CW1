using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lives : MonoBehaviour
{
    public player currPlayer;
    public Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("player");
        currPlayer = obj.GetComponent<player>();
        livesText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //DISPLAY PLAYER'S LIVES
        livesText.text = "LIVES: " + currPlayer.lives.ToString();
    }
}
