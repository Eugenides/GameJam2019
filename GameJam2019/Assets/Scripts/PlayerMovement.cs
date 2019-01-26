using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Player object's main transform.
    Transform mTransform;
    
    //Player object's speed-- Can be changed.
    public float speed;

	// Use this for initialization
	void Start () {
        mTransform = GetComponent<Transform>();
        speed = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {


	}

    void FixedUpdate()
    {
        //Gets axis values and multipies by speed.
        float xVelocity = Input.GetAxis("Horizontal") * speed;
        float yVelocity = Input.GetAxis("Vertical") * speed;

        //Translates the transform based off of the two velocities.
        mTransform.Translate(new Vector3(xVelocity, yVelocity, 0.0f));
    }
}
