using UnityEngine;

public class JokeManager : MonoBehaviour
{
    //Time till the next joke can appear. 
    public float jokeTimer; 
    bool readyToSayJoke;


    Joke[] jokeList; 
    //The number of the next upcoming joke
    int jokeIndex;
    //List of joke INDEXs that have been used. 
    int[] usedJokesThisRound; 
    //How many jokes will be said this round. 
    int numExistingJokesInScope;

    public MicrophoneScript microphone;

    public GameController gameController;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetNumExistingJokesInScope();
        usedJokesThisRound = new int[numExistingJokesInScope];
        jokeList = new Joke[numExistingJokesInScope];
        jokeIndex = 1;

    }

    //Function that runs at the start of the round to decide the number of jokes we have for the round. 
    void SetNumExistingJokesInScope(){
        //Do Some Logic to decide how many jokes. 
        numExistingJokesInScope = 10; 
    }

    // Update is called once per frame
    void Update()
    {
        if (jokeTimer > 0)
        {
            jokeTimer -= Time.deltaTime;
        }
        else
        {
            //If player is in the right state, make the prompt appear. 
            if (gameController.playerFSM.currentState == PlayerFSM.State.Waiting)
            {
                PromptForJoke();
                jokeTimer = 15f;
            }
            else if (gameController.playerFSM.currentState == PlayerFSM.State.SayingJoke)
            {
                gameController.playerFSM.SayingToWaiting();
            }
            else
            {
                jokeTimer = 5f;
            }
            
        }
        
    }
    //If the character is in the correct state, 
    void PromptForJoke()
    {
        microphone.currentJoke = jokeList[jokeIndex];
        //Some kind of indicator that its ready 
        gameController.playerFSM.WaitingToJokePrepared();
    }
}
