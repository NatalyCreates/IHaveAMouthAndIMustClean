﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {

    GameObject qb;

    AudioSource musicObj, sfxObj;

    Slider musicVolumeSlider, sfxVolumeSlider, brushDifSlider, germDifSlider;
    GameObject currentMusicVolumeText, currentSfxVolumeText, currentBrushDifText, currentGermDifText;

    bool flag_ok = false;

    void Awake()
    {
        Debug.Log("AWAKE MainMenu");

        musicObj = GameObject.FindGameObjectWithTag("music_obj").GetComponent<AudioSource>();
        sfxObj = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();

        musicVolumeSlider = GameObject.FindGameObjectWithTag("musvol_slider").GetComponent<Slider>();
        sfxVolumeSlider = GameObject.FindGameObjectWithTag("sfxvol_slider").GetComponent<Slider>();
        brushDifSlider = GameObject.FindGameObjectWithTag("bdif_slider").GetComponent<Slider>();
        germDifSlider = GameObject.FindGameObjectWithTag("gdif_slider").GetComponent<Slider>();
        currentMusicVolumeText = GameObject.FindGameObjectWithTag("musvol_curtext");
        currentSfxVolumeText = GameObject.FindGameObjectWithTag("sfxvol_curtext");
        currentBrushDifText = GameObject.FindGameObjectWithTag("bdif_curtext");
        currentGermDifText = GameObject.FindGameObjectWithTag("gdif_curtext");

    }

    void Start()
    {
#if UNITY_WEBPLAYER || UNITY_WEBGL
        // hide button if on web platform
        qb = GameObject.FindGameObjectWithTag("quit_button");
        qb.SetActive(false);
#endif

        Debug.Log("START MainMenu");

        // Load
        float xPos;
        // Music Volume
        musicVolumeSlider.value = PlayerPrefs.GetFloat("Settings_musicVolume", 60.0f);
        xPos = musicVolumeSlider.handleRect.position.x;
        currentMusicVolumeText.transform.position = new Vector3(xPos, currentMusicVolumeText.transform.position.y, 0);
        currentMusicVolumeText.GetComponent<Text>().text = ((int)musicVolumeSlider.value).ToString();
        float musicVol = 0.2f * musicVolumeSlider.value / 100;
        musicObj.volume = musicVol;
        // Sfx Volume
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("Settings_sfxVolume", 90.0f);
        xPos = sfxVolumeSlider.handleRect.position.x;
        currentSfxVolumeText.transform.position = new Vector3(xPos, currentSfxVolumeText.transform.position.y, 0);
        currentSfxVolumeText.GetComponent<Text>().text = ((int)sfxVolumeSlider.value).ToString();
        float sfxVol = 1.0f * sfxVolumeSlider.value / 100;
        sfxObj.volume = sfxVol;
        // Music Volume
        brushDifSlider.value = PlayerPrefs.GetFloat("Settings_brushDif", 2.0f);
        xPos = brushDifSlider.handleRect.position.x;
        currentBrushDifText.transform.position = new Vector3(xPos, currentBrushDifText.transform.position.y, 0);
        currentBrushDifText.GetComponent<Text>().text = ((int)brushDifSlider.value).ToString();
        // Music Volume
        germDifSlider.value = PlayerPrefs.GetFloat("Settings_germDif", 2.0f);
        xPos = germDifSlider.handleRect.position.x;
        currentGermDifText.transform.position = new Vector3(xPos, currentGermDifText.transform.position.y, 0);
        currentGermDifText.GetComponent<Text>().text = ((int)germDifSlider.value).ToString();
        flag_ok = true;
        Debug.Log(currentGermDifText.transform.position.y);

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void MoveAllWithSliders()
    {

        if (flag_ok)
        {
            float newValue, xPos;

            newValue = musicVolumeSlider.value;
            xPos = musicVolumeSlider.handleRect.position.x;
            currentMusicVolumeText.transform.position = new Vector3(xPos, currentMusicVolumeText.transform.position.y, 0);
            currentMusicVolumeText.GetComponent<Text>().text = ((int)newValue).ToString();
            PlayerPrefs.SetFloat("Settings_musicVolume", musicVolumeSlider.value);
            float musicVol = 0.2f * musicVolumeSlider.value / 100;
            musicObj.volume = musicVol;

            newValue = sfxVolumeSlider.value;
            xPos = sfxVolumeSlider.handleRect.position.x;
            currentSfxVolumeText.transform.position = new Vector3(xPos, currentSfxVolumeText.transform.position.y, 0);
            currentSfxVolumeText.GetComponent<Text>().text = ((int)newValue).ToString();
            PlayerPrefs.SetFloat("Settings_sfxVolume", sfxVolumeSlider.value);
            float sfxVol = 1.0f * sfxVolumeSlider.value / 100;
            sfxObj.volume = sfxVol;

            newValue = brushDifSlider.value;
            xPos = brushDifSlider.handleRect.position.x;
            currentBrushDifText.transform.position = new Vector3(xPos, currentBrushDifText.transform.position.y, 0);
            currentBrushDifText.GetComponent<Text>().text = ((int)newValue).ToString();
            PlayerPrefs.SetFloat("Settings_brushDif", brushDifSlider.value);

            newValue = germDifSlider.value;
            xPos = germDifSlider.handleRect.position.x;
            currentGermDifText.transform.position = new Vector3(xPos, currentGermDifText.transform.position.y, 0);
            currentGermDifText.GetComponent<Text>().text = ((int)newValue).ToString();
            PlayerPrefs.SetFloat("Settings_germDif", germDifSlider.value);
        }
        
    }

    public void StopBrushing()
    {
			Application.Quit();
	}

	public void StartGame()
    {
		Application.LoadLevel("mouth");
	}
    
}
