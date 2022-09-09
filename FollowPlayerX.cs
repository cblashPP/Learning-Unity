using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = Vector3.right * 20f;
    //private Quaternion offsetRotation = Quaternion.AngleAxis(-90, Vector3.up);



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    // LateUpdate is called every frame after Update is finished

    void LateUpdate()
    {
        transform.position = plane.transform.position + offset;
        //transform.rotation = offsetRotation;
    }
}