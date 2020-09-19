using UnityEngine;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float value = 1f;

    public void ChangeValue(float number)
    {
        if (value >= 1)
        {
            value = 1;
            value += number;
        }
        else if (value <= -.1f)
        {
            value = -0.1f;
            value += number;
        }
        else
        {
            value += number;
        }
    }
}