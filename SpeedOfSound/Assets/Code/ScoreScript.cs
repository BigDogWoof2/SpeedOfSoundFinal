using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreScript : MonoBehaviour
{
   

    [SerializeField] private TextMeshProUGUI multText;

    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] int baseNoteScore;

    [SerializeField] int multiplier;

    [SerializeField] int currentScore;

    [SerializeField] private int baseDistanceScore;

    [SerializeField] private int notesThisSection;

    private int sectionNotesHit;

    [SerializeField] private int currentDifficulty;

    [SerializeField] private int nextDifficulty;

    
    void Start()
    {
        baseNoteScore = 50;
        multiplier = 1;
        currentScore = 0;
    }

    void Update()
    {
        scoreText.text = currentScore.ToString();
        multText.text = multiplier.ToString();

        AddDistanceScore();
    }



    void AddDistanceScore()
    {

        currentScore+=baseDistanceScore;

    }

    public void AddPerfectNoteScore()
    {
        currentScore += (multiplier * baseNoteScore);
    }


    public void IncrementMultiplier()
    {
        multiplier += 1;
    }

    public void LostStreak()
    {
        Debug.Log("mult = 1");
        multiplier = 1;

    }

    //needs to be called as a player calls a user defined threshold
    public void AssessPerformance()
    {
        float percentNotesHit = sectionNotesHit/notesThisSection * 100;

        //switch (percentNotesHit)
    }
}
