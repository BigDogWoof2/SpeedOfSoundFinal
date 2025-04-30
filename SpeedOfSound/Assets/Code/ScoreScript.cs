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
    [SerializeField] private float policeDistance;
    [SerializeField] private GameObject policeLights;
    private UnityEngine.Vector3 plStartPos;
    private UnityEngine.Vector3 plEndPos;

    //Wwise RealTime Parameter Controls
    [SerializeField] AK.Wwise.RTPC WindSpeed = null;
    [SerializeField] AK.Wwise.RTPC RPM = null;
    [SerializeField] AK.Wwise.RTPC PoliceDistance = null;


    void Start()
    {
        baseNoteScore = 500;
        baseDistanceScore = 1;
        gear = 2;
        currentScore = 0;
        gearLevel = 0;
        currentPhraseLevel = 1;
          
        PoliceEffects();
    }

    void Update()
    {
        scoreText.text = currentScore.ToString();
        multText.text = gear.ToString();
        gearLevelText.text = gearLevel.ToString();

        AddDistanceScore();
        
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

    public void IncrementGearLevel(int value)
    {

        if (gearLevel >= 8 && gear < 3 && value > 0)
        {
            gear += 1;
            gearLevel = 1;
            AkSoundEngine.PostEvent("SFX_GearShift", gameObject);
        }
        else if (gearLevel <= 1 && gear > 1 && value < 0)
        {
            gear -= 1;
            gearLevel = 4;
            //AkSoundEngine.PostEvent("SFX_GearShiftDown", gameObject);
        }
        else
        {
            gearLevel = Mathf.Clamp(gearLevel + value, 1, 8);
        }

        PoliceEffects();
        AmbientEffects();
    }

    //needs to be called as a player calls a user defined threshold
    public void AssessPerformance()
    {
        Debug.Log("AssessPerformanceCalled");
        PoliceEffects();
        AmbientEffects();

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
                AkSoundEngine.PostEvent("BGM_SpeedOfSoundMEDMute", gameObject);
                AkSoundEngine.PostEvent("BGM_SpeedOfSoundHIGHMute", gameObject);
                AkSoundEngine.PostEvent("BGM_SpeedOfSoundLOWUnmute", gameObject);
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
                AkSoundEngine.PostEvent("BGM_SpeedOfSoundMEDUnmute", gameObject);
                AkSoundEngine.PostEvent("BGM_SpeedOfSoundHIGHMute", gameObject);
                AkSoundEngine.PostEvent("BGM_SpeedOfSoundLOWMute", gameObject);
                Debug.Log("MEDIUM MUSIC TRACK PLAYING");
            }

            //diff2Road.transform.position.x == 
        }

        if (gear == 3)
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
                AkSoundEngine.PostEvent("BGM_SpeedOfSoundHIGHUnmute", gameObject);
                AkSoundEngine.PostEvent("BGM_SpeedOfSoundMEDMute", gameObject);
                AkSoundEngine.PostEvent("BGM_SpeedOfSoundLOWMute", gameObject);
                Debug.Log("HIGH MUSIC TRACK PLAYING");
            }
        }
    }

    
    void AmbientEffects()
    {
        WindSpeed.SetGlobalValue(gearLevel + (gear - 1) * 8 + (currentPhraseLevel - 1) * 24);
        RPM.SetGlobalValue((gearLevel + gear) * 10);
    }

    void PoliceEffects() // Called at every gearLevel change and performanceassess
    {
        if (currentPhraseLevel == 1)
        {
            switch (gear)
            {
                case 1: // Distance will be between 0 and 64
                    policeDistance = 0 + gearLevel * 8;
                    // Enable police lights if below gearLevel 4
                    if (gearLevel <= 4) { 
                        policeLights.SetActive(true);
                        // Move lights closer the lower the gearLevel is
                        policeLights.transform.position = new UnityEngine.Vector3(229, 7, gearLevel * -8);
                    } else { 
                        policeLights.SetActive(false);
                    }
                    break;

                case 2: // Distance will be between 68 and 100
                    policeDistance = 68 + gearLevel * 4;
                    policeLights.SetActive(false);
                    break;

                case 3:
                    policeDistance = 100;
                    policeLights.SetActive(false);
                    break;
            }
        }
        else
        {
            policeDistance = 100;
            policeLights.SetActive(false);
        }

        PoliceDistance.SetGlobalValue(policeDistance);
    }

}