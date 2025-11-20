using UnityEngine;
using TMPro;
public class CurrentScore : MonoBehaviour
{
    public TMP_Text score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (GameController.score != null)
        {
            score.text = "Current Score: " + GameController.score;
        }
        else{
            score.text = "Current Score: 0";
            
        }
       
    }
}
