using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultyChecker : MonoBehaviour
{
    [SerializeField] public GameObject managerRef;
    [SerializeField] private int phraseLevel;
    [SerializeField] private int nextPhraseLevel;

    // Start is called before the first frame update
    void Start()
    {
        managerRef = GameObject.Find("Car/ManagerObject");
        
        phraseLevel = managerRef.GetComponent<ScoreScript>().currentPhraseLevel;
        nextPhraseLevel = managerRef.GetComponent<ScoreScript>().gearLevel;

    }

    // Update is called once per frame
   
    public void ChangeText()
    {
        Debug.Log("Collided with Text");
            if (nextPhraseLevel > phraseLevel)
            {
                Debug.Log("Change Text Up");
            }
            if (nextPhraseLevel == phraseLevel)
            {

                Debug.Log("Change Text Same");

            }
            if (nextPhraseLevel < phraseLevel)
            {

                Debug.Log("Change Text Down");

            }
    } 
}
