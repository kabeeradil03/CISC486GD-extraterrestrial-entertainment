using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationController : MonoBehaviour
{
    public Rigidbody ship;
    public CanvasGroup darkenScreenSquare;
    public float endingDelayTimer = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ship.AddForce(new Vector3(0, 80f, 0));

        if(endingDelayTimer > 10f)
        {
            endingDelayTimer -= Time.deltaTime;
            darkenScreenSquare.alpha -= 0.001f;
        }
        else if (endingDelayTimer > 2f && endingDelayTimer < 10f)
        {
            endingDelayTimer -= Time.deltaTime;
        }
        else if (endingDelayTimer > 0f)

        {
            endingDelayTimer -= Time.deltaTime;
            darkenScreenSquare.alpha += 0.005f;

        }
        else if (endingDelayTimer < 0f)
        {
            SceneManager.LoadScene(1);
        }   
    }
}
