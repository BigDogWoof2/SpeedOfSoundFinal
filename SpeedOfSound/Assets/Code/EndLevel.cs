using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//Base Class by Fraser Sutherland
public class EndLevel : MonoBehaviour
{

    [SerializeField] ScoreScript scoreScriptRef;
    // Start is called before the first frame update
    [SerializeField] GameObject scoreScreen;

    [SerializeField] TextMeshProUGUI totalScoreText;
    

    
    //called when car volume collides with end level trigger prefa
    public void EndLevelTriggered()
    {
        //Set active score screen UI element
        CreateScoreScreen();

    }
    //creates score screen at the end of the level, right now just sets the score equal to the current score
    void CreateScoreScreen()
    {
        scoreScreen.SetActive(true);

        totalScoreText.text = scoreScriptRef.currentScore.ToString();
    }



}
