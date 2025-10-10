using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCReaction : MonoBehaviour
{
    [Header("Reaction UI")]
    public Image reactionImage;     // Reference to the Image in the World Space Canvas
    public float displayTime = 2f;  // Duration the sprite is visible
    public Transform cameraTransform; // To face the camera

    [Header("Reaction Sprites")]
    public Sprite laughSprite;
    public Sprite sadSprite;
    public Sprite angrySprite;

    private Coroutine currentCoroutine;

    public int happiness;
    public object[] jokePrefrences;

    public TMP_Text stateText;

    void Start()
    {
        // Automatically find the main camera if not assigned
        if (cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }

        jokePrefrences = new object[] { JokeManager.JokeType.Silly, JokeManager.JokeType.SelfDepricating, JokeManager.JokeType.Wholesome, JokeManager.JokeType.Crude };
    }

    void Update()
    {
        // Make the reaction canvas always face the camera
        if (reactionImage != null && cameraTransform != null)
            reactionImage.transform.LookAt(cameraTransform);

        // Key inputs
        if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                stateText.text = "Happy";
                ShowReaction(laughSprite);
            }


        if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                stateText.text = "Sad";
                ShowReaction(sadSprite);
            }


        if (Input.GetKeyDown(KeyCode.Alpha3))
            {
            stateText.text = "Angry";
                ShowReaction(angrySprite); 
            }


        if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                stateText.text = "Very Happy";
                ShowReaction(laughSprite);
            }


        if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                stateText.text = "Very Angry";
                ShowReaction(angrySprite);
            }
            
    }

    void ShowReaction(Sprite sprite)
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(DisplaySprite(sprite));
    }

    System.Collections.IEnumerator DisplaySprite(Sprite sprite)
    {
        reactionImage.sprite = sprite;
        reactionImage.enabled = true;
        yield return new WaitForSeconds(displayTime);
        reactionImage.enabled = false;
    }


    public int score(JokeManager.JokeType pJoke)
    {
        if (pJoke == (JokeManager.JokeType)jokePrefrences[0])
        {
            ShowReaction(laughSprite);
            happiness += 10;
            return 10;
        }
        else if (pJoke == (JokeManager.JokeType)jokePrefrences[3])
        {
            ShowReaction(angrySprite);
            happiness -= 5;

            return -5;
        }
        else
        {
            return 0;
        }
    }
}
