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

    public GameObject detectionCube;

    public void OnTouched()
    {
        //enable mouse and disable looking

        //Lock camera in place. 
        micCam.SetActive(true);
        playerCam.SetActive(false);

        //Make a new joke and dispaly it
        jokeResponseContainer.SetActive(true);

        GameObject jokeInstance = GameObject.Instantiate(jokePrompt, jokeResponseContainer.transform);
    }

    public void OnExit()
    {

        micCam.SetActive(false);
        playerCam.SetActive(true);
        //Destroy the joke instance and hide the container. 

        //Disable mouse and enable looking
        jokeResponseContainer.SetActive(false); 


    }
}
