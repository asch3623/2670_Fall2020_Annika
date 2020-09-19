using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageFillBehavior : MonoBehaviour
{
    private Image newImage;
    public FloatData dataObj;
    void Start()
    {
        newImage = GetComponent<Image>();

    }

    void Update()
    {
        newImage.fillAmount = dataObj.value;
    }
}

