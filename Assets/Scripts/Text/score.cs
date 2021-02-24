using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public player currPlayer;
    public int currScore;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("player");
        currPlayer = obj.GetComponent<player>();
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currScore = currPlayer.score;
        scoreText.text = "SCORE: " + currScore.ToString();

    }
}
