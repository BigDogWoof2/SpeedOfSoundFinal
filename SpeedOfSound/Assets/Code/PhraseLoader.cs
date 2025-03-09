using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhraseLoader : MonoBehaviour
{

    string phraseName;
    // Start is called before the first frame update

    [SerializeField] private GameObject diff1Phrase1;

    [SerializeField] private GameObject diff1Phrase2; 

    [SerializeField] private GameObject diff2Phrase2; 

    [SerializeField] private GameObject diff3Phrase2; 

    [SerializeField] private GameObject diff4Phrase2; 
    void Start()
    {

        

        var phraseDict = new Dictionary<string, GameObject>();

        phraseDict.Add("1,1", diff1Phrase1);
        phraseDict.Add("1,2", diff1Phrase2);
        phraseDict.Add("2,2", diff2Phrase2);
        phraseDict.Add("3,2", diff3Phrase2);
        phraseDict.Add("4,2", diff4Phrase2);

        //get a reference to score script for gear value
        //need a dictionary to access all of the various sections, so the next can be loaded with the correct difficulty
        //might have to move to a system of the car moving forward, because moving the tracks when they are being changed might be challenging
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceNextPhrase()
    {
        //int current phrase
        //int current gear
        //create key from these values to find the right phrase
        //find gameObject to hold notes
        GameObject.Find("");  
        //Instantiate function that takes the correct object and the correct placeholder in the scene, and instantiates the notes as a child of the
    }
}
