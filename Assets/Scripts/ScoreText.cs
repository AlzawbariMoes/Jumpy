using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
    // scores how many coins the player collected ...
    Text text;
    public static int CoinsAmount;
    public GameObject winningScene;
    public GameObject SoundtrackHolder;


    void Start ()
    {
        text = GetComponent<Text>();
        CoinsAmount = 0;
    }



    // Update is called once per frame
    void Update ()
    {

        text.text = CoinsAmount.ToString();

        if (CoinsAmount == 5)
        {
            winningScene.SetActive(true);
            SoundtrackHolder.SetActive(false);
        }
    }
}
