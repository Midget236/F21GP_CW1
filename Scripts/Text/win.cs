using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win : MonoBehaviour
{

    public player currPlayer;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("player");
        currPlayer = obj.GetComponent<player>();
        winText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currPlayer.win) {
            winText.text = "YOU WIN";
        }
    }
}
