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

    public void OnButtonHover()
    {
        AkSoundEngine.PostEvent("UI_ButtonHover", gameObject);
    }

    public void LoadLevel(){
        AkSoundEngine.PostEvent("UI_NewGame", gameObject);
        AkSoundEngine.PostEvent("StopTitleScreenMusic", gameObject);
        SceneManager.LoadScene("SampleScene");
    }

    public void OptionsClick()
    {
        AkSoundEngine.PostEvent("UI_ContextOpen", gameObject);
    }

    public void QuitClick()
    {
        AkSoundEngine.PostEvent("UI_Quit", gameObject);
    }
}
