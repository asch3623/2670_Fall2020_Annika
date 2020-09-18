using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform lookObj;

    void Update()
    {
        transform.LookAt(lookObj);
    }
}
