﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    internal int brushPlayerScore = 0;
    internal int germPlayerScore = 0;

    internal int timePlayedThisRound = 0;
    internal int lastRoundStartedTime = 0;

    internal int timeLeftThisRound = 0;

    internal int roundNumber = 1;

    Image brushWins, germWins, brushLevelUp, germLevelUp;

    bool brushWon = false;
    bool germWon = false;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        lastRoundStartedTime = (int)Time.time;
        brushPlayerScore = 0;
        germPlayerScore = 0;
        roundNumber = 1;

        brushWins = GameObject.FindGameObjectWithTag("brush_wins").GetComponent<Image>();
        germWins = GameObject.FindGameObjectWithTag("germ_wins").GetComponent<Image>();
        brushLevelUp = GameObject.FindGameObjectWithTag("brush_level_up").GetComponent<Image>();
        germLevelUp = GameObject.FindGameObjectWithTag("germ_level_up").GetComponent<Image>();

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
            //Helper.Instance.Print("time over");
            EndGame(true);
            // stop game
            Application.Quit();
        }

        timeLeftThisRound = Settings.Instance.roundTime - timePlayedThisRound;

        // count until max round time and check winner

        if (brushWon)
        {
            ShowBrushWinAnim();
        }
        if (germWon)
        {
            ShowGermWinAnim();
        }
    }

    void ShowBrushWinAnim()
    {
        float aParam = Mathf.Lerp(brushWins.color.a, 1f, Time.deltaTime * 3f);
        brushWins.color = new Color(1f, 1f, 1f, aParam);
        if (brushWins.color.a >= 0.98f)
        {
            // fade in ended
            brushWon = false;
            StartCoroutine(BackToMainMenu());
        }
    }

    void ShowGermWinAnim()
    {
        float aParam = Mathf.Lerp(germWins.color.a, 1f, Time.deltaTime * 3f);
        germWins.color = new Color(1f, 1f, 1f, aParam);
        if (germWins.color.a >= 0.98f)
        {
            // fade in ended
            germWon = false;
            StartCoroutine(BackToMainMenu());
        }
    }

    IEnumerator BackToMainMenu()
    {
        yield return new WaitForSeconds(3f);
        RetToMainMenu();
    }

    void RetToMainMenu()
    {
        Application.LoadLevel("Menu");
    }

    public void EndGame (bool brushWins)
    {
        if (brushWins)
        {
            brushPlayerScore += 1;
        }
        else
        {
            germPlayerScore += 1;
        }

        // show UI and animation of endgam

        if (brushPlayerScore >= 3)
        {
            // brush won overall

            // back to menu screen
            brushWon = true;
        }
        if (germPlayerScore >= 3)
        {
            // germs won overall

            // back to menu screen
            germWon = true;
        }
        else
        {
            GameObject[] allTeeth = GameObject.FindGameObjectsWithTag("all_teeth");
            foreach (GameObject area in allTeeth)
            {
                //if (area == null) { Debug.Log("IHAMAIMC area is null"); }
                //Debug.Log("IHAMAIMC area name:  " + area.name);
                area.GetComponent<ToothState>().resetToothState();
            }
            //reset timer
            lastRoundStartedTime = (int)Time.time;
            timePlayedThisRound = 0;
            //reset cooldown bar to the new level clickCooldownTime
            GermPlayer.Instance.reset();
            //set brush speed to 0
            
        }
    }

    // endgame (call func if cavity or if time out) with winner flag -done
    // also check if someone reached 3 wins, if yes, final winner show - done
    // level up the loser - not needed
    // reset the whole game - ????
}
