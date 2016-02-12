using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;

    Text timerText, brushScoreText, germScoreText;
    Image efficiencyBar, cooldownBar, brushLevelBar, germLevelBar;

    internal float[] prev_efficiency_array;
    internal float prev_efficiency = 0;
    internal float sum;
    internal int prev_array_length = 15;
    internal float fillEfficiency_avg = 0;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start() {
        timerText = GameObject.FindGameObjectWithTag("timer_text").GetComponent<Text>();

        brushScoreText = GameObject.FindGameObjectWithTag("brush_score_text").GetComponent<Text>();
        germScoreText = GameObject.FindGameObjectWithTag("germ_score_text").GetComponent<Text>();

        cooldownBar = GameObject.FindGameObjectWithTag("cooldown_bar_fill").GetComponent<Image>();
        efficiencyBar = GameObject.FindGameObjectWithTag("efficiency_bar_fill").GetComponent<Image>();

        brushLevelBar = GameObject.FindGameObjectWithTag("brush_level_bar").GetComponent<Image>();
        germLevelBar = GameObject.FindGameObjectWithTag("germ_level_bar").GetComponent<Image>();

        prev_efficiency_array = new float[prev_array_length];
        for (var i = 0; i < prev_array_length; i++)
        {
            prev_efficiency_array[i] = 0;
        }

    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel("Menu");
        }

        if (Helper.Instance.IsGameStateNeedToPause())
        {
            timerText.text = "00:00";

            cooldownBar.fillAmount = 0f;
            efficiencyBar.fillAmount = 0f;
        }
        else
        {
            int minutes = GameManager.Instance.timeLeftThisRound / 60;
            int seconds = GameManager.Instance.timeLeftThisRound % 60;
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

            float fillCooldown = 0.03f + GermPlayer.Instance.cooldown / GermPlayer.Instance.clickCooldownTime;
            if (fillCooldown > 1f) fillCooldown = 1f;
            cooldownBar.fillAmount = fillCooldown;


            float fillEfficiency = 0.03f + BrushPlayer.Instance.efficiency;
            if (fillEfficiency > 1f) fillEfficiency = 1f;
            //        efficiencyBar.fillAmount = fillEfficiency;
            //efficiencyBar.fillAmount = Mathf.Lerp(prev_efficiency, fillEfficiency, Settings.Instance.barMoveSpeed);

            for (var i = 0; i < (prev_array_length - 1); i++)
            {
                prev_efficiency_array[i] = prev_efficiency_array[i + 1];
            }
            prev_efficiency_array[prev_array_length - 1] = fillEfficiency;

            sum = 0;
            for (var i = 0; i < prev_array_length; i++)
            {
                sum += prev_efficiency_array[i];
            }
            fillEfficiency_avg = sum / prev_array_length;
            //Debug.Log("prev_efficiency_array: " + prev_efficiency_array.ToString());

            efficiencyBar.fillAmount = Mathf.Lerp(prev_efficiency, fillEfficiency_avg, Time.time);
            prev_efficiency = fillEfficiency_avg;
            

        }

        

        brushScoreText.text = GameManager.Instance.brushPlayerScore.ToString();
        germScoreText.text = GameManager.Instance.germPlayerScore.ToString();

        float germPlayerFill = 0f;
        float brushPlayerFill = 0f;

        switch (GameManager.Instance.brushPlayerScore)
        {
            case 0:
                germPlayerFill = 0.1f;
                break;
            case 1:
                germPlayerFill = 0.35f;
                break;
            case 2:
                germPlayerFill = 0.75f;
                break;
        }

        switch (GameManager.Instance.germPlayerScore)
        {
            case 0:
                brushPlayerFill = 0.1f;
                break;
            case 1:
                brushPlayerFill = 0.35f;
                break;
            case 2:
                brushPlayerFill = 0.75f;
                break;
        }

        brushLevelBar.fillAmount = brushPlayerFill;
        germLevelBar.fillAmount = germPlayerFill;



    }
}
