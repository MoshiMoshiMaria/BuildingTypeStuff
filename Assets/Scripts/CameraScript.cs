using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //Define variables
    Vector3 position;
    float xRot;
    float yRot;
    float zRot;
    Camera cameraObject;

    Vector3 lastMousePos;
    Vector3 deltaMousePos;

    // Start is called before the first frame update
    void Start()
    {
        //Initialise based on camera's current position
        cameraObject = gameObject.GetComponent<Camera>();
        position = cameraObject.transform.position;
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
        if (Input.GetKey(KeyCode.A))
        {
            position += gameObject.transform.right * -0.1f * Time.time;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position += gameObject.transform.right * 0.1f * Time.time;
        }
        if (Input.GetKey(KeyCode.W))
        {
            position += gameObject.transform.forward * 0.1f * Time.time;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position += gameObject.transform.forward * -0.1f * Time.time;
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

        lastMousePos = Input.mousePosition;
        //Update Camera
        gameObject.transform.position = position;
        gameObject.transform.rotation = Quaternion.Euler(0, yRot, 0);
        cameraObject.transform.rotation = Quaternion.Euler(xRot, 0, zRot);
    }
}
