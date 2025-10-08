using UnityEngine;

public class JokeManager : MonoBehaviour
{
    //Time till the next joke can appear. 
    public float jokeTimer; 
    bool readyToSayJoke; 

    //The number of the next upcoming joke
    int jokeIndex;
    //List of jokes that have been used. 
    int[] usedJokesThisRound; 
    //How many jokes will be said this round. 
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
            //If player is in the right state, make the prompt appear. 
            if(true){
                PromptForJoke();
                jokeTimer = 15f;
            }
            
        }
        
    }
    

    //If the character is in the correct state, 
    void PromptForJoke(){

    }
}
