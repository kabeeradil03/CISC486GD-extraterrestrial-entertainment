using UnityEngine;

public class MicrophoneScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject jokeResponseContainer;
    public GameObject jokePrompt;
    public GameController controller; 
    public PlayerFSM playerFSM;
    

    public GameObject micCam;
    public GameObject readyLight;

    public GameObject playerCam;

    public GameObject detectionCube;
    public GameObject jokeInstance;


    public void OnTouched()
    {
        //enable mouse and disable looking

        //Lock camera in place. 
        micCam.SetActive(true);
        playerCam.SetActive(false);

        //Make a new joke and dispaly it
        jokeResponseContainer.SetActive(true);
        
        jokeInstance = GameObject.Instantiate(jokePrompt, jokeResponseContainer.transform);
        jokeInstance.transform.position = jokeInstance.transform.position - new Vector3(-25, 0 -25);
        //Load in the corresponding joke from the joke controller. 

    }

    public void OnExit()
    {
        micCam.SetActive(false);
        playerCam.SetActive(true);
        //Destroy the joke instance and hide the container. 
        GameObject.Destroy(jokeInstance);        
        jokeResponseContainer.SetActive(false); 

    }

    public void ReadyLight(bool pLight)
    {
        readyLight.SetActive(pLight);
        
    }
}
