using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour {
    public GameObject target;
    public float camX;
    public float camZ;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveToTarget();
	}
    void MoveToTarget()
    {
        
        camX = Mathf.Clamp(target.transform.position.x, -3, 3);
        camZ = Mathf.Clamp(target.transform.position.z, -3, 3);        
        transform.position = new Vector3(camX, transform.position.y, camZ);
        
        
    }
}
