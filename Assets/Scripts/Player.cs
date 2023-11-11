using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    CharacterController controller;

    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;

    float forwardSpeed = 5f;
    float strafeSpeed = 5f;

    float gravity;
    float jumpSpeed;
    float maxJumpHeight = 2f;
    float timeToMaxHeight = 0.5f; 

    void Start()
    {

        controller = GetComponent<CharacterController>();

        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / timeToMaxHeight;

    }
    

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("aqui!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        if (collision.gameObject.name=="ground")
        {
            Debug.Log("colidi!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            SceneManager.LoadScene("jogo");
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        forward = forwardInput * forwardSpeed * transform.forward;
        strafe = strafeInput * strafeSpeed * transform.right;
        
        vertical += gravity * Time.deltaTime * Vector3.up;

        
        //Mecanismo de correr.
        if(Input.GetKey(KeyCode.LeftShift)){
            forwardSpeed = 10f;
            gravity = (-3 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        }else {
            forwardSpeed = 5f;
            gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        }

        if (controller.isGrounded)
        {
            vertical = Vector3.down;
        }
    
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            vertical = jumpSpeed * Vector3.up;
        }

        if(vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            vertical = Vector3.zero;
        }

        Vector3 finalVelocity = forward + strafe + vertical;

        controller.Move(finalVelocity * Time.deltaTime);
    }
}
