using UnityEngine;
using System.Collections;


public class BrushPlayer : MonoBehaviour {

    
    float fractionOfMaxSpeed = 0;
    Vector2 direction = Vector2.zero;
    int level;
    internal int speed;

    internal float efficiency;

    internal float[] affectedToothAreasEfficiencies;
    
    

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {

        // If no movement, move slightly or play idle anim, and flag to prevent effect on teeth

        // Control Brush Movement

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

        // Calculate Average Efficiency on all Tooth Areas that have reported


    }

    public void AddAreaToCount()
    {
        // adds to the list
    }





}
