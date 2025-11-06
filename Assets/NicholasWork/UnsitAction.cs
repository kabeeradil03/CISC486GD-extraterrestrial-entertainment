using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Unsit", story: "Unsit", category: "Action", id: "6f6999479785126da05d013f8e6358dd")]
public partial class UnsitAction : Action
{

    [SerializeReference] public BlackboardVariable<GameObject>  targetObject;
    
    protected override Status OnStart()
    {
        GameObject obj = (GameObject) targetObject; 
        AlienMovement movementScript = obj.GetComponent<AlienMovement>();
        movementScript.UnSit();
        return Status.Success;
    }

    
}

