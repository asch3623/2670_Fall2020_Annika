using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharBehavior : MonoBehaviour
{
    protected CharacterController controller;
       protected Vector3 positionDirection;
       protected float yVar;
       
       public float gravity = 3f, jumpForce = 100f, roSpeed = 5f;
       public int jumpCount, jumpCountMax = 2;
       public FloatData moveSpeed, normalSpeed, fastSpeed;
          void Start()
           {
               controller = GetComponent<CharacterController>();
           }
}
