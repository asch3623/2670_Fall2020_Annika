﻿using System;
using System.Collections;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class CharacterMover : CharBehavior
{
public Animator anim;

void Start()
{
    anim.SetBool("isIdle", true);
    anim.SetBool("isJumping", false);
    anim.SetBool("isWalking", false);
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
        controller.Move((knockBackMovement + positionDirection) * Time.deltaTime);

        if (vInput != 0f)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
        }

        if (controller.isGrounded)
        {
            jumpCount = 0;
            yVar = -0.1f;
        }
        
        //double jump
        if (Input.GetButtonDown("Jump") && jumpCount < jumpCountMax)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isJumping", true);
            yVar += Mathf.Sqrt(jumpForce * -3f * (-gravity));
            positionDirection.Set(moveSpeed.value*vInput, yVar, hInput);
            jumpCount++;
        }
    }

    private float playerKnockBackForce = 10f;
    private Vector3 knockBackMovement;
    private IEnumerator KnockBack(ControllerColliderHit hit)
    {
        var i = 2f;
        knockBackMovement = hit.collider.attachedRigidbody.velocity * (i * playerKnockBackForce);
        while (i > 0)
        {
            yield return new WaitForFixedUpdate();
            i -= .1f;
        }
        
    }
    
    
    private Vector3 direction = Vector3.zero;
    public float pushPower = 3f;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var body = hit.collider.attachedRigidbody;

        if (body == null)
        {
            return;
        }

        StartCoroutine(KnockBack(hit));
       direction.Set(hit.moveDirection.x, 0, hit.moveDirection.z);
       var pushDirection = direction * pushPower;
       body.velocity = pushDirection;
       body.AddTorque(pushDirection);
       body.AddRelativeForce(pushDirection);
    }
}