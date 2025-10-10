using UnityEngine;

[CreateAssetMenu(fileName = "Joke", menuName = "Scriptable Objects/Joke")]
public class Joke : ScriptableObject
{
    public int numOfInputs;
    public string[] jokeTexts;
    public int id;
    
}
