using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    private float verticalVelocity;
    private float gravity = 14.0f;
    private float jumpForce= 10.0f;
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
<<<<<<< HEAD
=======
   
>>>>>>> main
    private void Start()
    {
        controller= GetComponent<CharacterController>();

    }
    


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
<<<<<<< HEAD
=======
       
>>>>>>> main
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
<<<<<<< HEAD
            if(controller.isGrounded)
            {
                verticalVelocity=-gravity*Time.deltaTime;
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    verticalVelocity=jumpForce;
                }
            }
            else
            {
                verticalVelocity-=gravity*Time.deltaTime;
            }
            Vector3 moveVector=Vector3.zero;
            moveVector.x=Input.GetAxis("Horizontal")*5.0f;
            moveVector.y=verticalVelocity;
            moveVector.z=Input.GetAxis("Vertical")*5.0f;
            controller.Move(moveVector*Time.deltaTime);



        }
=======
            

        }

        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKey("space"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        Vector3 moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * 5.0f;
        moveVector.y = verticalVelocity;
        moveVector.z = Input.GetAxis("Vertical") * 5.0f;
        controller.Move(moveVector * Time.deltaTime);
>>>>>>> main
    }
}
