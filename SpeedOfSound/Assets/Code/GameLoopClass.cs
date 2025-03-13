using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopClass : MonoBehaviour
{
   
    [SerializeField] private ScoreScript scoreScriptRef;
    
    public enum Strum
    {
        fail,
        decent,
        perfect
    }

    private int carLaneNumber;

    public int noteLaneNumber;

    public Strum strumValue;

    [SerializeField] private int trackSpeed;

    public GameObject roadRef1;

    public GameObject roadRef2;

    public GameObject roadRef3;
    public GameObject carRef;

    private GameObject currentNote;

    private int notesHit;

    [SerializeField] private int notesInSection;


     // Start is called before the first frame update
    void Start()
    {
        strumValue = Strum.fail; 

        carLaneNumber = 1;

        trackSpeed = 5;
        
    }
   
   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            //lane check here
         carRef.transform.Translate(3.84f, 0, 0);

         carLaneNumber +=1;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //lane check here
         carRef.transform.Translate(-3.84f, 0, 0);

         carLaneNumber -=1;
        }

        //Move the track towards the player, probably gonna need to change with art etc in
        roadRef1.transform.Translate(0, 0, (- 0.001f*trackSpeed) );
        roadRef2.transform.Translate(0, 0, (- 0.001f*trackSpeed) );
        roadRef3.transform.Translate(0, 0, (- 0.001f*trackSpeed) );

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Debug.Log("Spacebarhit");
            switch (strumValue)
            {
                case Strum.fail: 

                FailedNote();

                break;

                case Strum.decent: 

                DecentNoteHit();

                break;
                //if lane is correct then x, if lane incorrect then wrong note function called

                case Strum.perfect: 

                    if (carLaneNumber == noteLaneNumber)
                    {
                        PerfectNoteHit();
                        //execute perfect hit here
                    }

                    else
                    {
                        FailedNote();
                    }

                    break;

                default:

                //same as fail case

                break;

            }
        }

        //Debug.Log(noteLaneNumber.ToString()); Debugging notelanes

    }

    void PerfectNoteHit()
    {
        Debug.Log("Perfect note hit");
        scoreScriptRef.IncrementGearLevel();
        scoreScriptRef.AddPerfectNoteScore();
    }

    void DecentNoteHit()
    {
        Debug.Log("decent note hit");
        scoreScriptRef.AddNoteScore();
    }

    void FailedNote()
    {
        Debug.Log("NoteFailed");
        scoreScriptRef.LostStreak();
    }

    
}
