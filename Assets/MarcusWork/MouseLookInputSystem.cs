using UnityEngine;

public class MouseLookInputSystem : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Adjust sensitivity of mouse movement
    public Transform playerBody;         // Reference to the player's body for rotating the entire character
    private float xRotation = 0f;        // Tracks vertical rotation to prevent over-rotation

    void Start()
    {
        // Lock the cursor to the center of the screen and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Adjust vertical rotation and clamp it to prevent flipping
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply rotation to the camera (vertical) and player body (horizontal)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}