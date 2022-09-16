using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // assign relevant object that will be the player to the following variable
    // i.e. the tank in this case
    public GameObject player;
    public GameObject FPCamera;
    public GameObject TPCamera;
    private bool defaultMode;
    private bool cameraToggle;
    // Player camera offset
    private Quaternion cameraAngle = Quaternion.AngleAxis(18.75f, Vector3.right);
    private Vector3 TPOffset = new Vector3(0, 5.7f, -8);
    private Vector3 FPOffset = new Vector3(0, 4.15f, 1.15f);


    // Start is called before the first frame update
    void Start()
    {
        cameraToggle = false;
        defaultMode = true;
        FPCamera.SetActive(!defaultMode);
        TPCamera.SetActive(defaultMode);
        
        
    }

    // Update is called once per frame
    // LateUpdate is called every frame after Update is finished
    void LateUpdate()
    {
        cameraToggle = Input.GetButton("Jump");
        if (cameraToggle && defaultMode)
        {
            defaultMode = false;
            FPCamera.SetActive(!defaultMode);
            TPCamera.SetActive(defaultMode);
            
        }
        else if (cameraToggle && !defaultMode)
        {
            defaultMode = true;
            FPCamera.SetActive(!defaultMode);
            TPCamera.SetActive(defaultMode);
        }
        else
        {
            FPCamera.SetActive(!defaultMode);
            TPCamera.SetActive(defaultMode);
        }
            
        //position the camera relative to the player with an offset to view them from behind
        
        FPCamera.transform.position = player.transform.position + FPOffset;
        FPCamera.transform.rotation = cameraAngle;
        TPCamera.transform.position = player.transform.position + TPOffset;
        TPCamera.transform.rotation = cameraAngle;
    }
}
