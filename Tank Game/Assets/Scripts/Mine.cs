using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;
public class Mine : PoolObject {
    public GameObject ExplosionMine;
    private float LifeTimer;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        LifeTimer += 1 * Time.deltaTime;
        if(LifeTimer >= 5.3f)
        {
            Explode();
        }
	}
    void Explode()
    {
        PoolController.Instance.SpawnObject("MineExplosion", new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
        Destroy();
    }
    public override void OnObjectReuse() //Required
    {
        LifeTimer = 0;
    }
}
