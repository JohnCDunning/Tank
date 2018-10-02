using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;
public class Rocket : PoolObject {
    public float speed;
    bool exploded;
    public GameObject explosion;
    public AudioSource missileAudio;
    private Rigidbody rb;
    private int hits;
	// Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
	void Start () {
        hits = 0;
        exploded = false;
        missileAudio.pitch = Random.Range(0.7f, 1.4f);
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        
        RocketMove();
        


    }
    //rocket firing mechanism
    void RocketMove()
    {
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    //If the rocket hits anything
    private void OnTriggerEnter(Collider other)
    {
        
       
        //If hit breakable wall
        if (other.tag == "breakable")
        {
            Destroy(other.gameObject);
            Destroy();           
        }
        if (other.tag == "Player")
        {
            other.GetComponent<Tank>().alive = false;
        }else if(other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().alive = false;
        }
        //Explode if it hits anything at all
        explosion.transform.position = transform.position;
        PoolController.Instance.SpawnObject("Explosion", transform.position,Quaternion.identity);
       
        //Resets the rocket
        Destroy();      
    }
    public override void OnObjectReuse() //Required
    {
       
    }





}
