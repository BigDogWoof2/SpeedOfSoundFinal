using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base class created by Fraser Welsh. Controls all movement changes for 2D game elements.
public class UIMovement : MonoBehaviour
{
    public float uiSize = 10f;      //How much the HUD moves
    public float uiSpeed = 2f;      //How quickly it moves.
    private bool canRotate;
    private bool moveLeft;
    private bool moveRight;
    private bool resetRot;
    [SerializeField] GameObject managerRef;
    public RectTransform rectTransform;
    private Vector3 defaultPos;
 
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        defaultPos = rectTransform.localPosition;
    }

    void Update()
    {   
        //Hud moves more quickly when in higher gear
        if (managerRef.GetComponent<ScoreScript>().currentPhraseLevel == 3)
        {
            uiSpeed = 4f;
        }

        //HUD currently moves on a wave. Can add noise, but don't want score, gear information etc to become difficult to read.
        float xMovement = Mathf.Sin(Time.time * uiSpeed) * uiSize;
        float yMovement = Mathf.Sin(Time.time * uiSpeed) * uiSize;
        rectTransform.localPosition = defaultPos + new Vector3(xMovement, yMovement, 0);

        //Rotates the entire HUD left or right when switching lanes.
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
