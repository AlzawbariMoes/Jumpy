using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

     void Start()
    {
        //calculate & store the value by getting the distance btwn the plater position and camera's position
        offset = transform.position - player.transform.position;

     }
    // called after update each frame...
     void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
