using UnityEngine;
using System.Collections;

public class MenuSoundManager : MonoBehaviour {

    public static MenuSoundManager Instance;

	// Use this for initialization
	void Start () {
	
	}

    void Awake ()
    {
        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayMenuClickSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

}
