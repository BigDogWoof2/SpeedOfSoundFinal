using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyText : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f);
    }
}