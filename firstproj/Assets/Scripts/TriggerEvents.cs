using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    public UnityEvent triggerEnterEvent;
    public UnityEvent triggerExitEvent;
    
    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        triggerExitEvent.Invoke();
    }
}
