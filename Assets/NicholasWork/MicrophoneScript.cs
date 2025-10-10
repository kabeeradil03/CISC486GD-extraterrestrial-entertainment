using UnityEngine;

public class MicrophoneScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject jokeResponseContainer;
    public GameObject jokePrompt;
    public Joke currentJoke;
    public GameController controller; 
    public PlayerFSM playerFSM;

    public GameObject micCam;
    public GameObject playerCam;

    public void OnTouched()
    {
        //enable mouse and disable looking

        //Lock camera in place. 
        micCam.SetActive(true);
        playerCam.SetActive(false);

        //Make a new joke and dispaly it
        jokeResponseContainer.SetActive(true);

        GameObject jokeInstance = GameObject.Instantiate(jokePrompt, jokeResponseContainer.transform);

        //Change player state to be deciding joke. 
        playerFSM.JokePreparedToDeciding();
    }



    void finishJoke()
    {
        Word word1 = new Word();
        Word word2 = new Word();
        Word word3 = new Word();


        Word[] words = new Word[3];

        words[0] = word1;
        words[1] = word2;
        words[2] = word3;

        controller.sayJoke(currentJoke, words);
        
    }

    public void OnExit()
    {

        micCam.SetActive(false);
        playerCam.SetActive(true);
        //Destroy the joke instance and hide the container. 

        //Disable mouse and enable looking
        jokeResponseContainer.SetActive(false); 

        //Change player state to be Joke prepared. 
        playerFSM.DecidingToJokePrepared();


    }
}
