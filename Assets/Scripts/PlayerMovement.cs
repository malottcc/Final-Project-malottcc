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

    private Animator anim;

    private float jumpHeight = 10.0f;
    private bool groundedPlayer;

    public GameObject inGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
        anim = this.gameObject.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = transform.TransformDirection(Vector3.forward);

        //foward
        if (Input.GetAxis("Vertical") > 0)
        {
            controller.Move(moveDir * Time.deltaTime * playerMoveSpeed);
            anim.SetInteger("walk", 1);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                anim.SetBool("run", true);
                playerMoveSpeed = 10f;
            }
        }

        //backward
        else if (Input.GetAxis("Vertical") < 0)
        {
            controller.Move(-moveDir * Time.deltaTime * playerMoveSpeed);
            anim.SetInteger("walk", 1);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                anim.SetBool("run", true);
                playerMoveSpeed = 10f;
            }
        }
        else
        {
            anim.SetInteger("walk", 0);
            anim.SetBool("run", false);
            playerMoveSpeed = 5f;
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

        //jump
        groundedPlayer = controller.isGrounded;
        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            anim.SetTrigger("jump");
            anim.SetBool("falling", !groundedPlayer);

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inGameMenu.SetActive(true);
        }


        //gravity affects
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }


}