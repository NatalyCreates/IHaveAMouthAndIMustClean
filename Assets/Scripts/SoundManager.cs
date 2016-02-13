using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance;

    public AudioClip germifyClip, brushRightClip, brushLeftClip, timesUpClip, roundOverClip;

    AudioSource musicObj;

    float vol, mvol;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {

        mvol = PlayerPrefs.GetFloat("Settings_musicVolume", 60.0f);
        musicObj = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        musicObj.volume = 0.25f * mvol / 100;

        vol = PlayerPrefs.GetFloat("Settings_sfxVolume", 90.0f) * 1.0f / 100;

    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Instance.timesUpSoundPlaying)
        {
            musicObj.volume = 0;
        }
        else if (GameManager.Instance.gamePaused)
        {
            musicObj.volume = 0;
        }
        else if (Helper.Instance.IsGameStateNeedToPause())
        {
            musicObj.volume = 0;
        }
        else
        {
            musicObj.volume = 0.25f * mvol / 100;
        }
	}

    public void PlayBrushRightSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(brushRightClip, vol);
    }

    public void PlayBrushLeftSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(brushLeftClip, vol);
    }

    public void PlayBrushUpSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(brushRightClip, vol);
    }

    public void PlayBrushDownSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(brushLeftClip, vol);
    }

    public void PlayGermifySound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(germifyClip, vol);
    }

    public void PlayTimesUpSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(timesUpClip, vol);
    }

    public void PlayRoundOverSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(roundOverClip, vol * 2.0f);
    }

}
