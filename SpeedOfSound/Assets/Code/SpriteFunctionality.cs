using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class SpriteFunctionality : MonoBehaviour
{
    //Phrase Level Bar
    [SerializeField] private UnityEngine.UI.Image phraseBar;
    [SerializeField] private Sprite levelOneSprite;
    [SerializeField] private Sprite levelTwoSprite;
    [SerializeField] private Sprite levelThreeSprite;
    [SerializeField] private int phraseLevel;
    [SerializeField] private GameObject managerRef;

    //Phrase Level Bar
    [SerializeField] private GameObject bike;
    [SerializeField] private Sprite laneOneSprite;
    [SerializeField] private Sprite laneTwoSprite;
    [SerializeField] private Sprite laneThreeSprite;
    [SerializeField] private Sprite laneZeroSprite;
    [SerializeField] private int laneNumber;

    //Portrait Changes
    [SerializeField] private UnityEngine.UI.Image portrait;
    [SerializeField] private Sprite miss;
    [SerializeField] private Sprite okay;
    [SerializeField] private Sprite perfect;

    //Portait Bounce
    [SerializeField] private float sizeChange = 1.2f;
    [SerializeField] private Vector3 startSize;

    //Distance to Escape
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private Transform playerPos;
    [SerializeField] private Transform diff1EndPos;
    [SerializeField] private Transform diff2EndPos;
    [SerializeField] private Transform diff3EndPos;
    [SerializeField] private float distanceToEnd;

    void Start()
    {
        startSize = portrait.transform.localScale;        
    }

    void Update()
    {
        phraseLevel = managerRef.GetComponent<ScoreScript>().currentPhraseLevel;
        laneNumber = managerRef.GetComponent<GameLoopClass>().carLaneNumber;

        switch(phraseLevel)
        {
            case(1):
                phraseBar.sprite = levelOneSprite;
                break;
            case(2):
                phraseBar.sprite = levelTwoSprite;
                break;
            case(3):
                phraseBar.sprite = levelThreeSprite;
                break;
        }

        switch(laneNumber)
        {
            case(0):
                bike.GetComponent<SpriteRenderer>().sprite = laneZeroSprite;
                break;
            case(1):
                bike.GetComponent<SpriteRenderer>().sprite = laneOneSprite;
                break;
            case(2):
                bike.GetComponent<SpriteRenderer>().sprite = laneTwoSprite;
                break;
            case(3):
                bike.GetComponent<SpriteRenderer>().sprite = laneThreeSprite;
                break;
        }

        if (phraseLevel == 1){distanceToEnd = Vector3.Distance(playerPos.position, diff1EndPos.position); distanceToEnd = Mathf.Round(distanceToEnd*10.0f); distanceText.text = distanceToEnd.ToString() + "m";}
        else if (phraseLevel == 2){distanceToEnd = Vector3.Distance(playerPos.position, diff2EndPos.position); distanceToEnd = Mathf.Round(distanceToEnd*10.0f); distanceText.text = distanceToEnd.ToString() + "m";}
        else if (phraseLevel == 3){distanceToEnd = Vector3.Distance(playerPos.position, diff3EndPos.position); distanceToEnd = Mathf.Round(distanceToEnd*10.0f); distanceText.text = distanceToEnd.ToString() + "m";}
        
            
    }

    public void MissedNote()
    {
        portrait.sprite = miss;
        portrait.transform.localScale = startSize * sizeChange;
        Invoke(nameof(Reset), 0.1f);
    }

    public void OkayNote()
    {
        portrait.sprite = okay;
        portrait.transform.localScale = startSize * sizeChange;
        Invoke(nameof(Reset), 0.1f);
    }

    public void PerfectNote()
    {
        portrait.sprite = perfect;
        portrait.transform.localScale = startSize * sizeChange;
        Invoke(nameof(Reset), 0.1f);
    }

    public void Reset()
    {
        portrait.transform.localScale = startSize;   
    }

}
