using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    Camera mycam;
    float sensitivity = 0.05f;
    Vector3 init;
    [SerializeField]
    public float speed = 10f;

    float WALK_SPEED = 40f;
    float RUN_SPEED = 90f;

    float mouseX;

    // Start is called before the first frame update
    void Start()
    {
        mycam = GetComponent<Camera>();
        init = transform.position;
        mouseX = Input.GetAxis("Mouse X");
    }

    // Update is called once per frame
    void Update()
    {
        // Cameara movemnet using mouse
        mouseX += Input.GetAxis("Mouse X") * 2f;
        if (mouseX < -360) mouseX = 360;
        if (mouseX > 360) mouseX = -360;
        //float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
        float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
        transform.localRotation = Quaternion.Euler(new Vector4(-1f * (mouseY * 180f), mouseX, transform.localRotation.z));
        Debug.Log("X = " + (mouseX) + " = "+ (-1f * (mouseY * 180f))+ " Mouse x = " + Input.mousePosition.x + "-- "+ Input.GetAxis("Mouse X"));


        //forward
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            GoForward(RUN_SPEED);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            GoForward(WALK_SPEED);
        }
        else
        {

        }

        //backward
        if (Input.GetKey(KeyCode.S))
        {
            GoBackward(WALK_SPEED);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            
        }

        //right
        if (Input.GetKey(KeyCode.D))
        {
            GoRight(WALK_SPEED);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {

        }

        //left
        if (Input.GetKey(KeyCode.A))
        {
            GoLeft(WALK_SPEED);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            
        }
        transform.position = new Vector3(transform.position.x, init.y, transform.position.z);

        /*
        Vector3 vp = mycam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mycam.nearClipPlane));
        vp.x -= 0.5f;
        vp.y -= 0.5f;
        vp.x *= sensitivity;
        vp.y *= sensitivity;
        vp.x += 0.5f;
        vp.y += 0.5f;
        Vector3 sp = mycam.ViewportToScreenPoint(vp);

        Vector3 v = mycam.ScreenToWorldPoint(sp);
        transform.LookAt(v, Vector3.up);
        */
    }

    void GoForward(float sp)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * sp);
    }
    
    void GoBackward(float sp)
    {
        transform.Translate(Vector3.back * Time.deltaTime * sp);
    }

    void GoLeft(float sp)
    {
        transform.Translate(Vector3.left * Time.deltaTime * sp);
    }

    void GoRight(float sp)
    {
        transform.Translate(Vector3.right * Time.deltaTime * sp);
    }
}
