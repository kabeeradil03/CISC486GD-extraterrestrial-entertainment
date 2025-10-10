using UnityEngine;
using TMPro;


public class GameController : MonoBehaviour
{
    public int score;

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


    public GameObject[] npcList;

    
    public TMP_Text scoreText;


    private PlayerFSM.State previousState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actionTimer = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerFSM.currentState == PlayerFSM.State.Paused)
        {
            return;
        }
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
            else if (playerFSM.currentState == PlayerFSM.State.SayingJoke)
            {
                playerFSM.SayingToWaiting();
                actionTimer = 5f;

            }
            else
            {
                actionTimer = 5f;
            }

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
        Word word1 = new Word();
        Word word2 = new Word();
        Word word3 = new Word();


        Word[] words = new Word[3];

        words[0] = word1;
        words[1] = word2;
        words[2] = word3;

        //Get Joke type Of the created Joke. 
        JokeManager.JokeType typeOfSaidJoke = jokeManager.checkJokeType(jokeManager.getCurrentJoke(), words);
        //Play Audio

        //
        for (int i = 0; i < npcList.Length; i++)
        {
            score += npcList[i].GetComponent<NPCReaction>().score(typeOfSaidJoke);
        }

        //Update Score Text 
        scoreText.text = score.ToString();
        //Change Score Accordingly. 
        playerFSM.DecidingToSaying();


    }

    public void OnButtonClick()
    {
        //Check if all jokes are filled. 
        sayJoke();
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


}
