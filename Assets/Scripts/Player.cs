using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;
    public float jumpGravity;
    public Animator anim;
    public float rotateSpeed = 0f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, moveDirection.y, moveDirection.z);
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W))
            {
                moveDirection.y = jumpForce ;
                moveDirection.y = moveDirection.y + (Physics.gravity.y * (jumpGravity ) * Time.deltaTime);
            }
        } else
        {
            moveDirection.y = moveDirection.y + (Physics.gravity.y * (jumpGravity) * Time.deltaTime);
        }

        //turn character
        if (moveDirection.x >0.1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * rotateSpeed);
        }
        if (moveDirection.x < -0.1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 270, 0), Time.deltaTime * rotateSpeed);

        }

        //dance
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("Dance");
        }


        //moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime );

        moveDirection.z = 0 - controller.transform.position.z;
        controller.Move(moveDirection * Time.deltaTime);

        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal"))));
    }
}
