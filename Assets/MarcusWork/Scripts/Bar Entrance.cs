using UnityEngine;

public class BarEntrance : MonoBehaviour
{
    public float x = 0;
    public float y = 0;
    public float z = 0;
    public bool entering;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Vector3 location = new Vector3(x, y, z);

            // Get the PlayerScript and CharacterController components
            PlayerScript script = other.GetComponent<PlayerScript>();

            // used AI to figure out that I should be disabling the controller to avoid physics issues rather than the player movement script
            CharacterController controller = other.GetComponent<CharacterController>();

            if (controller != null && script != null)
            {
                // Disable the CharacterController temporarily to avoid unwanted physics
                controller.enabled = false;

                // Teleport the player to the new location
                controller.transform.position = location;

                // Re-enable the CharacterController
                controller.enabled = true;

                // Adjust gravity and jump height based on whether the player is entering or leaving
                if (entering)
                {
                    script.gravity = -9.81f; // Normal gravity
                    script.jumpHeight = 4f; // Normal jump height
                }
                else
                {
                    script.gravity = -4.81f; // Lower gravity
                    script.jumpHeight = 6f; // Higher jump height
                }
            }
        }
    }
}