using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ColourCube", story: "ColourDebugCube", category: "Action", id: "d7531462dc4b395f960c7051c40c004a")]
public partial class ColourCubeAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> debugCube;
    [SerializeReference] public BlackboardVariable<string> colourName;
    protected override Status OnStart()
    {
        Material newMat = Resources.Load(colourName, typeof(Material)) as Material;
        debugCube.Value.GetComponent<Renderer>().material = newMat;
        return Status.Success;
    }
}

