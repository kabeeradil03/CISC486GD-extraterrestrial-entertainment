using UnityEngine;

public class JokeManager : MonoBehaviour
{
    public float jokeTimer; 
    bool readyToSayJoke; 
    int jokeIndex;
    int[] usedJokesThisRound; 
    int numExistingJokesInScope; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetNumExistingJokesInScope();
        usedJokesThisRound = new int[numExistingJokesInScope];

    }

    //Function that runs at the start of the round to decide the number of jokes we have for the round. 
    void SetNumExistingJokesInScope(){
        //Do Some Logic to decide how many jokes. 
        numExistingJokesInScope = 10; 
    }

    // Update is called once per frame
    void Update()
    {
        if(jokeTimer > 0){
            jokeTimer -= Time.deltaTime;
        }
        else{
            PromptForJoke();
        }
        
    }
    

    //If the character is in the correct state, 
    void PromptForJoke(){

    }
}
