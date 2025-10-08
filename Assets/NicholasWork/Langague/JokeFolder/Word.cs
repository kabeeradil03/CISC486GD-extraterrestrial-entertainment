using UnityEngine;

[CreateAssetMenu(fileName = "Word", menuName = "Scriptable Objects/Word")]
public class Word : ScriptableObject
{
    //What word class it is
    public enum WordTypes{
        ADJ,
        NOUN,
        VERB
    };
    //When used in a joke, what theme does the word correspond to
    public enum WordThemes{
        SelfDeprication,
        Wholesome,
        Crude,
        Silly
    }
    public WordTypes type;
    public WordThemes theme;

    //The IRL meaning of the word
    public string meaning; 

    //Information to find the image of the alien word in the images. 
    public Sprite wordImage;
    public int imageID;

}
