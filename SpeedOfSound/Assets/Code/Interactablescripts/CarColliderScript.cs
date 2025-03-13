using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColliderScript : MonoBehaviour
{
   

    [SerializeField] ScoreScript scoreScriptRef;

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
    }

}
