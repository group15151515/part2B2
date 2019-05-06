using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Female_Controller : MonoBehaviour
{
    [SerializeField]

    Vector3 forward, right;

    float speed;
    float rotSpeed = 80;
    float rot = 0f;
    float gravity = 5;

   private Vector3 moveDir = Vector3.zero;


    CharacterController controller;
    Animator anim;


    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
       
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            anim.SetInteger("condition", 1);
            speed = 2;
            moveDir = new Vector3(0, 0, 1);
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);

        }

        if (Input.GetKey(KeyCode.B))
        {
            anim.SetInteger("condition", 1);
            speed = 3;
            moveDir = new Vector3(0, 0, -1);
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);

        }

        if (Input.GetKey(KeyCode.R))
        {
            anim.SetInteger("condition", 2);
            speed = 4;
            moveDir = new Vector3(0, 0, 1);
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);

        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetInteger("condition", 3);
            moveDir = new Vector3(0, 10, 0);
            moveDir *= 1;
            moveDir = transform.TransformDirection(moveDir);
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Move();
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.R) || Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.B))
        {
            anim.SetInteger("condition", 0);
            moveDir = new Vector3(0, 0, 0);
        }

        
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontalkey"), 0, Input.GetAxis("Verticalkey"));
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontalkey");
        Vector3 upMovement = right * speed * Time.deltaTime * Input.GetAxis("Verticalkey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;

       
    }
}
