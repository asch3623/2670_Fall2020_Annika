using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiPatrol : AiBase
{
//script from class dgm 2670
    public List patrolPoints;
    protected int i;

    protected virtual void OnEnable()
    {
        patrolPoints.vector3Datas?.Clear();
        i = 0;
    }

    private void OnDisable()
    {
        if (patrolPoints != null) patrolPoints.vector3Datas?.Clear();
    }

    public override void RunAgent(NavMeshAgent agent)
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.destination = patrolPoints.vector3Datas[i].value;
            i = (i + 1) % patrolPoints.vector3Datas.Count;
        }
    }
}