using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private RectTransform needle;
   
    [SerializeField] private float minimumAngle = default;
    [SerializeField] private float maximumAngle = default;
    [SerializeField] private float minimumSpeed = default;
    [SerializeField] private float maximumSpeed = default;

    [SerializeField] private float animationSpeed;

    private float speed;

    private float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, minimumSpeed, maximumSpeed);
       
    }


    //private void OnDrawGizmos()
    //{
    //    var minRotation = Quaternion.AngleAxis(minimumAngle, Vector3.forward);
    //    var maxRotation = Quaternion.AngleAxis(maximumAngle, Vector3.forward);
    //    var minVector = minRotation * Vector3.up * 350f;
    //    var maxVector = maxRotation * Vector3.up * 350f;
    //
    //    Gizmos.DrawRay(transform.position, minVector);
    //    Gizmos.DrawRay(transform.position, maxVector);
    //}

    void Update()
    {
        var angle = Mathf.Lerp(minimumAngle, maximumAngle, Mathf.InverseLerp(minimumSpeed, maximumSpeed, Speed));
        var value = Mathf.Lerp(ClampDegrees(needle.eulerAngles.z),angle, Time.deltaTime * animationSpeed);

        needle.transform.rotation = Quaternion.Euler(0, 0, value);
    }

    private float ClampDegrees(float degrees)
    {
        var clamped = degrees;
        if (clamped > minimumAngle)
            clamped -= 360;        
        if (clamped < maximumAngle)
            clamped += 360;
        return clamped;

    }
    
}
