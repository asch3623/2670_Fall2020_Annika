using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ApplyForce : MonoBehaviour
{
    private Rigidbody rb;
    public float force = 30f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        var forceDirection = new Vector3(force, 0,0);
        rb.AddRelativeForce(forceDirection);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
