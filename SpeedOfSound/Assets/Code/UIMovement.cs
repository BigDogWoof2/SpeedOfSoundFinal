using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMovement : MonoBehaviour
{
    public float uiSize = 10f;
    public float uiSpeed = 2f;

    public RectTransform rectTransform;
    private Vector3 defaultPos;
    [SerializeField] GameObject managerRef;
 
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        defaultPos = rectTransform.localPosition;
    }

    void Update()
    {
        if (managerRef.GetComponent<ScoreScript>().currentPhraseLevel == 3)
        {
            uiSpeed = 4f;
        }
        
        float xMovement = Mathf.Sin(Time.time * uiSpeed) * uiSize;
        float yMovement = Mathf.Sin(Time.time * uiSpeed) * uiSize;
        rectTransform.localPosition = defaultPos + new Vector3(xMovement, yMovement, 0);

    }
}
