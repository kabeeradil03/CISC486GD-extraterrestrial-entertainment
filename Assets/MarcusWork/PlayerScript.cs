using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public CharacterController controller; // Reference to the CharacterController component
    public float speed = 6f;               // Normal movement speed
    public float sprintSpeed = 12f;        // Sprinting speed
    public float jumpHeight = 1.5f;        // Jump height
    public float gravity = -9.81f;         // Gravity value
    public Transform groundCheck;          // Transform to check if the player is grounded
    public float groundDistance = 0.4f;    // Radius of the ground check sphere
    public LayerMask groundMask;           // Layer mask to identify ground

    private Vector3 velocity;              // Tracks player's velocity
    private bool isGrounded;               // Tracks if the player is grounded

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Reset velocity if grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Get input for movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Check if the player is sprinting
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = isSprinting ? sprintSpeed : speed;

        // Calculate movement direction
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Move the player
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply vertical movement
        controller.Move(velocity * Time.deltaTime);
    }
}