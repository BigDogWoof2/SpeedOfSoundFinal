using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private Transform needle; //needle sprite
    [SerializeField] private float minAngle = 85f; //farthest left the needle can be    
    [SerializeField] private float maxAngle = -85f; //farthest right the needle can be
    [SerializeField] private float speed = 2f; //speed of switching angles
    [SerializeField] private float gearLevelSpeedometer = 0; //set the needle position to gear level 1
    [SerializeField] private GameObject managerObject; //reference to get gearLevel

    void Update()
    {
        //get gearLevel
        gearLevelSpeedometer = managerObject.GetComponent<ScoreScript>().gearLevel;
        
        //get target angle of needle
        float needleRot = (gearLevelSpeedometer -1) / 6f;
        float targetAngle = Mathf.Lerp(minAngle, maxAngle, needleRot);

        //rotate to target angle
        needle.rotation = Quaternion.Slerp(needle.rotation, Quaternion.Euler(0,0,targetAngle), Time.deltaTime * speed);

        //add slight shake when needle is at farthest right position (based on gearLevel's highest, which is 8) 
        if (gearLevelSpeedometer >= 7)
        {
            float shake = Mathf.Sin(Time.time * 40f) * 0.2f;
            shake += UnityEngine.Random.Range(-0.5f,0.5f);
            needle.rotation *= Quaternion.Euler(0,0,shake);
        }
    
    }

}
