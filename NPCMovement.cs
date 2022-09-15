using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    private float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the cars at a negative speed, thus moving them back toward the player
        transform.Translate(Vector3.forward * -(speed) * Time.deltaTime);
    }
}