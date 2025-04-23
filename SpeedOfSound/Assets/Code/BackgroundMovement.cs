using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float speed = -1.0f;

    void Update()
    {
        // Move the background sprites forward along the Z-axis every frame
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
