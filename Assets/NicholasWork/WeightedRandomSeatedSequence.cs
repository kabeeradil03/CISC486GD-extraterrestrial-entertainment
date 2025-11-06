using System;
using Unity.Behavior;
using UnityEngine;
using Composite = Unity.Behavior.Composite;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "WeightedRandom Seated", category: "Flow", id: "04358835218257e21e50bd4a46665938")]
public partial class WeightedRandomSeatedSequence : Composite
{

    int m_RandomIndex = 0;
    [SerializeReference] public BlackboardVariable<GameObject>  targetObject;

    protected override Status OnStart()
    {

        GameObject obj = (GameObject) targetObject; 
        NPCReaction emotionScript = obj.GetComponent<NPCReaction>();
        NPCReaction.NPCStates state = emotionScript.currentState;

        //Stand Up, Wait, Idle Animation
        float[] arrayVeryHappy = { 10, 1, 1};
        float[] array1Happy = { 1, 1, 1};
        float[] array2Neutral = { 1, 1, 1};
        float[] array3Angry = { 1, 1, 1 };
        float[] array4VeryAngry = { 1, 1, 1};
        float[] array5Sad = { 1, 1, 1};
        

        m_RandomIndex = UnityEngine.Random.Range(0, Children.Count); // Turn this into a weigthed range.
        
        //Execute the corresponding State 
        if (m_RandomIndex < Children.Count)
        {
            var status = StartNode(Children[m_RandomIndex]);
            if (status == Status.Success || status == Status.Failure)
                return status;

            return Status.Waiting;
        }

        return Status.Success;
        
    }

    protected override Status OnUpdate()
    {
       var status = Children[m_RandomIndex].CurrentStatus;
            if (status == Status.Success || status == Status.Failure)
                return status;

            return Status.Waiting;
    }

    protected override void OnEnd()
    {
    }
}

