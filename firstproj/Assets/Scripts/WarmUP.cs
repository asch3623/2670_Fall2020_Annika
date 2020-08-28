using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmUP : MonoBehaviour
{

    public int score = 7;
    public float time;
    public bool isRunning;
    void Start()
    {
        if (score == 7)
        {
            Debug.Log("your score is 7");
        }
    }
}
