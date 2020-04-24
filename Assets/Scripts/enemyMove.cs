using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float Speed;
	
	void Update ()
    {
        
        transform.position = new Vector3(transform.position.x - Speed, transform.position.y);
    }

}
