using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    //Possible Player States. 
    public enum State{
        DecidingJoke,
        SayingJoke, 
        Waiting,
        Paused
    }
    public State currentState; 
    public float waitingTime;

    //UI Elements.
    public GameObject jokePrompt; 
    public GameObject jokeResponseContainer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = State.Waiting;
        waitingTime = 5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        waitingTime -= Time.deltaTime;
        if(waitingTime<=0){
            //Do Next Action, Call one of the transitions, depending on what conditions are true.
        }
        
    }

    void randJoke(){

    }
    //Transition between states; 
    void WaitingToDeciding(){

        //Generate Random Joke Prompt. 
        GameObject jokeInstance = GameObject.Instantiate(jokePrompt);
        //jokeResponseContainer.enabled = true;
        
        
    }
    void DecidingToSaying(){
        
    }
    void SayingToWaiting(){

    }
}
