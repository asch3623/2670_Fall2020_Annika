using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 positionDirection;
    
    public float gravity = 3f, jumpForce = 100f, roSpeed = 5f;
    public int jumpCount, jumpCountMax = 2;
    private float yVar;

    public FloatData moveSpeed, normalSpeed, fastSpeed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = fastSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = normalSpeed;
        }
        
        var vInput = Input.GetAxis("Vertical");
        var hInput = Input.GetAxis("Horizontal");
        
        transform.Rotate(0,roSpeed *hInput,0);

        yVar -= gravity;
        
        positionDirection.Set(moveSpeed.value*vInput, yVar, hInput);
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
            positionDirection.Set(moveSpeed.value*vInput, yVar, hInput);
            jumpCount++;
        }
    }
}