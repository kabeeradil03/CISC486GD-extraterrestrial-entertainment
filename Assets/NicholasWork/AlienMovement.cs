using UnityEngine;
using Unity.Behavior;

public class AlienMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float movementSpeed = 5f;

    public UnityEngine.AI.NavMeshAgent agent;
    Chair[] AllChairs = new Chair[20];
    public BehaviorGraphAgent behaviorAgent;
    Unity.Behavior.BlackboardVariable<UnityEngine.GameObject> chairObj;
    GameObject prevChairObject;

    bool seated = false;
    Vector3 prevPos;
    string prevTag;

    public bool isListening;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        behaviorAgent.GetVariable<GameObject>("Chair1", out chairObj);
        GameObject chairObj1 = (GameObject)chairObj;

        if(chairObj1 != null)
        {
            if(chairObj1.tag != "Chair" && chairObj1.tag != "ListeningChair")
            {
                //Stop Movement, and reset eveything. Chairs been taken
                behaviorAgent.Restart();
                behaviorAgent.SetVariableValue<GameObject>("Chair1", null);


            }
            if ((Vector3.Distance(transform.position, chairObj1.transform.position) < 3) && !seated)
            {
                Sit(chairObj);
            } 

        }
        
    }

    public void Sit(GameObject chair)
    {
        prevPos = transform.position;
        behaviorAgent.SetVariableValue<Vector3>("PrevPos", transform.position);
        //Animate Sitting, 
        transform.position = chair.transform.position;
        behaviorAgent.SetVariableValue<bool>("IsSitting", true);
        if(chair.tag == "ListeningChair")
        {
            isListening = true;
        }
        prevTag = chair.tag;
        prevChairObject = chair;

        chair.tag = "Untagged";

        seated = true;
        //Stop Movement
        agent.enabled = false;
        behaviorAgent.Restart();
    }
    public void UnSit()
    {
        transform.position = prevPos; // Exit Point

        behaviorAgent.SetVariableValue<bool>("IsSitting", false);
        
        seated = false;
        agent.enabled = true;

        isListening = false;

        Debug.Log(prevTag);
        prevChairObject.tag = prevTag;

        
        behaviorAgent.SetVariableValue<GameObject>("Chair1", null);


    }
    
}


    
        