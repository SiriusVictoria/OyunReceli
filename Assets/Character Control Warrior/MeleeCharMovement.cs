using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCharMovement : MonoBehaviour
{
    private float verticalVelocity2;
    private float gravity2 = 14.0f;
    private float jumpForce2 = 10.0f;
    public CharacterController controller;
    public Transform cam;
    public float speed2 = 6f;
    public float turnSmoothTime2 = 0.1f;
    float turnSmoothVelocity2;

    //sesler
    

    //eklentiler
    public Animator animator;
    private float glidingMultiplier = 10f;
    public bool isGliding, isAttacking;
    private float ungroundingTimer;

    private void Start()
    {
        ungroundingTimer = 0f;
        isGliding = false;
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
                isGliding = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                isAttacking = true;
                Invoke("AttackDisable", 0.85f);
            }
        }
        else
        {
            if (Input.GetKey("space") && verticalVelocity2 <= 0)
            {
                verticalVelocity2 = -Time.deltaTime * gravity2 * glidingMultiplier;
                isGliding = true;
            }
            else
            {
                verticalVelocity2 -= gravity2 * Time.deltaTime;
                isGliding = false;
            }
        }
        Vector3 moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * 5.0f;
        moveVector.y = verticalVelocity2;
        moveVector.z = Input.GetAxis("Vertical") * 5.0f;
        controller.Move(moveVector * Time.deltaTime);

        //Anim control
        AnimControl();


    }

    private void AttackDisable()
    {
        isAttacking = false;
    }

    private void AnimControl()
    {
        if (ungroundingTimer > 0.15f)
        {
            if (isGliding)
            {
                animator.SetBool("Jump", true);
                animator.SetBool("Fly", true);
            }
            else
            {
                animator.SetBool("Fly", false);
            }
        }

        if (isAttacking)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Jump", false);
            animator.SetBool("Fly", false);
            animator.SetBool("Attack", true);
           

        }
        else if (new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical")).magnitude >= 0.1f && controller.isGrounded)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Jump", false);
            animator.SetBool("Fly", false);
            animator.SetBool("Attack", false);
        }
        else if (verticalVelocity2 > 0)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
            animator.SetBool("Attack", false);
        }
        else if (!controller.isGrounded)
        {
            ungroundingTimer += Time.deltaTime;
            animator.SetBool("Run", false);
            animator.SetBool("Attack", false);
        }
        else if (controller.isGrounded)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Run", false);
            animator.SetBool("Fly", false);
            animator.SetBool("Attack", false);
            ungroundingTimer = 0;
        }

    }

}
