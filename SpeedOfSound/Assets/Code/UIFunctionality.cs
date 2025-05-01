using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIFunctionality : MonoBehaviour
{
    //Phrase Level Bar
    [SerializeField] private UnityEngine.UI.Image phraseBar;
    [SerializeField] private Sprite levelOneSprite;
    [SerializeField] private Sprite levelTwoSprite;
    [SerializeField] private Sprite levelThreeSprite;
    [SerializeField] private GameObject managerRef;

    //Portrait Changes
    [SerializeField] private UnityEngine.UI.Image portrait;
    [SerializeField] private Sprite miss;
    [SerializeField] private Sprite okay;
    [SerializeField] private Sprite perfect;

    //Portait Bounce
    [SerializeField] private float sizeChange = 1.2f;
    [SerializeField] private Vector3 startSize;

    void Start()
    {
        startSize = portrait.transform.localScale;
    }

    void Update()
    {
        if (managerRef.GetComponent<ScoreScript>().currentPhraseLevel == 1)
        {
            phraseBar.sprite = levelOneSprite;
        }
        if (managerRef.GetComponent<ScoreScript>().currentPhraseLevel == 2)
        {
            phraseBar.sprite = levelTwoSprite;
        }
        if (managerRef.GetComponent<ScoreScript>().currentPhraseLevel == 3)
        {
            phraseBar.sprite = levelThreeSprite;
        }
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
