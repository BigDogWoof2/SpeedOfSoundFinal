using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreScript : MonoBehaviour
{
   

    [SerializeField] private TextMeshProUGUI multText;

    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] int baseNoteScore;

    [SerializeField] int gear;

    [SerializeField] int gearLevel;

    [SerializeField] int currentScore;

    [SerializeField] private int baseDistanceScore;

    [SerializeField] private int notesThisSection;

    private int sectionNotesHit;

    [SerializeField] private int currentDifficulty;

    [SerializeField] private int nextDifficulty;

    
    void Start()
    {
        baseNoteScore = 50;
        gear = 1;
        currentScore = 0;
        gearLevel = 0;
    }

    void Update()
    {
        scoreText.text = currentScore.ToString();
        multText.text = gear.ToString();

        AddDistanceScore();
    }



    void AddDistanceScore()
    {
        currentScore+=baseDistanceScore;
    }

    public void AddNoteScore()
    {
        currentScore += baseNoteScore;
    }


    public void AddPerfectNoteScore()
    {
        currentScore += (gear * baseNoteScore);
    }


    public void IncrementGearLevel()
    {
        gearLevel += 1;
        if (gearLevel == 4 && gear < 4)
        {
            gearLevel = 0;
            gear +=1;
        }
    }

    public void LostStreak()
    {
        Debug.Log("gear = 1");
        gear = 1;

    }

    //needs to be called as a player calls a user defined threshold
    public void AssessPerformance()
    {
        float percentNotesHit = sectionNotesHit/notesThisSection * 100;

        if (gear == 1)
        {

        }

        //if (gear)
    }
}
