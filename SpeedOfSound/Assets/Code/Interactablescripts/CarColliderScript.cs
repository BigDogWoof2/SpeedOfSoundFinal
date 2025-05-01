using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Base class by Fraser Sutherland, additional functionality by Fraser Welsh
//Triggers various events when the player vehicle object collides with certain objects such as obstacles, upgrades and difficulty checkers (spaced out through the level to adapt difficulty at certain sections)
public class CarColliderScript : MonoBehaviour
{
   
    //references to relecant scripts
    [SerializeField] private ScoreScript scoreScriptRef;
    [SerializeField] private GameObject difficultyChecker;

    void Start()
    {
        
    }

    //triggers appropriate functions when colliding with objects with various tags
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
