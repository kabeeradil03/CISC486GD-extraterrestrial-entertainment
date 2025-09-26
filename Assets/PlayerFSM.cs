using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    public enum State{
        DecidingJoke,
        SayingJoke, 
        Waiting,
        Paused
    }
    public State currentState; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
