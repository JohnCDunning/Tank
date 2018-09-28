using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThisObject : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        Invoke("KillThisThing", 2f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void KillThisThing()
    {
        Destroy(gameObject);
    }
}
