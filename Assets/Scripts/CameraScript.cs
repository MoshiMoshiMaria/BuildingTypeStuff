using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //Define variables
    Vector3 position;//!<Position of the Camera/ParentObject
    float xRot;//!<X Rotation of the Camera
    float yRot;//!<Y Rotation of the Camera
    float zRot;//!<Z Rotation of the Camera - not currently used
    Camera cameraObject;//!<The Camera itself
    GameObject parent;//!<The parent object of the Camera

    [SerializeField]
    float heightMinClamp;//!<Minimum height of the Camera
    [SerializeField]
    float heightMaxClamp;//!<Maximum height of the Camera
    [SerializeField]
    float baseSpeed;//!<Speed at which the camera moves

    Vector3 lastMousePos;//!<Last known position of the mouse
    Vector3 deltaMousePos;//!<Difference between the last known mouse position and the current mouse position

    // Start is called before the first frame update
    void Start()
    {
        //Initialise based on camera's current position
        cameraObject = gameObject.GetComponent<Camera>();
        parent = gameObject.transform.parent.gameObject;
        position = parent.transform.position;
        xRot = cameraObject.transform.rotation.eulerAngles.x;
        yRot = cameraObject.transform.rotation.eulerAngles.y;
        zRot = cameraObject.transform.rotation.eulerAngles.z;

        lastMousePos = new Vector3(0,0);
        deltaMousePos = new Vector3(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs go here
        //Keyboard Keys
        if (Input.GetKey(KeyCode.A))
        {
            // Percentage across a range = ((input - min) * 100) / (max - min)
            // Inverse percentage = 1 - ((input - min) * 100) / (max - min))
            // 1.1 is used to ensure movement even at 100% (1) across the range (which would make the speed 0)
            float relativeSpeed = 1.1f - ((position.y - heightMinClamp) / (heightMaxClamp - heightMinClamp));
            if (Input.GetKey(KeyCode.LeftShift)) relativeSpeed *= position.y * 0.2f;
            position += parent.transform.right * -relativeSpeed * baseSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            float relativeSpeed = 1.1f - ((position.y - heightMinClamp) / (heightMaxClamp - heightMinClamp));
            if (Input.GetKey(KeyCode.LeftShift)) relativeSpeed *= position.y * 0.2f;
            position += parent.transform.right * relativeSpeed * baseSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            float relativeSpeed = 1.1f - ((position.y - heightMinClamp) / (heightMaxClamp - heightMinClamp));
            if (Input.GetKey(KeyCode.LeftShift)) relativeSpeed *= position.y * 0.2f;
            position += parent.transform.forward * relativeSpeed * baseSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            float relativeSpeed = 1.1f - ((position.y - heightMinClamp) / (heightMaxClamp - heightMinClamp));
            if (Input.GetKey(KeyCode.LeftShift)) relativeSpeed *= position.y *0.2f;
            position += parent.transform.forward * -relativeSpeed * baseSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            yRot += -0.1f * Time.time;
        }
        if (Input.GetKey(KeyCode.E))
        {
            yRot += 0.1f * Time.time;
        }
        //Middle Click
        if (Input.GetMouseButton(2))
        {
            deltaMousePos = Input.mousePosition;
            xRot -= deltaMousePos.y - lastMousePos.y;
            yRot += deltaMousePos.x - lastMousePos.x;
        }
        //Scroll Wheel
        Vector2 scrollDelta = Input.mouseScrollDelta;
        position.y -= scrollDelta.y;
        if (position.y < heightMinClamp) position.y = heightMinClamp;
        if (position.y > heightMaxClamp) position.y = heightMaxClamp;
        //Record known mouse position
        lastMousePos = Input.mousePosition;
        
        //Update Camera
        parent.transform.position = position;
        //Rotation of camera is separate from the parent object - need to be set separately
        parent.transform.rotation = Quaternion.Euler(0, yRot, 0);
        cameraObject.transform.rotation = Quaternion.Euler(xRot, yRot, zRot);
    }
}
