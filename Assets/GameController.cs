using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    static bool isDebug = false;
    public static int score;
    public static int levelNum = 0;
    public static int maxScoreAcheieved = 0;

    public static bool isPaused;



    public JokeManager jokeManager;

    public MicrophoneScript microphone;

    public PlayerFSM playerFSM;

    public PlayerScript playerScript;

    public GameObject journalPrefab;
    public GameObject jounralInstance;
    public bool isJounralUIOpen;
    public GameObject jounralCamera;
    public Camera mainCamera;

    public float actionTimer;
    public float alienSpawnChanceTimer;

    public float levelTimer;
    public float endingDelayTimer;


    public CanvasGroup darkenScreenSquare;


    public int maxAliens;
    public List<GameObject> npcList;

    public GameObject alienPrefab;

    public int DayNumber;

    public AudioSource jokePlayer;

    private Queue<AudioClip> audioQueue = new Queue<AudioClip>();
    public GameObject[] StarList;





    public TMP_Text scoreText;
    public GameObject alienSpawnSpot;

    private PlayerFSM.State previousState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        score = 0;

        
        actionTimer = 5f;
        alienSpawnChanceTimer = 10f;
        //Placeholder, gets set once the level ends 
        endingDelayTimer = 1000f;
        //Total time for the level 
        levelTimer = 100f;

        maxAliens = 10;

        if (isDebug)
        {
            GameObject.Find("DebugPlayerUI").SetActive(true);
        }
        else
        {
            GameObject.Find("DebugPlayerUI").SetActive(false);
            
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (playerFSM.currentState == PlayerFSM.State.Paused)
        {
            return;
        }
        if(playerFSM.currentState == PlayerFSM.State.SayingJoke && jokePlayer.isPlaying)
        {
            return;
        }


        //Level Timer Stuff 
        if (levelTimer > 0)
        {
            levelTimer -= Time.deltaTime;
        }
        else
        {
            //End Level. 
            //Make all aliens leave. 
            for (int i = 0; i < npcList.Count; i++)
            {
                //Make npc leave the building. 
                // npcList[i].getComponent
            }
            //End the level after another timer. 
            endingDelayTimer = 5f;
            levelTimer = 1000f;
        }


        if (endingDelayTimer > 2f && endingDelayTimer < 500f)
        {
            Debug.Log(1);
            endingDelayTimer -= Time.deltaTime;
        }
        else if (endingDelayTimer > 0f && endingDelayTimer < 500f)

        {
            Debug.Log(2);

            endingDelayTimer -= Time.deltaTime;
            //Darken Screen
            darkenScreenSquare.alpha += 0.01f;

        }
        else if (endingDelayTimer < 0f)
        {
            //Move to DayTransition
            GameController.levelNum += 1;
            SceneManager.LoadScene(3);
        }
        
        if (playerFSM.currentState == PlayerFSM.State.SayingJoke && !jokePlayer.isPlaying && audioQueue.Count > 0)
            {
                //Dequeue, Play audio clip
                AudioClip clipToPlay = audioQueue.Dequeue();
                jokePlayer.clip = clipToPlay;
                jokePlayer.Play();

            }
        else if(playerFSM.currentState == PlayerFSM.State.SayingJoke && !jokePlayer.isPlaying && audioQueue.Count == 0)
        {
            //transition to waiting
            playerFSM.SayingToWaiting();
            actionTimer = 5f;
        }
        //Action Timer, For the player to be able to do jokes and stuff. 
        if (actionTimer > 0)
        {
            actionTimer -= Time.deltaTime;
        }
        else
        {
            //If player is in the right state, make the prompt appear. 
            if (playerFSM.currentState == PlayerFSM.State.Waiting)
            {
                jokeManager.PromptForJoke();
                playerFSM.WaitingToJokePrepared();
                actionTimer = 15f;
            }
            else
            {
                actionTimer = 5f;
            }

        }
        if (alienSpawnChanceTimer > 0)
        {
            alienSpawnChanceTimer -= Time.deltaTime;
        }
        else
        {

            if (Random.Range(0, 1) < 0.33 && npcList.Count < maxAliens)
            {
                GameObject newAlien = GameObject.Instantiate(alienPrefab, alienSpawnSpot.transform.position, Quaternion.identity);
                npcList.Add(newAlien);
            }
            alienSpawnChanceTimer = 15f;
            
        }

        }



    public void entersMicrophone()
    {
        playerFSM.JokePreparedToDeciding();
    }

    public void exitsMicrophone()
    {
        playerFSM.DecidingToJokePrepared();
    }


    public void setPlayerCanMove(bool pCanMove)
    {
        playerScript.canMove = pCanMove;
    }



    public void sayJoke()
    {
        //give this to the Jokemanager to evaluate, 
        List<Word> words = new List<Word>();

        //Get the Joke prompt,
        //All of its children are the droppable spots. 
        Debug.Log(microphone.jokePrompt.transform.childCount);
        for (int i = 0; i <  microphone.jokePrompt.transform.childCount; i++) {
            //This will be the word object. 
            Transform test = microphone.jokeInstance.transform.GetChild(i);
            
            
            //If its a non-droppable section, just skip over it. 
            if(test.gameObject.GetComponent<Droppable>() == null)
            {
                continue;
            }
            //If they have dont have a child, just return. we need them to all have words in them. 
            if(test.childCount == 0)
            {
                return;
            }

            //Otherwise, get the child, and put it into the word list
            DragDrop wordInSlot = test.GetChild(0).GetComponent<DragDrop>();
            words.Add(wordInSlot.attachedWord); 
        }

        //Get Joke type Of the created Joke. 
        JokeManager.JokeType typeOfSaidJoke = jokeManager.checkJokeType(jokeManager.getCurrentJoke(), words);
        int numOfPerfect =  jokeManager.getNumOfPerfects(jokeManager.getCurrentJoke(), words);
        float scoringOfPerfectDefinitons = 1 + (numOfPerfect * 0.5f);

        //If there are any percfect definitions, display a small star! 
        for(int i = 0; i < numOfPerfect; i++)
        {
            //Make 1 star visible. 
            StarList[i].SetActive(true);
        }

        //Populate the audio queue  with the corresponding texts
        int loop = 0;
        while (true)
        {
            if(jokeManager.getCurrentJoke().listOfAudio.Length > loop)
            {
                audioQueue.Enqueue(jokeManager.getCurrentJoke().listOfAudio[loop]);
            }
            else
            {
                break;
            }
            if(words.Count > loop)
            {
                audioQueue.Enqueue(words[loop].sound);
            }
            else
            {
                break;
            }
            loop += 1;

        }
        //Actually play clip
        jokePlayer.clip = audioQueue.Dequeue();
        jokePlayer.Play();



        for (int i = 0; i < npcList.Count; i++)
        {
            if (npcList[i] == null)
            {
                continue;
            }
            if(npcList[i].GetComponent<AlienMovement>().isListening == true)
            {
                GameController.score += (int) (npcList[i].GetComponent<NPCReaction>().score(typeOfSaidJoke) + (Mathf.Abs((float)npcList[i].GetComponent<NPCReaction>().score(typeOfSaidJoke)) * scoringOfPerfectDefinitons));
            }
        }

        //Update Score Text 
        scoreText.text = GameController.score.ToString();
        


    }

    public void OnButtonClick()
    {
        //Check if all jokes are filled. 
        sayJoke();

        //Change Score Accordingly. 
        playerFSM.DecidingToSaying();
    }




    void OnOpenJournal()
    {
        if (!isJounralUIOpen)
        {
            jounralInstance = GameObject.Instantiate(journalPrefab, playerScript.transform);
            Transform t = jounralInstance.transform;

            for (int i = 0; i < t.childCount; i++)
            {
                if (t.GetChild(i).gameObject.tag == "Camera")
                {
                    jounralCamera = t.GetChild(i).gameObject;
                }

            }
            jounralCamera.SetActive(true);
            mainCamera.enabled = false;
            isJounralUIOpen = true;
            previousState = playerFSM.currentState;
            playerFSM.enterPaused();


        }
        else
        {
            Destroy(jounralInstance);
            jounralCamera.SetActive(false);
            mainCamera.enabled = true;
            isJounralUIOpen = false;
            playerFSM.exitPausedTo(previousState);

        }
    }



    public static bool IsDebug()
    {
        return isDebug;
    }

}
