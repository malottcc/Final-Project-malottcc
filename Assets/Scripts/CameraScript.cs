using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public float mouseSensitivity = 250f;
    public Transform player;

    private float xRotationCamera = 0f;


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        //get mouse movements
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //up and down
        player.Rotate(Vector3.up * mouseX);


        //left and right
        xRotationCamera -= mouseY;
        xRotationCamera = Mathf.Clamp(xRotationCamera, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotationCamera, 0f, 0f);


    }
}

