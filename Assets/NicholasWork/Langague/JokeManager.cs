using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class JokeManager : MonoBehaviour
{
    public GameObject[] allJokePrompts;
    public Joke[] allJokes;
    public Word[] allWords;


    public enum JokeType
    {
        Crude,
        Wholesome,
        SelfDepricating,
        Silly

    }
    //Time till the next joke can appear. 
    bool readyToSayJoke;

    Joke currentJoke;
    //The number of the next upcoming joke
    int jokeIndex;
    //List of joke INDEXs that have been used. 
    int[] usedJokesThisRound;
    //How many jokes will be said this round. 
    int numExistingJokesInScope;

    int numWordsToUse = 10;

    public MicrophoneScript microphone;

    public GameController gameController;

    public GameObject dragablePrefab;

    public List<Word> listOfWords = new List<Word>();




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetNumExistingJokesInScope();
        usedJokesThisRound = new int[numExistingJokesInScope];

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
        //Find a random joke 
        int randomIndex = Random.Range(0, gameController.jokeManager.allJokePrompts.Length);

        currentJoke =  gameController.jokeManager.allJokes[randomIndex];
        GameObject randomJokePrefab = gameController.jokeManager.allJokePrompts[randomIndex];
        microphone.jokePrompt = randomJokePrefab;

        //For that joke, generate 10 random words, and give them to the Microphone stand. 
        
        listOfWords = new List<Word>();


        int counter = 0;
        while(counter < numWordsToUse)
        {
            int randNum = Random.Range(0, allWords.Length);
            if (! listOfWords.Contains(allWords[randNum]))
            {
                listOfWords.Add(allWords[randNum]);
                counter += 1;
            }
            
        }

        //Make it so that upon the next time entering the microphone, it will create new draggables
        microphone.setBool = true;

        //Some kind of indicator that its ready 
        gameController.playerFSM.WaitingToJokePrepared();


    }

    public Joke getCurrentJoke()
    {
        return currentJoke;
    }


    public int getNumOfPerfects(Joke pJoke, List<Word> words){
        int counter = 0;
         for(int i = 0; i < words.Count; i++)
        {
            
            if (pJoke.perfectDefinition[i] == words[i].type)
            {
                counter += 1;
            }
        }
        return counter;
    }
    
    public JokeType checkJokeType(Joke pJoke, List<Word>  words)
    {
        int[] values = new int[4];
        values[0] = 0;
        values[1] = 0;
        values[2] = 0;
        values[3] = 0;

        Debug.Log(words.Count);
        for(int i = 0; i < words.Count; i++)
        {
            int addVal = 1; 
            if (pJoke.perfectDefinition[i] == words[i].type)
            {
                addVal = 2;
            }

            if(words[i].theme == JokeType.Crude)
            {
                values[0] += addVal;
            }
            else if(words[i].theme == JokeType.SelfDepricating)
            {
                values[1] += addVal;
            }
            else if(words[i].theme == JokeType.Silly)
            {
                values[2] += addVal;
            }
            else if(words[i].theme == JokeType.Wholesome)
            {
                values[3] += addVal;
            }
        }
        int maxIndex = 0;
        for(int i = 1; i < values.Length; i++)
        {
            if(values[i] > values[maxIndex])
            {
                maxIndex = i;
            }
        }

        if(maxIndex == 0)
        {
            return JokeType.Crude;
        }
        else if(maxIndex == 1)
        {
            return JokeType.SelfDepricating;
        }
        else if(maxIndex == 2)
        {
            return JokeType.Silly;
        }
        //else if(maxIndex == 3)
        else{
            return JokeType.Wholesome;
        }
        ;
    }
}


