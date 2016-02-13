using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

    public static Settings Instance;


    internal int brushDifficultyOption = 2; // 1, 2, or 3
    internal int germsDifficultyOption = 2; // 1, 2, or 3
    internal float germ_Diff_coef = 1;
    internal float brush_Diff_coef = 1;

    internal int roundTime = 35;
    internal int diff_time_increment = 5;

    public int winScore = 3;


    // Germs - When does it appear percentage
    public float[] percentageGermAppears;
    //public float percentageGerm1Appears = 1;
    //public float percentageGerm2Appears = 40;
    //public float percentageGerm3Appears = 70;
    //public float percentageGerm4Appears = 100;

    internal float maxToothAreaHp = 1f;

    internal float dmgPerSecAtMaxGermification = (1.0f/15.0f);
    //public float dmgPerSecAtMaxGermification = 1;

    public int[] secondsUntilCavityAtMaxGerms;
    public int[] numClicksUntilMaxGerms;

    public float rateOfMultiplicationPerSecondPerGermification = 0.05f;

    public int[] maxSpeedBrush;

    public float secsToFullSpeed = 0.3f; // brush acceleration

    public float[] germClickCooldownTime;

    public float[] idleCleaningEfficiency;
    public float[] movingCleaningEfficiency;
    internal float inefficientCleaningCoefficient = 0.7f;

    void Awake ()
    {
        Instance = this;

        brushDifficultyOption = (int)PlayerPrefs.GetFloat("Settings_brushDif", 2.0f);
        germsDifficultyOption = (int)PlayerPrefs.GetFloat("Settings_germDif", 2.0f);

        germ_Diff_coef = 0.5f + 0.25f * germsDifficultyOption;
        brush_Diff_coef = 0.5f + 0.25f * brushDifficultyOption;

        //inefficientCleaningCoefficient = inefficientCleaningCoefficient * (2 - brush_Diff_coef);
        secsToFullSpeed = secsToFullSpeed * brush_Diff_coef;
        rateOfMultiplicationPerSecondPerGermification = rateOfMultiplicationPerSecondPerGermification * (2 - germ_Diff_coef);

        secondsUntilCavityAtMaxGerms = new int[4];
        secondsUntilCavityAtMaxGerms[0] = 10;
        secondsUntilCavityAtMaxGerms[1] = 10;
        secondsUntilCavityAtMaxGerms[2] = 7;
        // same as the last level to prevent IndexOutOfRange
        secondsUntilCavityAtMaxGerms[3] = 7;

        numClicksUntilMaxGerms = new int[4];
        numClicksUntilMaxGerms[0] = 4;
        numClicksUntilMaxGerms[1] = 4;
        numClicksUntilMaxGerms[2] = 4;
        // same as the last level to prevent IndexOutOfRange
        numClicksUntilMaxGerms[3] = 4;

        maxSpeedBrush = new int[4];
        maxSpeedBrush[0] = 800;
        maxSpeedBrush[1] = 800;
        maxSpeedBrush[2] = 1300;
        // same as the last level to prevent IndexOutOfRange
        maxSpeedBrush[3] = 1300;

        germClickCooldownTime = new float[4];
        germClickCooldownTime[0] = 1.1f * germ_Diff_coef;
        germClickCooldownTime[1] = 0.8f * germ_Diff_coef;
        germClickCooldownTime[2] = 0.8f * germ_Diff_coef;
        // same as the last level to prevent IndexOutOfRange
        germClickCooldownTime[3] = 0.8f * germ_Diff_coef;

        idleCleaningEfficiency = new float[4];
        idleCleaningEfficiency[0] = 0;
        idleCleaningEfficiency[1] = 0.0f;
        idleCleaningEfficiency[2] = 0.0f;
        // same as the last level to prevent IndexOutOfRange
        idleCleaningEfficiency[3] = 0.0f;

        movingCleaningEfficiency = new float[4];
        movingCleaningEfficiency[0] = 0.45f * (2 - brush_Diff_coef);
        movingCleaningEfficiency[1] = 0.6f * (2 - brush_Diff_coef);
        movingCleaningEfficiency[2] = 0.6f * (2 - brush_Diff_coef);
        // same as the last level to prevent IndexOutOfRange
        movingCleaningEfficiency[3] = 0.5f * (2 - brush_Diff_coef);

        // NOT RELATED TO LEVELS
        percentageGermAppears = new float[4];
        percentageGermAppears[0] = 0.01f;
        percentageGermAppears[1] = 0.4f;
        percentageGermAppears[2] = 0.7f;
        percentageGermAppears[3] = 1.0f;

        roundTime = roundTime + (diff_time_increment * brushDifficultyOption);
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
	
	}
}
