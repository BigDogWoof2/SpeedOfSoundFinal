using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
//Base game loop glass, base loop written by Fraser Sutherland, additional UI and tuning by Fraser Welsh
public class GameLoopClass : MonoBehaviour
{
   //reference to the score script
    [SerializeField] private ScoreScript scoreScriptRef;
    //enum that describes the quality of the player's strums
    public enum Strum
    {
        fail,
        decent,
        perfect
    }
    //hold the lane the car is currently in
    private int carLaneNumber;
    //holds the lane the current node is in
    public int noteLaneNumber;
    //holds the player's most recent strum value
    public Strum strumValue;
    //expose in the editor the track speed editor, determines how fast the world moves toward the player
    [SerializeField] private int trackSpeed;
    //reference to the lowest difficulty road object
    public GameObject roadRef1;
    //reference to medium difficulty road object
    public GameObject roadRef2;
    //reference to the highest difficulty road obect
    public GameObject roadRef3;
    //hold a reference to the car (really it's a bike but oh well) game object
    public GameObject carRef;
    //maybe redundant holder?
    private GameObject currentNote;
    //redundant for now, could be used for the score screen potentially, if we also count number of notes passed
    private int notesHit;

    [SerializeField] private GameObject perfectText;
    [SerializeField] private GameObject decentText;
    [SerializeField] private GameObject missText;
    [SerializeField] private GameObject portrait;
    [SerializeField] public GameObject uiRef;    

    [SerializeField] private int notesInSection;

    // Wwise RealTime Parameter Controls
    [SerializeField] AK.Wwise.RTPC PerfectCombo = null;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

     // Start is called before the first frame update
     //initialise strumValue to being a failed note, the starting lane for the car, and the track speed
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
    // Receive input from the player, and move car accordingly 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            //stops out of bounds movement
            if (carLaneNumber !=3)
            {
                //lane check here
                //move object to adjacent lane
                carRef.transform.Translate(3.84f, 0, 0);
                //update lane number
                carLaneNumber +=1;

                //rotate UI
                uiRef.GetComponent<UIMovement>().MoveRight();

                AkSoundEngine.PostEvent("SFX_SwitchLane", gameObject);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (carLaneNumber !=0)
            {
                //lane check here
                //moveobject to adjacent lane
                carRef.transform.Translate(-3.84f, 0, 0);
                //update lane number
                carLaneNumber -=1;

                //rotate UI
                uiRef.GetComponent<UIMovement>().MoveLeft();

                AkSoundEngine.PostEvent("SFX_SwitchLane", gameObject);
            }
           
        }

         //input for hitting a note, like strumming the bar on guitar hero. We need to check if the player is in the right lane, and hitting the note with the right timing       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebarhit");

            AkSoundEngine.PostEvent("SFX_NotePress", gameObject);

            // strumValue is set in NoteDetector.cs. Strum value is determined by a collision with a succession of colliders to determine if a note is a fail (base state), decent (positive), or perfect (more score and extra mult)
            switch (strumValue)
            {
                case Strum.fail: 
                //randomly strumming notes needs to be discouraged to prevent input spam
                FailedNote();

                break;
                //case where strum is roughly on time
                case Strum.decent: 
                    //checks if car is in the same lane as the note
                  if (carLaneNumber == noteLaneNumber)
                    {
                         DecentNoteHit();
                        //execute decent hit here
                    }
                    //if car/bike isn't in the right lane, the note needs to fail!
                    else
                    {
                        FailedNote();
                    }

                break;
                //case where strum is perfectly timed
                case Strum.perfect: 

                    if (carLaneNumber == noteLaneNumber)
                    {
                        PerfectNoteHit();
                        //execute perfect hit here
                    }
                    //if car/bike isn't in the right lane, the note needs to fail!
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

    //Carry out perfect hit behaviour
    void PerfectNoteHit()
    {
        Debug.Log("Perfect note hit");

        //NoteParticles(perfect);
        //noteParticles.Play();

        AkSoundEngine.PostEvent("SFX_NotePerfect", gameObject);
        //increment combo value for perfect SFX
        var pc = PerfectCombo.GetGlobalValue();
        PerfectCombo.SetGlobalValue(pc + 15);
        

        Instantiate(perfectText, transform.position, Quaternion.identity);
        //increase gear level, add perfect note score 
        scoreScriptRef.IncrementGearLevel(1);
        scoreScriptRef.AddPerfectNoteScore();
        portrait.GetComponent<UIFunctionality>().PerfectNote();
    }

    //Decent note behaviour
    void DecentNoteHit()
    {
        Debug.Log("decent note hit");

        //NoteParticles(decent);
        //noteParticles.Play();

        AkSoundEngine.PostEvent("SFX_NoteDecent", gameObject);
        //reset combo value
        PerfectCombo.SetGlobalValue(0);

        Instantiate(decentText, transform.position, Quaternion.identity);
        //add the base note score, no gear level bonus
        scoreScriptRef.AddNoteScore();
        portrait.GetComponent<UIFunctionality>().OkayNote();

    }

    //failed note behaviour
    void FailedNote()
    {
        Debug.Log("NoteFailed");
        //NoteParticles(miss);
        //noteParticles.Play();

        AkSoundEngine.PostEvent("SFX_NoteMiss", gameObject);
        //reset combo value
        PerfectCombo.SetGlobalValue(0);

        Instantiate(missText, transform.position, Quaternion.identity);
        //Lose gear level for missing note
        scoreScriptRef.IncrementGearLevel(-2);
        portrait.GetComponent<UIFunctionality>().MissedNote();

    }

    void CameraBounce()
    {

    }
    
}
