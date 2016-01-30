using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance;

    public AudioClip germifyClip, brushRightClip, brushLeftClip, timesUpClip;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayBrushRightSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(brushRightClip);
    }

    public void PlayBrushLeftSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(brushLeftClip);
    }

    public void PlayBrushUpSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(brushRightClip);
    }

    public void PlayBrushDownSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(brushLeftClip);
    }

    public void PlayGermifySound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(germifyClip);
    }

    public void PlayTimesUpSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(timesUpClip);
    }

}
