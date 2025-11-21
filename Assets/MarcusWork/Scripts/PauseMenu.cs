using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public bool gameIsPaused = false;
    public PlayerFSM playerFSM;
    public PlayerFSM.State prevState;

    [SerializeField] public GameObject pauseMenuUI;
    [SerializeField] public GameObject jokeMenu;
    
    public int jokeActive; // 0 means wasn't active // 1 means it was active when esc pressed

    void Start()
    {
        playerFSM = GameObject.Find("Player").GetComponent<PlayerFSM>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                resume();
                
            }
            else
            {
                pause();
            }
            playerFSM.currentState = prevState;
        }




    }

    public void resume()
    {
        if (jokeActive == 1)
                {
                    jokeMenu.SetActive(true);
                    jokeActive = 0;
                } else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        
    }

    public void pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (jokeMenu.activeSelf)
        {
            jokeActive = 1;
        } else
        {
            jokeActive = 0;
        }
        pauseMenuUI.SetActive(true);
        jokeMenu.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;

        //Pause Game Play 
        prevState = playerFSM.currentState;
        playerFSM.currentState = PlayerFSM.State.Paused;

    }

    public void menu()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}