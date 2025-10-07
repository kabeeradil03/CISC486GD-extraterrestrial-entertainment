using UnityEngine;
using UnityEngine.UI;


public class NPCReactionWorld : MonoBehaviour
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

    void Start()
    {
        // Automatically find the main camera if not assigned
        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Make the reaction canvas always face the camera
        if (reactionImage != null && cameraTransform != null)
            reactionImage.transform.LookAt(cameraTransform);

        // Key inputs
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ShowReaction(laughSprite);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            ShowReaction(sadSprite);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            ShowReaction(angrySprite);
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
}
