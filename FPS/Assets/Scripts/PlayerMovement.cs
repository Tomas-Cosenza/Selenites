using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] private float speed, gravity = -9.81f, groundDistance, jumpModifier = 2f, jumpHeight = 2f;
    [SerializeField] private int extraJumps;
    [SerializeField] private bool isGrounded;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundMask;
    private int jumps;
    [SerializeField] private Animator anim;
    private Vector3 velocity;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }
        if (isGrounded == true) 
        {
            jumps = 1;
            anim.SetBool("land", true);
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right* x + transform.forward * z);
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if(x != 0 || z != 0)
        {
            anim.SetBool("walking", true);
        }
        else
        {

            anim.SetBool("walking", false);
        }

        if (Input.GetButtonDown("Jump") && jumps !=0 )
        {
            anim.SetTrigger("jump");
            Jump();
            jumps--;
        }else
        {

        }

    }

    public void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -jumpModifier * gravity);
    }

    public void Landing()
    {
        anim.SetBool("land", false);
    }
}
