using UnityEngine;
using System.Collections;

public class Cavity : MonoBehaviour {

    float maxOpacityLooksGood = 0.85f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //gameObject.GetComponentInParent<ToothState>().hp;

        // Update from parent's HP

        float hp = gameObject.GetComponentInParent<ToothState>().hp;

        Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
        if (hp < 0) hp = 0f;
        if (hp > 1.0f) hp = 1f;
        tmp.a = (1 - hp) * maxOpacityLooksGood;
        gameObject.GetComponent<SpriteRenderer>().color = tmp;


    }
}
