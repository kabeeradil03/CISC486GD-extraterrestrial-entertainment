using System;
using Unity.Behavior;
using UnityEngine;
using Composite = Unity.Behavior.Composite;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "WeightedRandom Seated", category: "Flow", id: "04358835218257e21e50bd4a46665938")]
public partial class WeightedRandomSeatedSequence : Composite
{

    int m_RandomNumber = 0;
    int chosenIndex;
    float[] correspondingWeights;

    protected override Status OnStart()
    {

        //Serializeable Field is not working properly, Im just gonna get GameObject by name.

        GameObject obj = this.GameObject; 
        
        NPCReaction emotionScript = obj.GetComponent<NPCReaction>();
        NPCReaction.NPCStates state = emotionScript.currentState;

        //Stand Up, Wait, Idle Animation
        float[] arrayVeryHappy = { 10, 80, 100};
        float[] array1Happy = { 20, 80, 100};
        float[] array2Neutral = { 30, 80, 100};
        float[] array3Angry = { 40, 80, 100};
        float[] array4VeryAngry = { 50, 80, 100};
        float[] array5Sad = { 60, 80, 100 };

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
        chosenIndex = 0;
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
        // var status = Children[chosenIndex].CurrentStatus;
        //     if (status == Status.Success || status == Status.Failure)
        //         return status;

        // return Status.Waiting;
        return Status.Success;
    }
}

