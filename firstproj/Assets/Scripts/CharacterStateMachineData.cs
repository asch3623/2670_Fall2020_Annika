using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class CharacterStateMachineData : ScriptableObject
{
    public enum characterStates{
        StandardWalk,
        WallCrawl,
     KnockBack
    }
    
    public characterStates value;

    public UnityEvent onEnableEvent;

    public void OnEnable()
    {
        onEnableEvent.Invoke();
    }

    public void StandardWalk()
    {
        value = characterStates.StandardWalk;
    }
    public void KnockBack()
    {
        value = characterStates.KnockBack;
    }
    
    public void WallClimb()
    {
        value = characterStates.WallCrawl;
    }

}
