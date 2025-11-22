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

    public GameObject[] listOfDragableWords;


    public bool setBool;

    public void OnTouched()
    {
        //enable mouse and disable looking

        //Lock camera in place. 
        micCam.SetActive(true);
        playerCam.SetActive(false);

        //Make a new joke and dispaly it
        jokeResponseContainer.SetActive(true);
        
        jokeInstance = GameObject.Instantiate(jokePrompt, jokeResponseContainer.transform);
        //jokeInstance.transform.position = jokeInstance.transform.position - new Vector3(-25, 0 -25);
        //Load in the corresponding joke from the joke controller. 


        //If first time entering since a joke has been said. 
        if (setBool)
        {
            GameObject[] listOfDragables = new GameObject[controller.jokeManager.listOfWords.Count];
            
            for(int i = 0; i < controller.jokeManager.listOfWords.Count; i++)
            {
                Debug.Log("Slot"+(i+1));

                Debug.Log(GameObject.Find("Slot"+(i+1)));

                GameObject newDragable = GameObject.Instantiate(controller.jokeManager.dragablePrefab, GameObject.Find("Slot"+(i+1)).transform);


                DragDrop newDragScript = newDragable.GetComponent<DragDrop>();
                newDragScript.attachedWord = controller.jokeManager.listOfWords[i];
                newDragable.GetComponent<UnityEngine.UI.Image>().sprite =  controller.jokeManager.listOfWords[i].wordImage; 
                listOfDragables[i] = newDragable;
            }
            listOfDragableWords = listOfDragables;
            setBool = false;
        }
        




    }

    public void OnExit()
    {
        //Also Hide Stars.
        if(GameObject.Find("Star1") != null)
        {
            GameObject.Find("Star1").SetActive(false);
            
        }
        if(GameObject.Find("Star2") != null)
        {
            GameObject.Find("Star2").SetActive(false);
            
        }
        if(GameObject.Find("Star3") != null)
        {
            GameObject.Find("Star3").SetActive(false);
            
        }

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
