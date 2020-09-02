using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 positionDirection;
    
    public float gravity = 3f, jumpForce = 30f, speed = 6f, roSpeed = 5f;
    public int jumpCount, jumpCountMax = 2;
    private float yVar;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        var vInput = Input.GetAxis("Vertical");
        var hInput = Input.GetAxis("Horizontal");
        
        transform.Rotate(0,roSpeed *hInput,0);

        yVar -= gravity;
        
        positionDirection.Set(speed*vInput, yVar, hInput);
        positionDirection = transform.TransformDirection(positionDirection);
        controller.Move(positionDirection * Time.deltaTime);

        if (controller.isGrounded)
        {
            jumpCount = 0;
            yVar = -0.1f;
        }
        
        //double jump
        if (Input.GetButtonDown("Jump") && jumpCount < jumpCountMax)
        {
            yVar += Mathf.Sqrt(jumpForce * -3f * (-gravity));
            positionDirection.Set(speed*vInput, yVar, hInput);
            jumpCount++;
        }
    }
}