using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public CharacterController controller;
    Vector3 velocity;
    public float gravity = -9.81f;

    public bool isGrounded;

    public float groundDistance;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float jumpHeight = 2f;
    public float jumpModifier = 2f;

    // Start is called before the first frame update
    void Start()
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


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right* x + transform.forward * z);
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if (isGrounded && Input.GetButtonDown("Jump") ) 
        {
            Jump();
        }

    }

    public void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -jumpModifier * gravity);
    }
}
