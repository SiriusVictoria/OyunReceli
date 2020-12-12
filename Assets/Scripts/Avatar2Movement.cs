using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar2Movement : MonoBehaviour
{
    private float verticalVelocity2;
    private float gravity2 = 14.0f;
    private float jumpForce2 = 10.0f;
    public CharacterController controller;
    public Transform cam;
    public float speed2 = 6f;
    public float turnSmoothTime2 = 0.1f;
    float turnSmoothVelocity2;
 
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
       
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity2, turnSmoothTime2);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed2 * Time.deltaTime);


        }

        if (controller.isGrounded)
        {
            verticalVelocity2 = -gravity2 * Time.deltaTime;
            if (Input.GetKey("space"))
            {
                verticalVelocity2 = jumpForce2;
            }
        }
        else
        {
            verticalVelocity2 -= gravity2 * Time.deltaTime;
        }
        Vector3 moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * 5.0f;
        moveVector.y = verticalVelocity2;
        moveVector.z = Input.GetAxis("Vertical") * 5.0f;
        controller.Move(moveVector * Time.deltaTime);
    }
}
