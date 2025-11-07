using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetWanderPoint", story: "Set Wander Point", category: "Action", id: "858ae20ecf0207e939a64161e7c0b701")]
public partial class SetWanderPointAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> agent1;
    UnityEngine.AI.NavMeshAgent agent;
    Vector3 targetPosition;


    protected override Status OnStart()
    {

        GameObject agent2 = (GameObject)agent1;
        agent = agent2.GetComponent<UnityEngine.AI.NavMeshAgent>();
        Vector3 sourcePosition = new Vector3(UnityEngine.Random.Range(3f, 10f), 0, UnityEngine.Random.Range(3f, 10f));


        Debug.Log(UnityEngine.Random.Range(0f, 1f));

        Debug.Log(UnityEngine.Random.Range(0f, 1f) < 0.5);
        if (UnityEngine.Random.Range(0f, 1f) < 0.5)
        {
            sourcePosition.x *= -1;
        }
        if(UnityEngine.Random.Range(0f,1f) < 0.5)
        {
            sourcePosition.z *= -1;
        }
        sourcePosition += agent2.transform.position;

        UnityEngine.AI.NavMeshHit hit;

        Debug.Log(agent.areaMask);

        if (UnityEngine.AI.NavMesh.SamplePosition(sourcePosition, out hit, 15f, agent.areaMask))
        {
            Debug.Log("Non-Zero");

            Debug.Log(hit.position);
            targetPosition = hit.position;
        }
        else
        {
            Debug.Log("Zero");
            Debug.Log(hit.position);
            targetPosition = Vector3.zero;
        }

        agent.SetDestination(targetPosition);

        return Status.Running;
    }
    
    protected override Status OnUpdate()
    {
        if (agent1.Value == null)
        {
            return Status.Failure;
        }
        
        Vector3 agentPosition = new Vector3(agent1.Value.transform.position.x, agent1.Value.transform.position.y, agent1.Value.transform.position.z);

        float distance = Vector3.Distance(agentPosition, targetPosition);
        
        bool destinationReached = distance <= 1;

        if (destinationReached)
        {
            return Status.Success;
        }

        return Status.Running;
            
    }
    


    
}

