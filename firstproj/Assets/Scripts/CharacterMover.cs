using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    public BoxCollider bc;
    public Vector3 movement;
    private CharacterController controller;
    public float gravity = 9.81f;
    public float moveSpeed = 3f;
    public float jumpForce = 10f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        

    }

    // Update is called once per frame
    void Update()
    {
        movement.y -= gravity;
        movement.x = Input.GetAxis("Vertical")*moveSpeed;
        controller.Move(movement*Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            movement.y = jumpForce*Time.deltaTime;
        }

        if (controller.isGrounded)
        {
            movement.y = 0f;
        }
        else
        {
            movement.y -= gravity;
        }
    }
}
