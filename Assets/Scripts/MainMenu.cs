using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    GameObject qb;

    void Start()
    {
#if UNITY_WEBPLAYER || UNITY_WEBGL
        // hide button if on web platform
        qb = GameObject.FindGameObjectWithTag("quit_button");
        qb.SetActive(false);
#endif

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    public void StopBrushing ()
    {
			Application.Quit();
	}

	public void StartGame()
    {
		Application.LoadLevel("mouth");
	}
    
}
