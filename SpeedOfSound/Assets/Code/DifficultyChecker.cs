using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyChecker : MonoBehaviour
{


    [SerializeField] private GameObject managerRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        
            Debug.Log("difficultyColissiondetected");
            managerRef.GetComponent<ScoreScript>().AssessPerformance();

        
        
    }
}
