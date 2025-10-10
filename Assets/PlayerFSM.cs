using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    //Possible Player States. 
    public enum State
    {
        DecidingJoke,
        JokePrepared,
        SayingJoke,
        Waiting,
        Paused
    }
    public State currentState;

    //Joke manager. 
    public JokeManager jokeManager;
    public GameController gameController;

    //UI Elements.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = State.Waiting;

    }

    // Update is called once per frame
    void Update()
    {
    }
    //Transition between states; 

    public void WaitingToJokePrepared()
    {
        //Cube appears. 
        

    }
    public void DecidingToSaying()
    {
        //After the user has inputted 
        //Play the corresponding audio
        //Remove the ability to move.
        gameController.setPlayerCanMove(false);

    }
    public void SayingToWaiting()
    {
        //Allow enough time for the aliens to give their responses, and maybe enough time to dodge some tomatoes. 
        gameController.setPlayerCanMove(false);
    }
    public void JokePreparedToDeciding()
    {

    }
    public void DecidingToJokePrepared()
    {
        
    }
}
