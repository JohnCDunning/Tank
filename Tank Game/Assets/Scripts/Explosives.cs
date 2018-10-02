using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;
public class Explosives : MonoBehaviour {
    private GameObject[] breakables;
    void Awake()
    {
       
    }
    // Use this for initialization
    private void Update()
    {
        breakables = GameObject.FindGameObjectsWithTag("breakable");
        foreach (GameObject breakwall in breakables)
        {
            if (Vector3.Distance(breakwall.transform.position, transform.position) < 3)
            {
                PoolController.Instance.SpawnObject("Explosion", breakwall.transform.position, Quaternion.identity);
                Destroy(breakwall);
            }
        }
    }
    void Start () {
        
        
        
	}
 
    


}
