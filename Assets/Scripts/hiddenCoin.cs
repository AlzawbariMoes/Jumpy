using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiddenCoin : MonoBehaviour {

    public GameObject HiddenCoin;
    private Collider2D col;
    private AudioSource audio;
    public AudioClip HiddenCoinSound;
    // Use this for initialization
    void Start ()
    {
        audio = GetComponent<AudioSource>();
        col = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
      private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            HiddenCoin.SetActive(true);
            Debug.Log("Hiddern Coin!!");
            col.enabled = !col.enabled;
            audio.PlayOneShot(HiddenCoinSound);
        }
    }
    
}
