using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    Color brushScoreOrigCol, germScoreOrigCol;

    internal int brushPlayerScore = 0;
    internal int germPlayerScore = 0;

    internal int timePlayedThisRound = 0;
    internal int lastRoundStartedTime = 0;

    internal int timeLeftThisRound = 0;

    internal int roundNumber = 1;

    Image brushWins, germWins, brushLevelUp, germLevelUp, insImage;
    GameObject brushScore, germScore;

    bool brushWon = false;
    bool germWon = false;
    internal bool brushLevelAnimPlaying = false;
    internal bool germLevelAnimPlaying = false;

    internal bool brushScoreAnimPlayingGrow = false;
    internal bool brushScoreAnimPlayingShrink = false;
    internal bool germScoreAnimPlayingGrow = false;
    internal bool germScoreAnimPlayingShrink = false;

    internal bool timesUpSoundPlaying = false;

    public bool totalGameOver = false;
    public bool insScreen = true;

    bool fadingIns = false;

    internal bool gamePaused = false;
    GameObject pauser;
    float pauseTime = 0;

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
        
        gamePaused = false;
        pauser = GameObject.FindGameObjectWithTag("pauser");
        pauser.SetActive(false);

        brushWins = GameObject.FindGameObjectWithTag("brush_wins").GetComponent<Image>();
        germWins = GameObject.FindGameObjectWithTag("germ_wins").GetComponent<Image>();
        brushLevelUp = GameObject.FindGameObjectWithTag("brush_level_up").GetComponent<Image>();
        germLevelUp = GameObject.FindGameObjectWithTag("germ_level_up").GetComponent<Image>();
        brushScore = GameObject.FindGameObjectWithTag("brush_score_text");
        germScore = GameObject.FindGameObjectWithTag("germ_score_text");

        insImage = GameObject.FindGameObjectWithTag("ins").GetComponent<Image>();

        timesUpSoundPlaying = false;
        totalGameOver = false;
        brushLevelUp.transform.localPosition = new Vector2(0f,-600f);
        brushLevelUp.color = new Color(1f, 1f, 1f, 0f);
        germLevelUp.transform.localPosition = new Vector2(0f, -600f);
        germLevelUp.color = new Color(1f, 1f, 1f, 0f);
        insScreen = true;
        fadingIns = false;
        StartCoroutine(INSSSS());
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (insScreen)
            {
                fadingIns = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            if (gamePaused)
            {
                gamePaused = false;
                pauser.SetActive(false);
            }
            else
            {
                if ((timeLeftThisRound > 0) && !Helper.Instance.IsGameStateNeedToPause())
                {
                    gamePaused = true;
                    pauser.SetActive(true);
                }
            }
        }

        if (Helper.Instance.IsGameStateNeedToPause())
        {
            timePlayedThisRound = 0;
            lastRoundStartedTime = (int)Time.time;
        }
        else if (gamePaused)
        {
            pauseTime += Time.deltaTime;
        }
        else
        {
            timePlayedThisRound = (int)Time.time - lastRoundStartedTime - (int)pauseTime;

            if (timePlayedThisRound >= Settings.Instance.roundTime + 1)
            {
                lastRoundStartedTime = (int)Time.time;
                timePlayedThisRound = 0;
                EndGame(true);
            }
        }

        timeLeftThisRound = Settings.Instance.roundTime - timePlayedThisRound;

        if ((timeLeftThisRound <= 5f) && (!timesUpSoundPlaying))
        {
            SoundManager.Instance.PlayTimesUpSound();
            timesUpSoundPlaying = true;
        }

        // count until max round time and check winner

        if (brushWon)
        {
            ShowBrushWinAnim();
        }
        if (germWon)
        {
            ShowGermWinAnim();
        }
        if (brushLevelAnimPlaying)
        {
            brushLevelUp.color = new Color(1f, 1f, 1f, 1f);
            ShowBrushLevelUpAnim();
        }
        if (germLevelAnimPlaying)
        {
            germLevelUp.color = new Color(1f, 1f, 1f, 1f);
            ShowGermLevelUpAnim();
        }
        if (fadingIns && insScreen)
        {
            InsFadeOut();
        }
        if (brushScoreAnimPlayingGrow)
        {
            ShowBrushScoreAnimGrow();
        }
        if (germScoreAnimPlayingGrow)
        {
            ShowGermScoreAnimGrow();
        }
        if (brushScoreAnimPlayingShrink)
        {
            ShowBrushScoreAnimShrink();
        }
        if (germScoreAnimPlayingShrink)
        {
            ShowGermScoreAnimShrink();
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

    IEnumerator INSSSS()
    {
        yield return new WaitForSeconds(20f);
        if (insScreen) fadingIns = true;
    }

    void InsFadeOut()
    {
        float aParam = Mathf.Lerp(insImage.color.a, 0f, Time.deltaTime * 2.5f);
        insImage.color = new Color(1f, 1f, 1f, aParam);
        if (aParam <= 0.02f)
        {
            aParam = 0;
            insImage.color = new Color(1f, 1f, 1f, aParam);
            // fade in ended
            insScreen = false;
            // start game
            fadingIns = false;
        }
    }

    void ShowBrushScoreAnimGrow()
    {
        brushScore.GetComponent<Text>().color = Color.Lerp(brushScore.GetComponent<Text>().color, Color.red, 2.5f * Time.deltaTime);
        brushScore.transform.localScale = Vector2.Lerp(new Vector2(brushScore.transform.localScale.x, brushScore.transform.localScale.y), new Vector2(1.5f, 1.5f), 2f * Time.deltaTime);
        if ((brushScore.transform.localScale.x >= 1.49f) && (brushScore.transform.localScale.y >= 1.49f))
        {
            // grow ended
            brushScoreAnimPlayingShrink = true;
            brushScoreAnimPlayingGrow = false;
            brushScore.transform.localScale = new Vector2(1.5f, 1.5f);
            brushScore.GetComponent<Text>().color = Color.red;
        }
    }

    void ShowGermScoreAnimGrow()
    {
        germScore.GetComponent<Text>().color = Color.Lerp(germScore.GetComponent<Text>().color, Color.red, 2.5f * Time.deltaTime);
        germScore.transform.localScale = Vector2.Lerp(new Vector2(germScore.transform.localScale.x, germScore.transform.localScale.y), new Vector2(1.5f, 1.5f), 2f * Time.deltaTime);
        if ((germScore.transform.localScale.x >= 1.49f) && (germScore.transform.localScale.y >= 1.49f))
        {
            // grow ended
            germScoreAnimPlayingShrink = true;
            germScoreAnimPlayingGrow = false;
            germScore.transform.localScale = new Vector2(1.5f, 1.5f);
            germScore.GetComponent<Text>().color = Color.red;
        }
    }

    void ShowBrushScoreAnimShrink()
    {
        brushScore.GetComponent<Text>().color = Color.Lerp(brushScore.GetComponent<Text>().color, brushScoreOrigCol, 2.5f * Time.deltaTime);
        brushScore.transform.localScale = Vector2.Lerp(new Vector2(brushScore.transform.localScale.x, brushScore.transform.localScale.y), new Vector2(1f, 1f), 2f * Time.deltaTime);
        if ((brushScore.transform.localScale.x <= 1.02f) && (brushScore.transform.localScale.y <= 1.02f))
        {
            // shrink ended
            germLevelAnimPlaying = true;
            brushScoreAnimPlayingShrink = false;
            brushScore.transform.localScale = new Vector2(1f, 1f);
            brushScore.GetComponent<Text>().color = brushScoreOrigCol;
        }
    }

    void ShowGermScoreAnimShrink()
    {
        germScore.GetComponent<Text>().color = Color.Lerp(germScore.GetComponent<Text>().color, germScoreOrigCol, 2.5f * Time.deltaTime);
        germScore.transform.localScale = Vector2.Lerp(new Vector2(germScore.transform.localScale.x, germScore.transform.localScale.y), new Vector2(1f, 1f), 2f * Time.deltaTime);
        if ((germScore.transform.localScale.x <= 1.02f) && (germScore.transform.localScale.y <= 1.02f))
        {
            // shrink ended
            brushLevelAnimPlaying = true;
            germScoreAnimPlayingShrink = false;
            germScore.transform.localScale = new Vector2(1f, 1f);
            germScore.GetComponent<Text>().color = germScoreOrigCol;
        }
    }

    void ShowBrushLevelUpAnim()
    {
        brushLevelUp.transform.localPosition = Vector2.Lerp(new Vector2(brushLevelUp.transform.localPosition.x, brushLevelUp.transform.localPosition.y), new Vector2(-605f, 305f), 2.8f * Time.deltaTime);
        if ((brushLevelUp.transform.localPosition.x <= -600f) && (brushLevelUp.transform.localPosition.y <= 300f))
        {
            // move ended
            brushLevelAnimPlaying = false;
            ResetGame();
            brushLevelUp.transform.localPosition = new Vector2(0f, -600f);
            brushLevelUp.color = new Color(1f, 1f, 1f, 0f);
            germLevelUp.transform.localPosition = new Vector2(0f, -600f);
            germLevelUp.color = new Color(1f, 1f, 1f, 0f);
        }
    }

    void ShowGermLevelUpAnim()
    {
        germLevelUp.transform.localPosition = Vector2.Lerp(new Vector2(germLevelUp.transform.localPosition.x, germLevelUp.transform.localPosition.y), new Vector2(605f, 305f), 2.8f * Time.deltaTime);
        if ((germLevelUp.transform.localPosition.x >= 600f) && (germLevelUp.transform.localPosition.y <= 300f))
        {
            // move ended
            germLevelAnimPlaying = false;
            ResetGame();
            brushLevelUp.transform.localPosition = new Vector2(0f, -600f);
            brushLevelUp.color = new Color(1f, 1f, 1f, 0f);
            germLevelUp.transform.localPosition = new Vector2(0f, -600f);
            germLevelUp.color = new Color(1f, 1f, 1f, 0f);
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
    
    IEnumerator PROS()
    {
        yield return new WaitForSeconds(1f);
        SoundManager.Instance.PlayRoundOverSound();
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
        StartCoroutine(PROS());
        timesUpSoundPlaying = false;
        Debug.Log("called EndGame with brushWins = " + brushWins.ToString());
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
            totalGameOver = true;
            // back to menu screen
            brushWon = true;
        }
        else if (germPlayerScore >= 3)
        {
            // germs won overall
            totalGameOver = true;
            // back to menu screen
            germWon = true;
        }
        else
        {
            if (brushWins)
            {
                brushScoreOrigCol = brushScore.GetComponent<Text>().color;
                brushScoreAnimPlayingGrow = true;
            }
            else
            {
                germScoreOrigCol = germScore.GetComponent<Text>().color;
                germScoreAnimPlayingGrow = true;
            }
        }
        
    }

    void ResetGame()
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
        pauseTime = 0;
        timePlayedThisRound = 0;
        //reset cooldown bar to the new level clickCooldownTime
        GermPlayer.Instance.reset();
        //set brush speed to 0
    }

    // endgame (call func if cavity or if time out) with winner flag -done
    // also check if someone reached 3 wins, if yes, final winner show - done
    // level up the loser - not needed
    // reset the whole game - ????
}
