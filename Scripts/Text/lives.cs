using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lives : MonoBehaviour
{
    public player currPlayer;
    public int currLives;
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
        currLives = currPlayer.lives;
        livesText.text = "LIVES: " + currLives.ToString();
    }
}
