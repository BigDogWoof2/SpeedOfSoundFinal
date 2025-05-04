using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBuildings : MonoBehaviour
{
    float repeatWidth;
    UnityEngine.Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z/2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        } 
    }
}
