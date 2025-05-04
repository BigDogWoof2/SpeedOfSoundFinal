using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AK.Wwise;
using static ak;
//Initial class created by Fraser Sutherland just to load level, additional functionality by Lou Ling & Fraser Welsh
public class MenuManager : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject Splash;
    public GameObject Credits;


    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("BGM_StartupJingle", gameObject);
        Invoke("ShowMainMenu", 3);
    }

    public void ShowMainMenu()
    {
        Splash.SetActive(false);
        MainMenu.SetActive(true);
        AkSoundEngine.PostEvent("BGM_TitleScreenMusic", gameObject);
    }

    public void OnButtonHover()
    {
        AkSoundEngine.PostEvent("UI_ButtonHover", gameObject);
    }

    public void LoadLevel(){
        AkSoundEngine.PostEvent("UI_NewGame", gameObject);
        AkSoundEngine.PostEvent("BGM_StopTitleScreenMusic", gameObject);
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenCredits()
    {
        Credits.SetActive(true);
        MainMenu.SetActive(false);
        AkSoundEngine.PostEvent("UI_ContextOpen", gameObject);
    }

    public void BackClick()
    {
        Credits.SetActive(false);
        MainMenu.SetActive(true);
        AkSoundEngine.PostEvent("UI_Quit", gameObject);

    }

    public void QuitClick()
    {
        AkSoundEngine.PostEvent("UI_Quit", gameObject);
        Invoke("QuitGame", 1);
    }

    public void QuitGame()
    {
        // This will quit the game regardless of if it's in editor or in a build
        Debug.Log("Quitting game...");
        if (Application.isEditor)
        {
            //UnityEditor.EditorApplication.isPlaying = false;
        } else
        {
            Application.Quit();
        }
    }
}
