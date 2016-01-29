using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    internal int brushPlayerScore;
    internal int germPlayerScore;

    internal float timePlayedThisRound;

    internal int roundNumber;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // count until max round time and check winner

    }

    // endgame (call func if cavity or if time out) with winner flag
    // also check if someone reached 3 wins, if yes, final winner show
    // level up the loser
    // reset the whole game
}
