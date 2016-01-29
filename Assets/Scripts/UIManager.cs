using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;

    Text timerText, brushScoreText, germScoreText;
    Image efficiencyBar, cooldownBar;

    void Awake ()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
        timerText = GameObject.FindGameObjectWithTag("timer_text").GetComponent<Text>();

        brushScoreText = GameObject.FindGameObjectWithTag("brush_score_text").GetComponent<Text>();
        germScoreText = GameObject.FindGameObjectWithTag("germ_score_text").GetComponent<Text>();

        cooldownBar = GameObject.FindGameObjectWithTag("cooldown_bar_fill").GetComponent<Image>();
        efficiencyBar = GameObject.FindGameObjectWithTag("efficiency_bar_fill").GetComponent<Image>();



    }
	
	// Update is called once per frame
	void Update () {

        int minutes = GameManager.Instance.timeLeftThisRound / 60;
        int seconds = GameManager.Instance.timeLeftThisRound % 60;
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        brushScoreText.text = GameManager.Instance.brushPlayerScore.ToString();
        germScoreText.text = GameManager.Instance.germPlayerScore.ToString();

        float fillCooldown = 0.03f + GermPlayer.Instance.cooldown / GermPlayer.Instance.clickCooldownTime;
        if (fillCooldown > 1f) fillCooldown = 1f;
        cooldownBar.fillAmount = fillCooldown;

        float fillEfficiency = 0.03f + BrushPlayer.Instance.efficiency;
        if (fillEfficiency > 1f) fillCooldown = 1f;
        efficiencyBar.fillAmount = fillEfficiency;
    }
}
