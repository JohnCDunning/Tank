using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RocketMove();


    }
    //rocket firing mechanism
    void RocketMove()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


    }
}
