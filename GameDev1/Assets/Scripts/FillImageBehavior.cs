using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FillImageBehavior : MonoBehaviour
{
  private Image im;
  public BoolData coolDown;
  private float fillValue = 0f;
  private float targetValue = 1f;
  private float fillSpeed = .1f;
    void Start()
    {

        im = GetComponent<Image>();
        im.fillAmount = fillValue;
    }
    
    void Update()
    {
        while (coolDown.value == true && fillValue <= 1f)
        {
            fillValue = Mathf.MoveTowards(fillValue, targetValue, Time.deltaTime * fillSpeed);
            im.fillAmount = fillValue;
        }
    }
}
