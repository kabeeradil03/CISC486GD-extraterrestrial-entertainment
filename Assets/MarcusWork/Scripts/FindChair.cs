using UnityEngine;
using UnityEngine.AI;

public class FindChair : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public NavMeshAgent agent;
    [SerializeField] static Transform[] obj;
    Vector3[] chairs;

    void Start()
    {
        chairs = new Vector3[obj.Length];
        for (int i=0; i<obj.Length;i++)
        {
            chairs[i] = obj[i].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
