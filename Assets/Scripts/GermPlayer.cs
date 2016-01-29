using UnityEngine;
using System.Collections;

public class GermPlayer : MonoBehaviour {

    public static GermPlayer Instance;

    internal int cooldown;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        // cooldown = 0
        //float dmgPerSecAtMaxGermification = maxToothAreaHp / secondsUntilCavityAtMaxGerms;

    }

    // Update is called once per frame
    void Update () {
	    // refill cooldown in time from settings

	}
}
