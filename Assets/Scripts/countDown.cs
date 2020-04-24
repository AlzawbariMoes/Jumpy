using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countDown : MonoBehaviour {

    public float timer = 60;
    public Text timerText;
    public GameObject losingScene;
    public GameObject LeftButton;
    public GameObject RightButton;
    public GameObject UpButton;
    public GameObject SoundtrackHolder;
 


    void Start ()
    {
        timerText = GetComponent<Text>();
     
    }


    void Update ()
    {
        AudioSource audio = GetComponent<AudioSource>();


        timer -= Time.deltaTime;
        timerText.text = timer.ToString("f0");

         

        if ( timer <= 0)
        {
            losingScene.SetActive(true);
               timer = 0;

            LeftButton.SetActive(false);
            UpButton.SetActive(false);
            RightButton.SetActive(false);
            SoundtrackHolder.SetActive(false);
             
 
            Time.timeScale = 0;
 
        }
    }
}
