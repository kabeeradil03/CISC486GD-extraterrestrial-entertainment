using System;
using Unity.Behavior;
using UnityEngine;
using Composite = Unity.Behavior.Composite;
using Unity.Properties;
using Unity.Collections;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "WeightedRandom", story: "Weighted Random Based On State", category: "Flow", id: "cd12de49a13a777d896b62e5f063e845")]
public partial class WeightedRandomSequence : Composite
{

    int m_RandomNumber = 0;
    int chosenIndex;
    [SerializeReference] public BlackboardVariable<GameObject>  targetObject;

    protected override Status OnStart()
    {

        GameObject obj = (GameObject) targetObject; 
        NPCReaction emotionScript = obj.GetComponent<NPCReaction>();
        NPCReaction.NPCStates state = emotionScript.currentState;
        
        //Navigate To Bar, Navigate To Listening Chair, Navigate To Other Chair, Wait, Leave, 
        float[] arrayVeryHappy = { 10, 40, 1, 1, 100};
        float[] array1Happy = { 1, 1, 1, 1, 100};
        float[] array2Neutral = { 1, 1, 1, 1, 100};
        float[] array3Angry = { 1, 1, 1, 1, 100};
        float[] array4VeryAngry = { 1, 1, 1, 1, 100};
        float[] array5Sad = { 1, 1, 1, 50, 100};

        //Stand Up, Wait, Idle Animation

        float[] correspondingWeights = array1Happy;
        m_RandomNumber = UnityEngine.Random.Range(0, 100); // Turn this into a weigthed range.
        int chosenIndex = 0;
        while (m_RandomNumber < correspondingWeights[chosenIndex])
        {
            chosenIndex += 1;
        }
       
        
        //Execute the corresponding State 
        if (chosenIndex < Children.Count)
        {
            var status = StartNode(Children[chosenIndex]);
            if (status == Status.Success || status == Status.Failure)
                return status;

            return Status.Waiting;
        }

        return Status.Success;
        
    }

    protected override Status OnUpdate()
    {
       var status = Children[chosenIndex].CurrentStatus;
            if (status == Status.Success || status == Status.Failure)
                return status;

            return Status.Waiting;
    }

    protected override void OnEnd()
    {
    }
}

