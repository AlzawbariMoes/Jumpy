using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    
    //Destroies the coins when the player touches it....
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            ScoreText.CoinsAmount += 1;

            Destroy(gameObject);
 
        }


    }


}
