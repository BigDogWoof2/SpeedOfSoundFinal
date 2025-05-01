using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Note detection class by Fraser Sutherland. Needs to detect collisions with incoming notes, and determine if player is within the perfect note range or not, determined by a pair of nested colliders
//When player hits a larger collider, they enter the satisfactory note range, and when they hit a second smaller collider, they enter the perfect note range
public class NoteDetector : MonoBehaviour
{


    [SerializeField] private GameObject GameManagerObject;
    //holds current lane number
    int laneNumber;

    //when a bar collider covering the whole width of the track collides with another object
    void OnTriggerEnter(Collider otherCollider)
    {
        //first determine if the other object is note
        if(otherCollider.gameObject.tag == "Note"){

            // Set strumValue in GameLoopClass based on other's collider type
            if (otherCollider.GetType().ToString().Equals("UnityEngine.CapsuleCollider"))
            {

                Debug.Log("Collide with decent");
                GameManagerObject.GetComponent<GameLoopClass>().strumValue = GameLoopClass.Strum.decent;

            }

            if (otherCollider.GetType().ToString().Equals("UnityEngine.BoxCollider"))
            {
                Debug.Log("Collide with perfect");
                GameManagerObject.GetComponent<GameLoopClass>().strumValue = GameLoopClass.Strum.perfect;

            }
            
            // Send lane value to GameLoop, needs to be done so people can't hit notes on lanes they aren't in
            if (otherCollider.gameObject.transform.parent.name == "Lane0")
            {
                Debug.Log("Lane0");
                laneNumber = 0; 
                SendLane(laneNumber);
            }

            else if (otherCollider.gameObject.transform.parent.name == "Lane1")
            {
                Debug.Log("Lane1");
                laneNumber = 1; 
                SendLane(laneNumber);
            }

            else if (otherCollider.gameObject.transform.parent.name == "Lane2")
            {
                Debug.Log("Lane2");
                laneNumber = 2; 
                SendLane(laneNumber);
            }

            else if (otherCollider.gameObject.transform.parent.name == "Lane3")
            {
                Debug.Log("Lane3");
                laneNumber = 3; 
                SendLane(laneNumber);
            }

        }
    }
    //Now when players leave a note's colliders, the progressively fall off from perfect to decent, and decent back to the rest state of a failed note
    void OnTriggerExit(Collider otherCollider)
    {
        if(otherCollider.gameObject.tag == "Note"){

            Debug.Log("detector exits note " + otherCollider.name);

            // Set strumValue in GameLoopClass based on other's collider type
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

    

    //sends the lane number of the most recent note to the GameLoop Class

    void SendLane(int laneNumber)
    {
        GameManagerObject.GetComponent<GameLoopClass>().noteLaneNumber = laneNumber;
    }



}
