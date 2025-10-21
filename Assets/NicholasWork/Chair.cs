using UnityEngine;

public class Chair : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Collider col;
    public bool isTaken;

    //Which index animation to play when the alien is sitting in the chair. 
    public int animIndex;


    public void sitIn(GameObject alienObj)
    {
        isTaken = true;
    }

    public void getOut()
    {
        isTaken = false;
    }

}
