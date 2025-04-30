using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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

    [SerializeField] public int gearLevel;

    public int currentScore;

    [SerializeField] private int baseDistanceScore;

    [SerializeField] private int notesThisSection;

    private int sectionNotesHit;

    private int upgradesHit; 
    

    [SerializeField] private int currentDifficulty;

    [SerializeField] private int nextDifficulty;

    [SerializeField] public int currentPhraseLevel;

    //roads object references
    [SerializeField] private GameObject currentRoad;

    [SerializeField] private GameObject diff1Road;

    [SerializeField] private GameObject diff2Road;

    [SerializeField] private GameObject diff3Road;

    [SerializeField] private GameObject diff4Road;

    //Background speed change
    [SerializeField] private GameObject frontBG;
    [SerializeField] private GameObject backBG;
    [SerializeField] private GameObject clutter;

    //FOV Shifting
    [SerializeField] Camera cameraObj;
    [SerializeField] private float fovSpeed = 0.5f;
    [SerializeField] public float gearOneFOV = 40f;
    [SerializeField] public float gearTwoFOV = 50f;
    [SerializeField] public float gearThreeFOV = 60f;

    //Police Siren
    [SerializeField] private GameObject policeLights;
    private UnityEngine.Vector3 plStartPos;
    private UnityEngine.Vector3 plEndPos;

    //Wwise RealTime Parameter Controls
    [SerializeField] AK.Wwise.RTPC RPM = null;


    void Start()
    {
        baseNoteScore = 500;
        baseDistanceScore = 1;
        gear = 2;
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
        PoliceLights();
        
        if(Input.GetKeyDown(KeyCode.P))
        {
          Debug.Break();
        }
    }



    void AddDistanceScore()
    {
        currentScore+=baseDistanceScore * currentPhraseLevel;
    }

    public void AddNoteScore()
    {
        currentScore += baseNoteScore;
    }


    public void AddPerfectNoteScore()
    {
        currentScore += (gear * baseNoteScore);
    }

    public void ObstacleHit()
    {
        currentScore -= 5000*gear; 
        
    }

    public void UpgradeHit()
    {
        upgradesHit +=1; 
    }

    public void IncrementGearLevel()
    {
        if (gearLevel < 8)
        {
            gearLevel += 1;

        }
        if (gearLevel == 8 && gear < 3)
        {
            gearLevel = 0;
            gear +=1;
            AkSoundEngine.PostEvent("GearShift", gameObject);
        }

        // RPM informs the pitch of the engine ambient sound
        RPM.SetGlobalValue((gearLevel + gear) * 10);
    }

    public void LostStreak()
    {
        Debug.Log("gear -1");
        if (gear == 1)
        {
            gear = 1;
        }
        else
        {
            gear -= 1;
        }        
        gearLevel = 1;

        RPM.SetGlobalValue((gearLevel + gear) * 10);
    }

    //needs to be called as a player calls a user defined threshold
    public void AssessPerformance()
    {
        
        Debug.Log("AssessPerformanceCalled");

        UnityEngine.Vector3 currentPosition = new UnityEngine.Vector3();

        if (gear == 1)
        {
            //change speed of BG
            frontBG.GetComponent<BackgroundMovement>().speed = -40;
            backBG.GetComponent<BackgroundMovement>().speed = -30;
            clutter.GetComponent<BackgroundMovement>().speed = -40;
            //change camera FOV
            cameraObj.fieldOfView = Mathf.Lerp(cameraObj.fieldOfView, gearOneFOV, fovSpeed);

            if (currentPhraseLevel != 1)
            {
                
                //translate current road to placeholder xposition;
                currentPosition = currentRoad.transform.position;
                currentRoad.transform.position = new UnityEngine.Vector3(300, 0, 200);
                //translate road 1 to road xposition;
                diff1Road.transform.position = currentPosition;
                //set current road to road1
                currentRoad = diff1Road;
                //set currentPhraseLevel to 1
                currentPhraseLevel = 1;
                //CHANGE TO LOW MUSIC TRACK
                AkSoundEngine.PostEvent("SpeedOfSoundMEDMute", gameObject);
                AkSoundEngine.PostEvent("SpeedOfSoundHIGHMute", gameObject);
                AkSoundEngine.PostEvent("SpeedOfSoundLOWUnmute", gameObject);
                Debug.Log("LOW MUSIC TRACK PLAYING");
                
            }


        }

        if (gear == 2)
        {
            //change speed of BG
            frontBG.GetComponent<BackgroundMovement>().speed = -80;
            backBG.GetComponent<BackgroundMovement>().speed = -60;
            clutter.GetComponent<BackgroundMovement>().speed = -40;

            //change camera FOV
            cameraObj.fieldOfView = Mathf.Lerp(cameraObj.fieldOfView, gearTwoFOV, fovSpeed);

            //load difficulty 1 next section

            if (currentPhraseLevel != 2)
            {

                currentPosition = currentRoad.transform.position;
                currentRoad.transform.position = new UnityEngine.Vector3(400, 0, 200);
                //translate road 1 to road xposition;
                diff2Road.transform.position = currentPosition;
                //set current road to road1
                currentRoad = diff2Road;
                //set currentPhraseLevel to 1
                currentPhraseLevel = 2;
                //CHANGE TO MEDIUM MUSIC TRACK
                AkSoundEngine.PostEvent("SpeedOfSoundMEDUnmute", gameObject);
                AkSoundEngine.PostEvent("SpeedOfSoundHIGHMute", gameObject);
                AkSoundEngine.PostEvent("SpeedOfSoundLOWMute", gameObject);
                Debug.Log("MEDIUM MUSIC TRACK PLAYING");
            }

            //diff2Road.transform.position.x == 
        }

        if (gear ==3)
        {
            //change speed of BG
            frontBG.GetComponent<BackgroundMovement>().speed = -100;
            backBG.GetComponent<BackgroundMovement>().speed = -80;
            clutter.GetComponent<BackgroundMovement>().speed = -40;

            //change camera FOV
            cameraObj.fieldOfView = Mathf.Lerp(cameraObj.fieldOfView, gearThreeFOV, fovSpeed);
            //load difficulty 3 next section

            if (currentPhraseLevel != 3)
            {
                currentPosition = currentRoad.transform.position;
                //translate road 1 to road xposition;
                currentRoad.transform.position = new UnityEngine.Vector3(500, 0, 200);

                diff3Road.transform.position = currentPosition;
                //set current road to road1
                currentRoad = diff3Road;
                //set currentPhraseLevel to 1
                currentPhraseLevel = 3;
                //CHANGE TO HIGH MUSIC TRACK
                AkSoundEngine.PostEvent("SpeedOfSoundHIGHUnmute", gameObject);
                AkSoundEngine.PostEvent("SpeedOfSoundMEDMute", gameObject);
                AkSoundEngine.PostEvent("SpeedOfSoundLOWMute", gameObject);
                Debug.Log("HIGH MUSIC TRACK PLAYING");
            }

        }

        
    }

    void PoliceLights()
    {
        if (gear == 1 && gearLevel <= 3 && currentPhraseLevel == 1)
        {
            policeLights.SetActive(true);

        }
        else
        {
            policeLights.SetActive(false);
        }
    }

}