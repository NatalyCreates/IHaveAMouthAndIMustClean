using UnityEngine;
using System.Collections;

public class Helper : MonoBehaviour {

    public static Helper Instance;

    void Awake()
    {
        Instance = this;
    }

    public void Print (string text)
    {
        Debug.Log("IHAMAIMC" + text);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
