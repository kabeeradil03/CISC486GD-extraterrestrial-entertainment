using UnityEngine;
using System.Collections;
public class CameraController : MonoBehaviour
{
    public float xSenesitivity;
    public float ySenesitivity;
    public Transform player;
    public float xRotation;
    public float yRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * xSenesitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * ySenesitivity * Time.deltaTime;

        // get the rotation values and limit x so the player can't go past normal view
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation += mouseX;

        // rotate the player along the x z plane, but don't change the y rotation
        player.rotation = Quaternion.Euler(0,yRotation,0);

        // rotate camera vertically and horizontally
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
