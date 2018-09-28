using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThisObject : MonoBehaviour {
    public float TimeToKill;
    // Use this for initialization
    void Start () {
        Invoke("KillThisThing", TimeToKill);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void KillThisThing()
    {
        Destroy(gameObject);
    }
}
