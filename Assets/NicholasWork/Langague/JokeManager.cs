using UnityEngine;

public class JokeManager : MonoBehaviour
{
    public enum JokeType
    {
        Crude,
        Wholesome,
        SelfDepricating,
        Silly

    }
    //Time till the next joke can appear. 
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
    void SetNumExistingJokesInScope()
    {
        //Do Some Logic to decide how many jokes. 
        numExistingJokesInScope = 10;
    }


    
    //If the character is in the correct state, 
    public void PromptForJoke()
    {
        microphone.currentJoke = jokeList[jokeIndex];
        //Some kind of indicator that its ready 
        gameController.playerFSM.WaitingToJokePrepared();
    }

    public Joke getCurrentJoke()
    {
        //FIX HERE
        return jokeList[0];
    }
    public JokeType checkJokeType(Joke pJoke, Word[] words)
    {
        return JokeType.Silly;
    }
}


