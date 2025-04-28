using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetector : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject GameManagerObject;

    int laneNumber;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerEnter(Collider otherCollider)
    {

        

        

        if(otherCollider.gameObject.tag == "Note"){

            if (otherCollider.GetType().ToString().Equals("UnityEngine.CapsuleCollider"))
            {

                Debug.Log("Collide with decent");
                GameManagerObject.GetComponent<GameLoopClass>().strumValue = GameLoopClass.Strum.decent;

            }

            //Debug.Log("decector collides with note" + otherCollider.name);

            if (otherCollider.GetType().ToString().Equals("UnityEngine.BoxCollider"))
            {
                Debug.Log("Collide with perfect");
                GameManagerObject.GetComponent<GameLoopClass>().strumValue = GameLoopClass.Strum.perfect;

            }
            
            if (otherCollider.gameObject.transform.parent.name == "Lane0")
            {
                //need to sent this information to GameLoop
                Debug.Log("Lane0");
                laneNumber = 0; 
                SendLane(laneNumber);
            }

            if (otherCollider.gameObject.transform.parent.name == "Lane1")
            {
                //need to sent this information to GameLoop
                Debug.Log("Lane1");
                laneNumber = 1; 
                SendLane(laneNumber);
            }

            if (otherCollider.gameObject.transform.parent.name == "Lane2")
            {
                //need to sent this information to GameLoop
                Debug.Log("Lane2");
                laneNumber = 2; 
                SendLane(laneNumber);
            }

            if (otherCollider.gameObject.transform.parent.name == "Lane3")
            {
                //need to sent this information to GameLoop
                Debug.Log("Lane3");
                laneNumber = 3; 
                SendLane(laneNumber);
            }

            

        }
    }

    void OnTriggerExit(Collider otherCollider)
    {
        if(otherCollider.gameObject.tag == "Note"){

            Debug.Log("detector exits note " + otherCollider.name);

            if (otherCollider.GetType().ToString().Equals("UnityEngine.BoxCollider"))
            {
                GameManagerObject.GetComponent<GameLoopClass>().strumValue = GameLoopClass.Strum.decent;
                Debug.Log("Leave perfect");
            }

            if (otherCollider.GetType().ToString().Equals("UnityEngine.CapsuleCollider"))
            {

                Debug.Log("Leave decent");
                GameManagerObject.GetComponent<GameLoopClass>().strumValue = GameLoopClass.Strum.fail;                

            }                    
            
        }
    }

    //for detecting perfect note we can use multiple colliders on the notes and get the type of the different colliders, saved in bookmarks

    

    void SendLane(int laneNumber)
    {
        GameManagerObject.GetComponent<GameLoopClass>().noteLaneNumber = laneNumber;
    }



}
