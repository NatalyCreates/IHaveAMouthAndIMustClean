using UnityEngine;
using System.Collections;

public class ToothState : MonoBehaviour {

    internal float hp;
    internal float germification = 0f;
    

    public enum PrefBrushDir { UpDown, LeftRight };
    public PrefBrushDir prefDir = PrefBrushDir.LeftRight;


    void OnTriggerEnter2D(Collider2D other)
    {
        // every frame that we are touching this

        if (other.tag == "brush")
        {
            //direction
        }
    }

	// Use this for initialization
	void Start () {
        hp = Settings.Instance.maxToothAreaHp;
    }
	
    void OnMouseDown()
    {
        // check if cooldown is up, do something and make cooldown 0
        if (GermPlayer.Instance.cooldown >= Settings.Instance.germClickCooldownTime[GameManager.Instance.brushPlayerScore])
        {
            // Germ Me
            germification += (1f/Settings.Instance.numClicksUntilMaxGerms[GameManager.Instance.brushPlayerScore]);
            GermPlayer.Instance.cooldown = 0f;
        }


    }

    // Update is called once per frame
    void Update () {

        // Germ multiplication

        germification = germification * Settings.Instance.rateOfMultiplicationPerSecondPerGermification * Time.deltaTime;

        //Check that germification isn't more than max.
        if (germification > 1f)
        {
            germification = 1f;
        }

        // Update damage from germs

        hp = hp - germification * Settings.Instance.dmgPerSecAtMaxGermification;
        if (hp <= 0)
        {
            //GameManager.Instance.EndGame(false);
        }




        //cleaningEfficiencyAtMaxSpeed = 100 / secondsToCleanFullyInfectedToothAtMaxSpeed;
        //cleaningEfficiencyAtIdle = 100 / secondsToCleanFullyInfectedToothAtIdle; //idleCleaningEfficiency
    }

    // reset me func (max hp etc)
    void resetToothState ()
    {
        hp = Settings.Instance.maxToothAreaHp;
        germification = 0f;
    }


}
