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


            PlayerScript script = other.GetComponent<PlayerScript>();

            // used AI to figure out that I should be disabling the controller to avoid physics issues rather than the player movement script/rigidbody.
            // I also used AI to automatically replace the code (swap from using the script/rigidbody to character controller). 
            // The code that was affected was code that grabbed the rigidbody component (line 24) and was replaced with CharacterController
            // The code to disable/enable the script/rigidbody was also replaced with the controller variable (line 29 and 35). All other code I originally wrote.
            CharacterController controller = other.GetComponent<CharacterController>();

            if (controller != null && script != null)
            {

                controller.enabled = false;

                // Teleport the player to the new location
                controller.transform.position = location;


                controller.enabled = true;

                // Adjust gravity and jump height based on whether the player is entering or leaving the bar
                if (entering)
                {
                    script.gravity = -9.81f; 
                    script.jumpHeight = 4f; 
                }
                else
                {
                    script.gravity = -4.81f;
                    script.jumpHeight = 6f; 
                }
            }
        }
    }
}