using UnityEngine;
using System.Collections;

public class GermPlayer : MonoBehaviour {

    public static GermPlayer Instance;

    internal float cooldown;
    internal float clickCooldownTime;


    // Use this for initialization
    void Start () {
        cooldown = 0f;
        int germ_level = GameManager.Instance.brushPlayerScore;
        //Helper.Instance.Print(germ_level.ToString());
        //germ_level = 0;
        clickCooldownTime = Settings.Instance.germClickCooldownTime[germ_level];
        //float dmgPerSecAtMaxGermification = maxToothAreaHp / secondsUntilCavityAtMaxGerms;

        //// HERE

        //// HERE

    }

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update () {
        // refill cooldown in time from settings
        if (cooldown < clickCooldownTime)
        {
            cooldown += Time.deltaTime;
        }
	}

    void Reset()
    {
        // clickCooldownTime update to correct time according to level
    }
}
