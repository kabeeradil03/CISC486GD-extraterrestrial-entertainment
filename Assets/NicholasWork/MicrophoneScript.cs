using UnityEngine;

public class MicrophoneScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Canvas jokeResponseContainer;
    public GameObject jokePrompt;
    void Start()
    {
        
    }
    
    void OnTouched(){
        GameObject jokeInstance = GameObject.Instantiate(jokePrompt);
        jokeResponseContainer.enabled = true;
    }
}
