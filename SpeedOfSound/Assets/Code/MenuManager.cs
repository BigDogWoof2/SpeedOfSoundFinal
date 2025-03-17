using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AK.Wwise;
using static ak;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadLevel(){
        AkSoundEngine.PostEvent("StopTitleScreenMusic", gameObject);
        SceneManager.LoadScene("SampleScene");
    }
}
