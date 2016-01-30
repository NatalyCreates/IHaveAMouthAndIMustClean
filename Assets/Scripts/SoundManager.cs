using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance;

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

    }

    public void StopBrushRightSound()
    {

    }

    public void PlayBrushLeftSound()
    {

    }

    public void StopBrushLeftSound()
    {

    }

    public void PlayGermifySound()
    {
        
    }

    public void PlayTimesUpSound()
    {
        
    }

    public void PlayFailedClickGermSound()
    {
        //gameObject.GetComponent<AudioListener>();
    }

}
