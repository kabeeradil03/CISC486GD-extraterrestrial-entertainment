using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float movementSpeed = 5f;

    public UnityEngine.AI.NavMeshAgent agent;
    Chair[] AllChairs = new Chair[20];
    
    public enum AlienMovementState
    {
        Walking,
        
    }





    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        generatePath();
        
    }
    
    public void generatePath()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            agent.SetDestination(AllChairs[0].transform.position);
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            agent.SetDestination(AllChairs[1].transform.position);
        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            agent.SetDestination(AllChairs[2].transform.position);
        } else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            agent.SetDestination(AllChairs[3].transform.position);
        }
    }
}
