using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;

    Text timerText;

    void Awake ()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
        timerText = GameObject.FindGameObjectWithTag("timer_text").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {

        int minutes = GameManager.Instance.timeLeftThisRound / 60;
        int seconds = GameManager.Instance.timeLeftThisRound % 60;
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        //timerText.text = "01:00";
    }
}
