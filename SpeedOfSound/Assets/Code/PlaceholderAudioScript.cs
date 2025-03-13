using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderAudioScript : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource source;
    public AudioClip gear1Trackl;
    void Start()
    {
        //source.PlayOneShot(gear1Trackl);

        
    }

    // Update is called once per frame
    void Update()
    {
        source.Play();
    }   
}