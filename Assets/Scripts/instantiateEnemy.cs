using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateEnemy : MonoBehaviour
{

    public Rigidbody2D enemyPrefab;
    public Transform spawnPosition;
    public bool enemyAwake = false;
    private AudioSource RocketShooting;

    private void Start()
    {
        RocketShooting = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(InstantiateRockets());
        }

        
    }

    IEnumerator InstantiateRockets()
    {
        for (int i = 0; i <= 4; i ++)
        {
            yield return new WaitForSeconds(2f);
            Rigidbody2D Enemyinstantiate;
            Enemyinstantiate = Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation) as Rigidbody2D;
            RocketShooting.Play();
         } 
    }
}
