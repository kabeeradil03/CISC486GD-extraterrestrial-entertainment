using UnityEngine;
using TMPro;
public class ScoreScript : MonoBehaviour
{
    public TMP_Text maxScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameController.maxScoreAcheieved != null)
        {
            maxScore.text = "Maximum Score Acheieved: " + GameController.maxScoreAcheieved;
        }
        else{
            maxScore.text = "Maximum Score Acheieved: 0";
            
        }
       
    }
}
