using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumbkinsMove : MonoBehaviour {

    public float Speed;
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y-Speed, transform.position.z);
    }
}
