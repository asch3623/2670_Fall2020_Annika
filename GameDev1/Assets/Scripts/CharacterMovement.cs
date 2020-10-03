using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
  private Rigidbody rb;
  public float moveSpeed = 20f;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
    Vector3 rotateRB;

  }

  private void Update()
  
  {
    rb.transform.rotation = Quaternion.Euler(0,0,0);
    
    float moveH = Input.GetAxis("Horizontal");
    float moveV = Input.GetAxis("Vertical");
    Vector3 movement = new Vector3(moveH, 0f, moveV)* Time.deltaTime * moveSpeed;
    rb.MovePosition(transform.position + movement);
  }
}
