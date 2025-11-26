using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public TMP_Text dayText;

    public TMP_Text scoreText;
    public TMP_Text score;
    public TMP_Text requiredScoreText;
    public TMP_Text requiredScore;
    public TMP_Text verdictText;
    public TMP_Text verdict;

    public Button button;

    public float actionTimer = 5f;
    private int counter = 0;

    public GameObject pass;
    public GameObject fail;
    
    void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(() => { transitionToWorld();});
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        dayText.text = "Day " + GameController.levelNum;
        PlayerPrefs.SetInt("HighScore", GameController.score);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        if (actionTimer > 0f)
        {
            actionTimer -= Time.deltaTime;
        }
        else
        {
            displayNextText();
            actionTimer = 3f;
            counter += 1;
        }

    }
    public void transitionToWorld()
    {
        SceneManager.LoadScene(2);

    }

    public void transitionToFail()
    {
        SceneManager.LoadScene(4);

    }


    void displayNextText()
    {
        if (counter == 0)
        {
            scoreText.gameObject.SetActive(true);
            score.gameObject.SetActive(true);
            score.text = (GameController.score).ToString();
        }
        else if (counter == 1)
        {
            requiredScore.gameObject.SetActive(true);
            requiredScoreText.gameObject.SetActive(true);
            requiredScore.text = (GameController.levelNum * 20).ToString();
        }
        //Else if counter == 2
        else
        {
            verdict.gameObject.SetActive(true);
            verdictText.gameObject.SetActive(true);
            bool verdictBool = (GameController.levelNum * 20) <= (GameController.score);
            if (verdictBool)
            {
                pass.SetActive(true);
                verdict.text = "Passed";
                button.GetComponent<Button>().onClick.AddListener(() => { transitionToWorld(); });
            }
            else
            {
                fail.SetActive(true);
                verdict.text = "Failed";
                button.GetComponent<Button>().onClick.AddListener(() => { transitionToFail(); });
                if(GameController.maxScoreAcheieved > GameController.score)
                {
                    GameController.maxScoreAcheieved = GameController.score;
                }
            }
            
            button.gameObject.SetActive(true);
        }
    }
}
