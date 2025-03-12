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

    [SerializeField] private TextMeshProUGUI gearLevelText;

    [SerializeField] int baseNoteScore;

    [SerializeField] int gear;

    [SerializeField] int gearLevel;

    [SerializeField] int currentScore;

    [SerializeField] private int baseDistanceScore;

    [SerializeField] private int notesThisSection;

    private int sectionNotesHit;

    

    [SerializeField] private int currentDifficulty;

    [SerializeField] private int nextDifficulty;

    [SerializeField] private int currentPhraseLevel;

    //roads object references

    [SerializeField] private GameObject currentRoad;

    [SerializeField] private GameObject diff1Road;

    [SerializeField] private GameObject diff2Road;

    [SerializeField] private GameObject diff3Road;

    [SerializeField] private GameObject diff4Road;


    void Start()
    {
        baseNoteScore = 50;
        gear = 1;
        currentScore = 0;
        gearLevel = 0;
        currentPhraseLevel = 1;
    }

    void Update()
    {
        scoreText.text = currentScore.ToString();
        multText.text = gear.ToString();
        gearLevelText.text = gearLevel.ToString();

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

        if (gear == 1)
        {
            if (currentPhraseLevel != 1)
            {
                //translate current road to placeholder xposition;
                //translate road 1 to road xposition;
                //set current road to road2
                //set currentPhraseLevel to 1
            }


        }

        if (gear == 2)
        {
            //load difficulty 1 next section

            if (currentPhraseLevel != 2)
            {
                //translate current road to placeholder xposition;
                //translate road 2 to road xposition;
                //set current road to road2
                //set currentPhraseLevel to 2
            }

            //diff2Road.transform.position.x == 
        }

        if (gear ==3)
        {
            //load difficulty 3 next section

            if (currentPhraseLevel != 3)
            {
                //translate current road to placeholder xposition;
                //translate road 2 to road xposition;
                //set current road to road2
                //set currentPhraseLevel to 2
            }

        }

        //if (gear)
    }
}
