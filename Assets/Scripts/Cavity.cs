﻿using UnityEngine;
using System.Collections;

public class Cavity : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //gameObject.GetComponentInParent<ToothState>().hp;

        // Update from parent's HP

        Helper.Instance.Print("ToothState HP: " + gameObject.GetComponentInParent<ToothState>().hp.ToString());
        float hp = gameObject.GetComponentInParent<ToothState>().hp;
        Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
        tmp.a = (100 - hp) / 100;
        gameObject.GetComponent<SpriteRenderer>().color = tmp;


    }
}
