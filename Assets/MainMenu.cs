using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void StopBrushing (){
			Application.Quit ();
	}

	public void StartGame(){
		Application.LoadLevel ("mouth");
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
