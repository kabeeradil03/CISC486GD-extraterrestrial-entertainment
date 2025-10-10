using UnityEngine;
using TMPro;

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
    public GameController gameController;

    public TMP_Text stateText;

    //UI Elements.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = State.Waiting;
        stateText.text = "Waiting";

    }

    // Update is called once per frame
    void Update()
    {

    }
    //Transition between states; 

    public void WaitingToJokePrepared()
    {
        currentState = State.JokePrepared;
        //Cube appears. 
        gameController.microphone.detectionCube.SetActive(true);
        //Put light to show its joke time. 
        stateText.text = "JokePrepared";
    }
    public void JokePreparedToDeciding()
    {
        currentState = State.DecidingJoke;

        //Player steps into the cube.
        gameController.microphone.OnTouched();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        stateText.text = "DecidingOnJoke";


    }
    public void DecidingToSaying()
    {
        //After the user has inputted 
        //Play the corresponding audio
        //Remove the ability to move.
        currentState = State.SayingJoke;

        gameController.setPlayerCanMove(false);
        gameController.actionTimer = 5f;
        gameController.microphone.jokeResponseContainer.SetActive(false);
        stateText.text = "SayingJoke";


    }
    public void SayingToWaiting()
    {
        //Allow enough time for the aliens to give their responses, and maybe enough time to dodge some tomatoes. 
        currentState = State.Waiting;
        gameController.microphone.OnExit();
        gameController.microphone.detectionCube.SetActive(false);
        gameController.setPlayerCanMove(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        stateText.text = "Waiting";

    }
    
    public void DecidingToJokePrepared()
    {
        currentState = State.JokePrepared;
        gameController.microphone.OnExit();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        stateText.text = "JokePrepared";
    }
    public void enterPaused()
    {
        currentState = State.Paused;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameController.setPlayerCanMove(false);
        stateText.text = "Paused";


    }
    public void exitPausedTo(State pState)
    {
        currentState = pState;
        gameController.setPlayerCanMove(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        stateText.text = pState.ToString();
    }
}
