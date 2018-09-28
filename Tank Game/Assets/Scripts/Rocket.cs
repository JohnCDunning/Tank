using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;
public class Rocket : PoolObject {
    public float speed;
    bool exploded;
    public GameObject explosion;
	// Use this for initialization
	void Start () {
        exploded = false;
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
    private void OnTriggerStay(Collider other)
    {
        

        if (other.tag == "breakable")
        {
            Destroy(other.gameObject);
            Destroy();
            
        }
        explosion.transform.position = transform.position;
        PoolController.Instance.SpawnObject("Explosion", transform.position,Quaternion.identity);
        Destroy();
    }
    public override void OnObjectReuse() //Required
    {
       
    }





}
