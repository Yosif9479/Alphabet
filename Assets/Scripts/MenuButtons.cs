using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public GameObject settingBlock;
    public Button soundButton;
    public Animator settingBlockAnim;
    public Sprite soundOn, soundOff;
    public static bool soundIsOn = true, settingsIsOpen = false;
    private string privacyPolicyUrl = "https://google.com";
    public string Name;
    public static string language = "tj";

    private void Awake()
    {
        if (Name != "Exit")
        {
            settingBlockAnim = settingBlock.GetComponent<Animator>();
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void toggleSettings()
    {
        if (settingsIsOpen == false)
        {
            openSettings();
        }
        else if (settingsIsOpen == true)
        {
            closeSettings();
        }
        settingsIsOpen = !settingsIsOpen;
    }

    public void openSettings()
    {
        settingBlockAnim.SetTrigger("Open");
    }

    public void closeSettings()
    {
        settingBlockAnim.SetTrigger("Close");
    }

    public void toggleSound()
    {
        soundIsOn = !soundIsOn;

        if (soundIsOn == true)
        {
            soundButton.GetComponent<Image>().sprite = soundOn;
        }

        else if (soundIsOn == false)
        {
            soundButton.GetComponent<Image>().sprite = soundOff;
        }
    }
    
    public void Rate()
    {
        Application.OpenURL("market://details?id=" + Application.identifier);
    }

    public void openPrivacyPolicy()
    {
        Application.OpenURL(privacyPolicyUrl);
    }

    public void previousScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        else
        {
            Exit();
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}