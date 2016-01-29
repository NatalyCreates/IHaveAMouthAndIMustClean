using UnityEngine;
using System.Collections;

public class ToothState : MonoBehaviour {

    internal int hp = 100;
    internal int germification = 0;
    

    public enum PrefBrushDir { UpDown, LeftRight };
    public PrefBrushDir prefDir = PrefBrushDir.LeftRight;


    void OnTriggerEnter2D(Collider2D other)
    {
        // every frame that we are touching this

        if (other.tag == "brush")
        {
            // Brush Me
        }
    }

	// Use this for initialization
	void Start () {
        
	}
	
    void OnMouseDown()
    {
        // check if cooldown is up, do something and make cooldown 0


        // Germ Me
    }

    // Update is called once per frame
    void Update () {

        // Germ multiplication
        
        // Update damage from germs

        

        //cleaningEfficiencyAtMaxSpeed = 100 / secondsToCleanFullyInfectedToothAtMaxSpeed;
        //cleaningEfficiencyAtIdle = 100 / secondsToCleanFullyInfectedToothAtIdle; //idleCleaningEfficiency
    }

    // reset me func (max hp etc)
}
