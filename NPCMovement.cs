using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    private float speed = 10;
    private Quaternion orientation = Quaternion.AngleAxis(180f, Vector3.up);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //turn the cars toward the player
        transform.rotation = orientation;
        //then move the cars forward to the player
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        
    }
}
