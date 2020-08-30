using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmUP : MonoBehaviour
{

enum Direction {North, East, South, West};

    public int score = 7;
    public float time;
    public bool isRunning;
    private Rigidbody rb;
    void Start()
    {
        if (score == 7)
        {
            Debug.Log("your score is 7");
            rb = GetComponent<Rigidbody>();
        }
    }
}
