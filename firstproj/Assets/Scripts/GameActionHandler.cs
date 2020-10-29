using UnityEngine;
using UnityEngine.Events;

public class GameActionHandler : MonoBehaviour
{
    
    public GameAction gameAction;
    public UnityEvent handlerEvent;
    private void Start()
    {
        gameAction.action += ActionHandler;
    }

    private void ActionHandler()
    {
        handlerEvent.Invoke();
    }
}
