using UnityEngine;

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
    public Camera jounralCamera;
    public Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnOpenJournal()
    {
        if (!isJounralUIOpen)
        {
            jounralInstance = GameObject.Instantiate(journalPrefab);
            jounralCamera.enabled = true;
            mainCamera.enabled = false;
            isJounralUIOpen = true;

        }
        else
        {
            Destroy(jounralInstance);
            jounralCamera.enabled = false;
            mainCamera.enabled = true;
            isJounralUIOpen = false;

        }
    }

    public void entersMicrophone()
    {
        microphone.OnTouched();
    }

     public void exitsMicrophone()
    {
        microphone.OnExit();
    }


    public setPlayerCanMove(bool pCanMove)
    {
        playerScript.canMove = pCanMove;
    }


    
    public void sayJoke(Joke joke, Word[] listWords)
    {
        //give this to the Jokemanager to evaluate, 

        //Change Score Accordingly. 
        playerFSM.DecidingToSaying();


    }
}
