﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
  private Rigidbody rb;
  public float moveSpeed = 10f;
  private int seconds = 1, coolDownSeconds = 7;
  public BoolData coolDown, isDarting;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
    coolDown.value = false;
  }

  private void Update()
  
  {
    rb.transform.rotation = Quaternion.Euler(0,0,0);
    
    float moveH = Input.GetAxis("Horizontal");
    float moveV = Input.GetAxis("Vertical");
    Vector3 movement = new Vector3(moveH, 0f, moveV)* Time.deltaTime * moveSpeed;
    rb.MovePosition(transform.position + movement);
    
    
    
    
    if (Input.GetKeyDown(KeyCode.LeftShift) && !isDarting.value && !coolDown.value)
           {
             isDarting.value = true;
             moveSpeed = 50f;
             StartCoroutine(Dart());
           }

  }

  IEnumerator Dart()
  {
    yield return new WaitForSeconds(seconds);
    moveSpeed = 10f;
    isDarting.value = false;
    coolDown.value = true;
    yield return new WaitForSeconds(coolDownSeconds);
    coolDown.value = false;
  }
}