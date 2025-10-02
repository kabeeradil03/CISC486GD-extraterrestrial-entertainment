using UnityEngine;

public class Revolution : MonoBehaviour

{
    public float rotationSpeed = 10f; // Speed of rotation in degrees per second
    public Transform pivotPoint; // Point around which the object will rotate

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivotPoint.position,Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
