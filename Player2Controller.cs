using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    private const int WHEELCOUNT = 4;
    public GameObject[] wheel = new GameObject[WHEELCOUNT];
    private float speed = 15.0f;
    private float turnspeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Read input from player
        horizontalInput = Input.GetAxis("Horizontal2");
        forwardInput = Input.GetAxis("Vertical2");
        //Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Rotate the vehicle while it's moving to simulate turns    
        transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * horizontalInput);
        //Rotate the wheels when driving
        for (int i = 0; i < WHEELCOUNT; i++)
        {
            wheel[i].transform.Rotate(Vector3.right * Time.deltaTime * speed * forwardInput);
        }
    }
}
