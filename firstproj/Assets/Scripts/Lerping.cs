using UnityEngine;

public class Lerping : MonoBehaviour
{
   public Vector3 vOne, vTwo;
   public float value;

    
    void Update()
    {
        var direction = Vector3.Lerp(vOne, vTwo, value);
        value += 0.01f * Time.deltaTime;
        transform.Translate(direction);
    }
}
