using UnityEngine;
using System.Collections;

public class MoveWithArrows : MonoBehaviour {

    Vector2 direction = Vector2.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += new Vector3(1,2,0);
            direction = Vector2.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.up;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.down;
        }
    }
}
