﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTip : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(GameObject.FindWithTag("Player").transform.position, transform.position) < 3)
        {
            Destroy(gameObject);
        }
	}
}
