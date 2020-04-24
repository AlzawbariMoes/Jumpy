using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclesGravity : MonoBehaviour
{
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(objectFalling());
        }
    }
    IEnumerator objectFalling()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("10 sec has passed..");
        rb.gravityScale = 1;
        rb.constraints = RigidbodyConstraints2D.None;
    }


}

