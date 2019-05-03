using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Female_Controller : MonoBehaviour
{
    float walkspeed = 2;
    float runspeed = 4;
    float bwalkspeed = 3;
    float jumpspeed = 2;
    float rotSpeed = 80;
    float rot = 0f;
    float gravity = 5;

   private Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    void Start()
    {

        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

            if (Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("condition", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= walkspeed;
                moveDir = transform.TransformDirection(moveDir);

            }

            if (Input.GetKey(KeyCode.B))
            {
                anim.SetInteger("condition", 1);
                moveDir = new Vector3(0, 0, -1);
                moveDir *= bwalkspeed;
                moveDir = transform.TransformDirection(moveDir);

            }

            if (Input.GetKey(KeyCode.R))
            {
                anim.SetInteger("condition", 2);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= runspeed;
                moveDir = transform.TransformDirection(moveDir);

            }
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetInteger("condition", 3);
                moveDir = new Vector3(0, 4, 0);
                moveDir *= jumpspeed;
                moveDir = transform.TransformDirection(moveDir);
            }

            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.R)||Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.B))
            {
                anim.SetInteger("condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0,rot,0); 
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);

    }
}
