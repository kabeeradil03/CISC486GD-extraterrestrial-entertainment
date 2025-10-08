using UnityEngine;

[CreateAssetMenu(fileName = "Joke", menuName = "Scriptable Objects/Joke")]
public class Joke : ScriptableObject
{
    public int numOfInouts;
    public string[] jokeTexts;
    public int id;
    
}
