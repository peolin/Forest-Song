using System;
using System.Security.AccessControl;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    public GameObject mainMenu_panel;
    public GameObject settings_panel;
    public AudioSource audioSource;
    //public Toggle soundToggle;
    //public Slider soundSlider;
    // Start is called before the first frame update
    public void Start()
    {
        settings_panel.SetActive(false);
        //audioSource = GetComponent<AudioSource>();
    }

    public void Continue()
    {
        // check save files
    }

    public void New_game()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        settings_panel.SetActive(true);
        mainMenu_panel.SetActive(false);
    }

    public void Exit_app()
    {
        Application.Quit();
    }

    public void Close_settings_panel()
    {
        settings_panel.SetActive(false);
        mainMenu_panel.SetActive(true);
    }

    public void Sound_settings_toggle(System.Boolean toggleValue)
    {
        //System.Boolean toggleValue = 
        if (toggleValue == false)
        {
            Debug.Log("Turn off audio");
            audioSource.mute = true;
        } else
        {
            Debug.Log("Turn on audio");
            audioSource.mute = false;
        }
    }

    public void Volume_settings_slider(System.Single sliderValue)
    {
        audioSource.volume = sliderValue;
        Debug.Log("Sound volume is " + sliderValue);
    }
}
