using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float playerMoveSpeed = 5.0f;
    public float playerRotateSpeed = 50f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;

    // Start s called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = transform.TransformDirection(Vector3.forward);

        //foward
        if (Input.GetAxis("Vertical") > 0)
        {
            controller.Move(moveDir * Time.deltaTime * playerMoveSpeed);
           
        }

        //backward
        else if (Input.GetAxis("Vertical") < 0)
        {
            controller.Move(-moveDir * Time.deltaTime * playerMoveSpeed);
    
        }
      

        //rotate left
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * playerRotateSpeed);
        }

        //rotate right
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * playerRotateSpeed);
        }

        /*jump
        groundedPlayer = controller.isGrounded;
        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            anim.SetTrigger("jump");
            anim.SetBool("falling", !groundedPlayer);

        } */

        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            inGameMenu.SetActive(true);
        }*/


        //gravity affects
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }


}