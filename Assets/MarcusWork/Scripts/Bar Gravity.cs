using UnityEngine;

public class BarGravity : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().gravity = -9.81f;
            other.GetComponent<PlayerScript>().jumpHeight = 3f;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().gravity = -4.81f;
            other.GetComponent<PlayerScript>().jumpHeight = 6f;
        }
    }
}
