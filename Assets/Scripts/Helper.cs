using UnityEngine;
using System.Collections;

public class Helper : MonoBehaviour {

    public static Helper Instance;

    void Awake()
    {
        Instance = this;
    }

    public bool IsGameStateNeedToPause()
    {
        if (GameManager.Instance.germScoreAnimPlayingGrow || GameManager.Instance.germScoreAnimPlayingShrink || GameManager.Instance.germLevelAnimPlaying ||
            GameManager.Instance.brushScoreAnimPlayingGrow || GameManager.Instance.brushScoreAnimPlayingShrink || GameManager.Instance.brushLevelAnimPlaying
            || GameManager.Instance.insScreen || GameManager.Instance.totalGameOver)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Print (string text)
    {
        Debug.Log("IHAMAIMC " + text);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
