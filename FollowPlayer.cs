using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // assign relevant object that will be the player to the following variable
    // i.e. the tank in this case
    private GameObject player;

    // Player camera offset
    private Vector3 offset = new Vector3(0, 5.7f, -8);


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    // LateUpdate is called every frame after Update is finished
    void LateUpdate()
    {
        //position the camera relative to the player with an offset to view them from behind
        transform.position = player.transform.position + offset;
    }
}
