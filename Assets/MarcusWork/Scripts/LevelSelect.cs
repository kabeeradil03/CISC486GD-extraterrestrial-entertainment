using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button l2;
    public int mp; //multiplayer

    void Start()
    {
        l2.interactable = false;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mp = 1;
        }

        if (mp == 1)
        {
            l2.interactable = true;
        }
    }
    
    public void menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void LoadLevel(int level){
        SceneManager.LoadScene(level);
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
        
    }
}
