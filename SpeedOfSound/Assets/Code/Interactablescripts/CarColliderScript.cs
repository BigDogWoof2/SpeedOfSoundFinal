using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColliderScript : MonoBehaviour
{
   

    [SerializeField] private ScoreScript scoreScriptRef;
    [SerializeField] private GameObject difficultyChecker;

    void Start()
    {
        
    }


    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "Obstacle")
        {
            Debug.Log("Hit Obstacle");
            scoreScriptRef.ObstacleHit();
        }

        if (otherCollider.gameObject.tag == "Upgrade")
        {
            Debug.Log("Hit upgrade");
            scoreScriptRef.UpgradeHit();
        }

        if ((otherCollider.gameObject.tag == "DiffCheck") && otherCollider.GetType().ToString().Equals("UnityEngine.CapsuleCollider"))
        {
            Debug.Log("Change Text");
            difficultyChecker.GetComponent<DifficultyChecker>().ChangeText();
        }

        if ((otherCollider.gameObject.tag == "DiffCheck") && otherCollider.GetType().ToString().Equals("UnityEngine.BoxCollider"))
        {
            Debug.Log("Change Difficulty");
            scoreScriptRef.GetComponent<ScoreScript>().AssessPerformance();
        }
    }

}
