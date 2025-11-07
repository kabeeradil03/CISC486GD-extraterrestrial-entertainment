using System;
using Unity.Behavior;
using UnityEngine;
using Composite = Unity.Behavior.Composite;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "WeightedRandom", story: "Weighted Random Based On State", category: "Flow", id: "cd12de49a13a777d896b62e5f063e845")]
public partial class WeightedRandomSequence : Composite
{

    int m_RandomNumber = 0;
    int chosenIndex;
    float[] correspondingWeights;



    protected override Status OnStart()
    {

        // GameObject obj = (GameObject)targetObject;
        GameObject obj = this.GameObject; 
        NPCReaction emotionScript = obj.GetComponent<NPCReaction>();
        NPCReaction.NPCStates state = emotionScript.currentState;

        //Navigate To Bar, Navigate To Listening Chair, Navigate To Other Chair, Wait, Wander, Leave, 
        float[] arrayVeryHappy = { 10, 70, 80, 85, 95, 100 };
        float[] array1Happy = { 20, 60, 75, 80, 90, 100 };
        float[] array2Neutral = { 20, 50, 60,70, 80, 100 };
        float[] array3Angry = { 30, 50, 60, 65, 70, 100 };
        float[] array4VeryAngry = { 30, 40, 50, 55, 60, 100 };
        float[] array5Sad = { 20, 30, 40,45, 50, 100 };

        if (state == NPCReaction.NPCStates.VeryHappy)
        {
            correspondingWeights = arrayVeryHappy;
        }
        else if (state == NPCReaction.NPCStates.Happy)
        {
            correspondingWeights = array1Happy;

        }
        else if (state == NPCReaction.NPCStates.Neutral)
        {
            correspondingWeights = array2Neutral;

        }
        else if (state == NPCReaction.NPCStates.Angry)
        {
            correspondingWeights = array3Angry;

        }
        else if (state == NPCReaction.NPCStates.VeryAngry)
        {
            correspondingWeights = array4VeryAngry;

        }
        //else if(state == NPCReaction.NPCStates.Sad)
        else
        {
            correspondingWeights = array5Sad;
            
        }



        m_RandomNumber = UnityEngine.Random.Range(0, 100); // Turn this into a weigthed range.
        int chosenIndex = 0;
        while (m_RandomNumber > correspondingWeights[chosenIndex])
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

        //This code below is what should work, but I cant get it to work, the status is always uninitialized. 
        // So therefore Im Bodging it with a return Status.Success

        //Status status = Children[chosenIndex].CurrentStatus;
        //Debug.Log(status);
        //if (status == Status.Success || status == Status.Failure)
        //    return status;
        //return Status.Waiting;
        return Status.Success;
    }
}

