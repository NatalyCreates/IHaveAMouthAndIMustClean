using UnityEngine;
using System.Collections;

public class ToothState : MonoBehaviour {

    internal float hp = 1f;
    internal float germification = 0f;
    internal float x_part = 0f;
    internal float y_part = 0f;
    internal float toothAreaEfficiency = 0f;
    public float toughness;


    public enum PrefBrushDir { UpDown, LeftRight };
    public PrefBrushDir prefDir = PrefBrushDir.LeftRight;

    bool isBeingBrushed = false;

    void brushMe()
    {
        //Debug.Log("toothAreaEfficiency " + BrushPlayer.Instance.direction.sqrMagnitude.ToString());
        if ((BrushPlayer.Instance.direction.sqrMagnitude > 0) && (germification > 0))
        {
            x_part = Mathf.Pow((BrushPlayer.Instance.direction.x), 2) / BrushPlayer.Instance.direction.sqrMagnitude;
            y_part = Mathf.Pow((BrushPlayer.Instance.direction.y), 2) / BrushPlayer.Instance.direction.sqrMagnitude;
            //Debug.Log("IHAMAIMC x_part " + x_part.ToString());
            //Debug.Log("IHAMAIMC y_part " + y_part.ToString());

            if (PrefBrushDir.LeftRight == prefDir)
            {
                //toothAreaEfficiency = x_part + (y_part * Settings.Instance.inefficientCleaningCoefficient);
                toothAreaEfficiency = 1;
            }
            else if (PrefBrushDir.UpDown == prefDir)
            {
                toothAreaEfficiency = y_part + (x_part * Settings.Instance.inefficientCleaningCoefficient);
            }
            else
            {
                Debug.Log("toothAreaEfficiency is wrong!");
            }
            toothAreaEfficiency = BrushPlayer.Instance.fractionOfMaxSpeed * toothAreaEfficiency;

        }
        else { toothAreaEfficiency = 0; }

        //Debug.Log("toothAreaEfficiency " + toothAreaEfficiency.ToString());

        //Brush level = germ score.
        germification = germification - toothAreaEfficiency * Settings.Instance.movingCleaningEfficiency[GameManager.Instance.germPlayerScore] * Time.deltaTime;
        germification = germification < 0 ? 0 : germification;
        //Debug.Log("germification after cleaning " + germification.ToString());

        //report toothAreaEfficiency to BrushPlayer
        //Don't report - brushplayer asks us instead.
        //BrushPlayer.Instance.AddAreaToCount(toothAreaEfficiency);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "brush")
        {
            Debug.Log("Got Brushed!");
            isBeingBrushed = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "brush")
        {
            Debug.Log("Got UnBrushed!");
            isBeingBrushed = false;
            toothAreaEfficiency = 0;
        }
    }

    // Use this for initialization
    void Start () {
        hp = Settings.Instance.maxToothAreaHp;
        //Debug.Log("IHAMAIMC initial hp " + hp.ToString());
    }
	
    void OnMouseDown()
    {
        // check if cooldown is up, do something and make cooldown 0
        if ((germification < 1) && (GermPlayer.Instance.cooldown >= Settings.Instance.germClickCooldownTime[GameManager.Instance.brushPlayerScore] - 0.1f))
        {
            SoundManager.Instance.PlayGermifySound();
            // Germ Me, considering my toughness
            //germification += (1f/Settings.Instance.numClicksUntilMaxGerms[GameManager.Instance.brushPlayerScore])/toughness;
            germification += (1f / Settings.Instance.numClicksUntilMaxGerms[GameManager.Instance.brushPlayerScore]);
            GermPlayer.Instance.cooldown = 0f;
        }


    }

    // Update is called once per frame
    void Update () {

        // Germ multiplication

        germification = germification * (1 + (Settings.Instance.rateOfMultiplicationPerSecondPerGermification * Time.deltaTime));

        //Check that germification isn't more than max.
        if (germification > 1f)
        {
            germification = 1f;
        }

        //Debug.Log("IHAMAIMC germification " + germification.ToString());
        //Debug.Log("IHAMAIMC rate const " + Settings.Instance.dmgPerSecAtMaxGermification.ToString());

        // Update damage from germs

        hp = hp - (germification * Settings.Instance.dmgPerSecAtMaxGermification * Time.deltaTime)/toughness;
        //hp = hp - (germification * 1 * Time.deltaTime);
        //Debug.Log("IHAMAIMC hp " + hp.ToString());
        if (Helper.Instance.IsGameStateNeedToPause())
        {
            //nada
        }
        else
        {
            if (hp <= 0)
            {
                GameManager.Instance.EndGame(false);
            }
        }
        




        //cleaningEfficiencyAtMaxSpeed = 100 / secondsToCleanFullyInfectedToothAtMaxSpeed;
        //cleaningEfficiencyAtIdle = 100 / secondsToCleanFullyInfectedToothAtIdle; //idleCleaningEfficiency


        if (isBeingBrushed)
        {
            brushMe();
        }
    }

    // reset me func (max hp etc)
    internal void resetToothState ()
    {
        //Debug.Log("IHAMAIMC germification in reset " + germification.ToString());
        hp = Settings.Instance.maxToothAreaHp;
        germification = 0f;
        //Debug.Log("IHAMAIMC germification after reset " + germification.ToString());
    }


}
