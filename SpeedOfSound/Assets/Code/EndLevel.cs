using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndLevel : MonoBehaviour
{

    [SerializeField] ScoreScript scoreScriptRef;
    // Start is called before the first frame update
    [SerializeField] GameObject scoreScreen;

    [SerializeField] TextMeshProUGUI totalScoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndLevelTriggered()
    {
        //Set active score screen UI element
        CreateScoreScreen();

    }

    void CreateScoreScreen()
    {
        scoreScreen.SetActive(true);

        totalScoreText.text = scoreScriptRef.currentScore.ToString();
    }



}
