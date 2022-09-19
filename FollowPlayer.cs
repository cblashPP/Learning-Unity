using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// add this script as a component to the hierarchy containing your cameras
public class FollowPlayer : MonoBehaviour
{
    //In the GUI, add the relevant cameras and the player to the below public variables
    public GameObject player;
    public GameObject FPCamera;
    public GameObject TPCamera;

    //Default mode meaning third person 
    //purpose is to track what camera is currently active
    private bool defaultMode;
    // Tracks player input for camera change
    private bool cameraToggle;
    // To keep the camera from switching rapidly on input we'll detect if it has recently been pressed 
    private bool holdInput;
    // This will track how long the input has been blocked.
    private float holdTime;
    // Determined minimum buffer time between inputs, in seconds
    private const float INPUTBUFFER = 1;

    // Player camera offsets and angle
    private Quaternion cameraAngle = Quaternion.AngleAxis(18.75f, Vector3.right);
    private Vector3 TPOffset = new Vector3(0, 5.7f, -8);
    private Vector3 FPOffset = new Vector3(0, 4.15f, 1.15f);


    // Start is called before the first frame update
    void Start()
    {
        // assign initial values to tracking variables
        holdInput = false;
        cameraToggle = false;
        defaultMode = true;
        // set cameras, one will always have the opposite state of the other
        FPCamera.SetActive(!defaultMode);
        TPCamera.SetActive(defaultMode);
    }

    // Update is called once per frame
    // LateUpdate is called every frame after Update is finished
    void LateUpdate()
    {
        //Read in player input for jump, spacebar by default
        cameraToggle = Input.GetButton("Jump");
        //Check if the button is pressed, and if it wasn't recently pressed
        if (cameraToggle && !holdInput)
        {
            // set flag to block further changing of the camera
            holdInput = true;
            // set time since last press to zero
            holdTime = 0;
            // use helper function to update camera
            CameraUpdate();
        }
        // check if input is being blocked this frame
        if (holdInput)
        {
            //increment hold time by elapsed time since last frame update
            holdTime += Time.deltaTime;
            //once the hold time equals or exceeds the buffer constant, unflag input holding
            if (holdTime >= INPUTBUFFER)
            {
                holdInput = false;
            }
        }

        //position the two cameras in their respective spots
        FPCamera.transform.position = player.transform.position + FPOffset;
        FPCamera.transform.rotation = cameraAngle;
        TPCamera.transform.position = player.transform.position + TPOffset;
        TPCamera.transform.rotation = cameraAngle;
    }

    // Helper function to decide camera mode
    void CameraUpdate()
    {
        // if default is true (3rd person enabled) switch to 3rd person
        if (defaultMode)
        {
            defaultMode = false;
            FPCamera.SetActive(!defaultMode);
            TPCamera.SetActive(defaultMode);
        }
        // if not, swap back to default mode
        else
        {
            defaultMode = true;
            FPCamera.SetActive(!defaultMode);
            TPCamera.SetActive(defaultMode);
        }
    }
}
