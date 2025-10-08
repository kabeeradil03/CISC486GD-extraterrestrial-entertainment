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

    //Joke manager. 
    public JokeManager jokeManager; 

    //UI Elements.

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
            //Do Next Action, Call one of the transitions, depending on what conditions are true
            // All transition EXCEPT deciding on joke require a waiting time.
        }
        
    }
    //Transition between states; 
    void WaitingToDeciding(){

        //Generate Random Joke Prompt. 
        
        
        
        
    }
    void DecidingToSaying(){
        //After the user has inputted 
        //Play the corresponding audio
        
    }
    void SayingToWaiting(){
        //Allow enough time for the aliens to give their responses, and maybe enough time to dodge some tomatoes. 

    }
}
