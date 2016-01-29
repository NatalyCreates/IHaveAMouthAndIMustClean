﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    internal int brushPlayerScore = 0;
    internal int germPlayerScore = 0;

    internal int timePlayedThisRound = 0;
    internal int lastRoundStartedTime = 0;

    internal int timeLeftThisRound = 0;

    internal int roundNumber = 1;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        timePlayedThisRound = (int)Time.time - lastRoundStartedTime;
        //Helper.Instance.Print("timePlayedThisRound = " + timePlayedThisRound.ToString());
        //Helper.Instance.Print("lastRoundStartedTime = " + lastRoundStartedTime.ToString());
        //Helper.Instance.Print("roundTime = " + Settings.Instance.roundTime.ToString());
        
        if (timePlayedThisRound >= Settings.Instance.roundTime + 1)
        {
            lastRoundStartedTime = (int)Time.time;
            timePlayedThisRound = 0;
            Helper.Instance.Print("time over");
            // stop game
            Application.Quit();
        }

        timeLeftThisRound = Settings.Instance.roundTime - timePlayedThisRound;

        // count until max round time and check winner

    }

    // endgame (call func if cavity or if time out) with winner flag
    // also check if someone reached 3 wins, if yes, final winner show
    // level up the loser
    // reset the whole game
}
