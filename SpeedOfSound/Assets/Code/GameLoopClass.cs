using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
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

    [SerializeField] private GameObject perfectText;
    [SerializeField] private GameObject decentText;
    [SerializeField] private GameObject missText;    


    //Particle System
    //[SerializeField] private ParticleSystem noteParticles;
    //private Color perfect = Color.green;
    //private Color decent = Color.blue;
    //private Color miss = Color.red;

    [SerializeField] private int notesInSection;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

     // Start is called before the first frame update
    void Start()
    {
        strumValue = Strum.fail; 

        carLaneNumber = 1;

        trackSpeed = 400;
        
    }
   
    void FixedUpdate()
    {
        //Move the track towards the player, probably gonna need to change with art etc in
        roadRef1.transform.Translate(0, 0, (-0.4f));
        roadRef2.transform.Translate(0, 0, (-0.4f));
        roadRef3.transform.Translate(0, 0, (-0.4f));
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
                
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Debug.Log("Spacebarhit");

            // strumValue is set in NoteDetector.cs
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

        //NoteParticles(perfect);
        //noteParticles.Play();
        Instantiate(perfectText, transform.position, Quaternion.identity);

        scoreScriptRef.IncrementGearLevel();
        scoreScriptRef.AddPerfectNoteScore();
    }

    void DecentNoteHit()
    {
        Debug.Log("decent note hit");

        //NoteParticles(decent);
        //noteParticles.Play();
        Instantiate(decentText, transform.position, Quaternion.identity);

        scoreScriptRef.AddNoteScore();
    }

    void FailedNote()
    {
        Debug.Log("NoteFailed");

        //NoteParticles(miss);
        //noteParticles.Play();
        Instantiate(missText, transform.position, Quaternion.identity);

        scoreScriptRef.LostStreak();
    }

    void CameraBounce()
    {

    }

    //void NoteParticles(Color hitColour)
    //{
    //    var main = noteParticles.main;
    //    main.startColor = hitColour;
    //}

    
}
