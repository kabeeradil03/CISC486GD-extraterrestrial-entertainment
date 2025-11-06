using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetWanderPoint", story: "Set Wander Point", category: "Action", id: "858ae20ecf0207e939a64161e7c0b701")]
public partial class SetWanderPointAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject>  agent1;

    protected override Status OnStart()
    {
        Vector3 hitPosition;
        GameObject agent2 = (GameObject) agent1;
        UnityEngine.AI.NavMeshAgent agent =  agent2.GetComponent<UnityEngine.AI.NavMeshAgent>();
        Vector3 sourcePosition = new Vector3(UnityEngine.Random.Range(3, 20), UnityEngine.Random.Range(3, 20), UnityEngine.Random.Range(3, 20));
        UnityEngine.AI.NavMeshHit hit;
        if (UnityEngine.AI.NavMesh.SamplePosition(sourcePosition, out hit, 10f, agent.areaMask))
        {
            hitPosition = hit.position;
        }
        else
        {
            hitPosition = Vector3.zero;
        }

        agent.SetDestination(hitPosition);

        return Status.Success;
    }

    
}

