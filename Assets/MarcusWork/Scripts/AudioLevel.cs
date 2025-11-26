using UnityEngine;

public class AudioLevel : MonoBehaviour
{

    public AudioSource aud;
    public PlayerFSM pfsm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pfsm.currentState != PlayerFSM.State.JokePrepared && pfsm.currentState != PlayerFSM.State.Waiting)
        {
            aud.volume = 0.1f;
        } else
        {
            aud.volume = 1;
        }
    }
}
