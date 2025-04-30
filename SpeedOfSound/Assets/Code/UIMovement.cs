using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIMovement : MonoBehaviour
{
    public float uiSize = 10f;
    public float uiSpeed = 2f;

    public RectTransform rectTransform;
    private Vector3 defaultPos;
    private bool canRotate;
    private bool moveLeft;
    private bool moveRight;
    private bool resetRot;


    [SerializeField] GameObject managerRef;
 
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        defaultPos = rectTransform.localPosition;
        canRotate = false;
        resetRot = false;
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

        if(!canRotate && moveLeft)
        {
            rectTransform.rotation = Quaternion.Slerp(rectTransform.rotation, Quaternion.Euler(0,0,5), Time.deltaTime * 5f);
        }

        if(!canRotate && moveRight)
        {
            rectTransform.rotation = Quaternion.Slerp(rectTransform.rotation, Quaternion.Euler(0,0,-5), Time.deltaTime * 5f);
        }

        if (resetRot)
        {
            rectTransform.rotation = Quaternion.Slerp(rectTransform.rotation, Quaternion.Euler(0,0,0), Time.deltaTime * 10f);
        }

    }

    public void MoveLeft()
    {
        moveLeft = true;
        Invoke(nameof(ResetRotation), 1f);
    }

    public void MoveRight()
    {
        moveRight = true;
        Invoke(nameof(ResetRotation), 1f);
    }

    public void ResetRotation()
    {   
        moveLeft = false;
        moveRight = false;
        canRotate = false;
        resetRot = true;
    }
}
