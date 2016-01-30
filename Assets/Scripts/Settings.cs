using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

    public static Settings Instance;

    internal int roundTime = 60;

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

    public float rateOfMultiplicationPerSecondPerGermification = 0.1f;

    public int[] maxSpeedBrush;

    internal float barMoveSpeed = 0.1f;

    public float secsToFullSpeed = 0.3f; // brush acceleration

    public float[] germClickCooldownTime;

    public float[] idleCleaningEfficiency;
    public float[] movingCleaningEfficiency;
    internal float inefficientCleaningCoefficient = 0.3f;

    void Awake ()
    {
        Instance = this;

        secondsUntilCavityAtMaxGerms = new int[3];
        secondsUntilCavityAtMaxGerms[0] = 12;
        secondsUntilCavityAtMaxGerms[1] = 12;
        secondsUntilCavityAtMaxGerms[2] = 9;

        numClicksUntilMaxGerms = new int[3];
        numClicksUntilMaxGerms[0] = 7;
        numClicksUntilMaxGerms[1] = 7;
        numClicksUntilMaxGerms[2] = 7;

        maxSpeedBrush = new int[3];
        maxSpeedBrush[0] = 800;
        maxSpeedBrush[1] = 800;
        maxSpeedBrush[2] = 1200;

        germClickCooldownTime = new float[3];
        germClickCooldownTime[0] = 1.0f;
        germClickCooldownTime[1] = 0.7f;
        germClickCooldownTime[2] = 0.7f;

        idleCleaningEfficiency = new float[3];
        idleCleaningEfficiency[0] = 0;
        idleCleaningEfficiency[1] = 0.005f;
        idleCleaningEfficiency[2] = 0.01f;

        movingCleaningEfficiency = new float[3];
        movingCleaningEfficiency[0] = 0.4f;
        movingCleaningEfficiency[1] = 0.4f;
        movingCleaningEfficiency[2] = 0.4f;

        percentageGermAppears = new float[4];
        percentageGermAppears[0] = 0.01f;
        percentageGermAppears[1] = 0.4f;
        percentageGermAppears[2] = 0.7f;
        percentageGermAppears[3] = 1.0f;

    }

    // Use this for initialization
    void Start () {

        

    }
	
	// Update is called once per frame
	void Update () {
        
	
	}
}
