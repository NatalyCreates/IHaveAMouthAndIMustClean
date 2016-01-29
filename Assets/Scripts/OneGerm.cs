using UnityEngine;
using System.Collections;

public class OneGerm : MonoBehaviour {

    [Range(0, 3)] public int germNum = 0;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        // if ToothArea which is my parent reaches X percent of germification, show me
        // get appropriate X percentage from settings according to germNum

        //Helper.Instance.Print("ToothState Germification: " + gameObject.GetComponentInParent<ToothState>().germification.ToString());

        float germ = gameObject.GetComponentInParent<ToothState>().germification;
        
        if (germ >= Settings.Instance.percentageGermAppears[germNum])
        {
            // show this germ
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }


    }
}
