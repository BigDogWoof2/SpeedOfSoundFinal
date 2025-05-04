using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
//Base Class by Fraser Sutherland and UI/grade by Fraser Welsh
public class EndLevel : MonoBehaviour
{

    [SerializeField] ScoreScript scoreScriptRef;
    [SerializeField] GameLoopClass gameLoopRef;
    [SerializeField] GameObject scoreScreen;
    [SerializeField] int totalScore;
    [SerializeField] TextMeshProUGUI totalScoreText;
    [SerializeField] TextMeshProUGUI highestGearText;
    [SerializeField] TextMeshProUGUI runGrade;
    

    
    //called when car collides with EndTrigger obj in scene.
    void OnTriggerEnter()
    {
        //Set active score screen UI element
        CreateScoreScreen();

    }
    //Creates score screen at the end of the level.
    void CreateScoreScreen()
    {
        scoreScreen.SetActive(true);

        //Multiplies score by upgrades hit and shows on scorescreen as final score.
        totalScore = scoreScriptRef.currentScore * scoreScriptRef.upgradesHit;
        totalScoreText.text = totalScore.ToString();

        //Don´t have a variable for Highest Gear on UI Elements, just posts the current gear for now.
        highestGearText.text = scoreScriptRef.gear.ToString();

        //Rudimentary grade system. Scores should be tweaked.
        if (totalScore > 4500000) {runGrade.text = "S";}
        else if (totalScore > 4000000) {runGrade.text = "A";}
        else if (totalScore > 3000000) {runGrade.text = "B";}
        else if (totalScore > 2000000) {runGrade.text = "C";}
        else if (totalScore > 0) {runGrade.text = "F";}

    }

    //Returns player to first scene. Audio continues playing, needs updated.
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }



}
