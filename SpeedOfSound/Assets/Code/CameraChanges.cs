using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraChanges : MonoBehaviour
{
    
    [SerializeField] Camera cameraObj;
    [SerializeField] float maxFov;
    [SerializeField] float defaultFov;
    [SerializeField] float zoomSpeed = 0.1f;
    [SerializeField] GameObject managerRef;
    [SerializeField] PostProcessLayer postProcessing;

    // Start is called before the first frame update
    void Start()
    {
        zoomSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (managerRef.GetComponent<ScoreScript>().currentPhraseLevel == 1)
        {
            defaultFov = 40f;
            maxFov = 30f;
            postProcessing.enabled = false;
        }
        if (managerRef.GetComponent<ScoreScript>().currentPhraseLevel == 2)
        {
            defaultFov = 50f;
            maxFov = 40f;
            postProcessing.enabled = false;

        }
        if (managerRef.GetComponent<ScoreScript>().currentPhraseLevel == 3)
        {
            defaultFov = 60f;
            maxFov = 50f;

            postProcessing.enabled = true;

        }
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraObj.fieldOfView = Mathf.Lerp(cameraObj.fieldOfView, maxFov, zoomSpeed);

        }
        else
        {
            cameraObj.fieldOfView = Mathf.Lerp(cameraObj.fieldOfView, defaultFov, zoomSpeed);
        }   

    }
}
