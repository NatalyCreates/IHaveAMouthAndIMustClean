using UnityEngine;
using System.Collections;

public class GermPlayer : MonoBehaviour {

    public static GermPlayer Instance;

    internal float cooldown;
    internal float clickCooldownTime;


    // Use this for initialization
    void Start () {
        reset();
        //float dmgPerSecAtMaxGermification = maxToothAreaHp / secondsUntilCavityAtMaxGerms;


    }

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update () {
        if (GameManager.Instance.gamePaused)
        {
            // no refill
        }
        else
        {
            // refill cooldown in time from settings
            if (cooldown < clickCooldownTime)
            {
                cooldown += Time.deltaTime;
            }
        }
	}

    internal void reset()
    {
        // clickCooldownTime update to correct time according to level
        cooldown = 0f;
        clickCooldownTime = Settings.Instance.germClickCooldownTime[GameManager.Instance.brushPlayerScore];
    }
}
