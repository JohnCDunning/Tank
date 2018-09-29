using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;
//This script is now only for object pooled items
public class KillThisObject : PoolObject{
    public float TimeToKill;
    float timeryeet;
    // Use this for initialization
    void Start () {
        timeryeet = 0;
    }
	
	// Update is called once per frame
	void Update () {
        timeryeet += 1 * Time.deltaTime;
        if(timeryeet >= TimeToKill)
        {
            KillThisThing();
        }
	}
    void KillThisThing()
    {
        Destroy();
     
    }
    public override void OnObjectReuse() //Required
    {
        timeryeet = 0;
    }

}
