using System;
using Unity.Behavior;
using UnityEngine;
using Composite = Unity.Behavior.Composite;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "WeightedRandom", story: "Weighted Random Based On State", category: "Flow", id: "cd12de49a13a777d896b62e5f063e845")]
public partial class WeightedRandomSequence : Composite
{

    int m_RandomIndex = 0;

    protected override Status OnStart()
    {
            m_RandomIndex = UnityEngine.Random.Range(0, Children.Count); // Turn this into a weigthed range. 
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

