using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BrushPlayer : MonoBehaviour {

    public static BrushPlayer Instance;

    internal float fractionOfMaxSpeed = 0;
    internal Vector2 direction = Vector2.zero;
    internal Vector2 direction_normalized;
    internal Vector2 prev_direction;
    internal float curMaxSpeed;
    internal int speed;

    internal float efficiency;
    internal float cur_efficiency;
    internal int non_zero_efficiencies;
    internal float total_efficiency;

    internal bool isBrushing;

    internal float[] affectedToothAreasEfficiencies;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {

        // If no movement, move slightly or play idle anim, and flag to prevent effect on teeth

        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        if ((direction.x < 0) && (transform.position.x < -900))
        {
            direction.x = 0;
        }
        if ((direction.x > 0) && (transform.position.x > 800))
        {
            direction.x = 0;
        }
        if ((direction.y < 0) && (transform.position.y < -320))
        {
            direction.y = 0;
        }
        if ((direction.y > 0) && (transform.position.y > 470))
        {
            direction.y = 0;
        }

        direction_normalized = direction.normalized;
        //Debug.Log("IHAMAIMC direction vector " + direction.ToString());

       // if (isBrushing == true)
       // {
            if ((direction.x < 0) && ((prev_direction.x == 0) || (prev_direction.x > 0)))
            {
                SoundManager.Instance.PlayBrushLeftSound();
            }
            if ((direction.x > 0) && ((prev_direction.x == 0) || (prev_direction.x < 0)))
            {
                SoundManager.Instance.PlayBrushRightSound();
            }
            if ((direction.y < 0) && ((prev_direction.y == 0) || (prev_direction.y > 0)))
            {
                SoundManager.Instance.PlayBrushDownSound();
            }
            if ((direction.y > 0) && ((prev_direction.y == 0) || (prev_direction.y < 0)))
            {
                SoundManager.Instance.PlayBrushUpSound();
            }
       // }

        curMaxSpeed = Settings.Instance.maxSpeedBrush[GameManager.Instance.germPlayerScore];
        transform.Translate(direction_normalized.x * curMaxSpeed * Time.deltaTime, direction_normalized.y * curMaxSpeed * Time.deltaTime, 0);

        //fractionOfMaxSpeed = ???? / curMaxSpeed;
        fractionOfMaxSpeed = 1f;
        //fractionOfMaxSpeed = direction.magnitude;
        //if (fractionOfMaxSpeed>1) { fractionOfMaxSpeed = 1; }

        // Control Brush Movement
        /*
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //gameObject.transform.position = gameObject.transform.position + Vector3.right;
            direction = Vector3.right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
        }
        */

            //Update movement according to 

            // Calculate Average Efficiency on all Tooth Areas that have reported
            cur_efficiency = 0f;
        total_efficiency = 0f;
        non_zero_efficiencies = 0;
        GameObject[] allTeeth = GameObject.FindGameObjectsWithTag("all_teeth");
        foreach (GameObject area in allTeeth)
        {
            cur_efficiency = area.GetComponent<ToothState>().toothAreaEfficiency;
            if (cur_efficiency != 0) {
                non_zero_efficiencies += 1;
                total_efficiency += cur_efficiency;
            }
        }
        efficiency = total_efficiency / non_zero_efficiencies;

        prev_direction = direction;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "all_teeth")
        {
            Debug.Log("isBrushing");
            isBrushing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "all_teeth")
        {
            Debug.Log("isNotBrushing");
            isBrushing = false;
           
        }
    }

    //    public void AddAreaToCount(float efficiency)
    //    {
    //        // adds to the list
    //    }





}
