using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiatePumbkin : MonoBehaviour
{
    public Rigidbody2D pumbkinPrefab;
    public Transform spawnPosition;
    private BoxCollider2D collider2d;
    public GameObject PumbkinSpawner;
    private void Start()
    {
        collider2d = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(InstantiatePumbkins());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
             collider2d.enabled = !collider2d;
        }
    }

    IEnumerator InstantiatePumbkins()
    {
        for(int i = 0; i < 3; i ++)
        {
             Rigidbody2D EnemyInstantiate;
            EnemyInstantiate = Instantiate(pumbkinPrefab, spawnPosition.position, spawnPosition.rotation) as Rigidbody2D;
            yield return new WaitForSeconds(3);
         }
        PumbkinSpawner.SetActive(false);

    }

}
