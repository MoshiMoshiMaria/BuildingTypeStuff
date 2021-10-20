using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Camera cameraObject;//!<Camera from which rays will be cast

    [SerializeField]
    LayerMask interactableMask;//!<The layer on which interactable objects will be on

    float timeMouseDown;//!<The time when the mouse button goes down
    Vector3 mouseDownPosition;//!<The position in which the mouse went down

    // Start is called before the first frame update
    void Start()
    {
        cameraObject = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Left Click
        if (Input.GetMouseButton(0))
        {
            Ray ray = cameraObject.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, Mathf.Infinity, interactableMask);
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);
        }
        //Right Click
        if (Input.GetMouseButton(1))
        {
            Ray ray = cameraObject.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, Mathf.Infinity, interactableMask);
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.blue);
        }
    }
}
