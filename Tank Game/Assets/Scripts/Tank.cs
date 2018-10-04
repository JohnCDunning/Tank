using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;
public class Tank : MonoBehaviour {
    public float tankRotateSpeed;
    public float tankSpeed;
    public float timeToShoot;
    public AudioClip death;
    private float shootTimer;
    public float timeToMine;
    private float mineTimer;
    public GameObject Turret;
    public GameObject marker;
    public GameObject Rocket;
    public GameObject RocketSpawnPoint;
    public GameObject trailPrefab;
    public GameObject trailSpawn;
    public bool alive;
    public GameObject deathParticles;
    public ParticleSystem shootPuff;
    public AudioSource tankNoise;
    public AudioSource shootNoise;

    private bool playedDeathNoise = false;
    
    // Use this for initialization
    void Awake()
    {
        
    }
    void Start() {
        InvokeRepeating("TredTrail", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        //If Alive
        if (alive == true)
        {
            shootTimer += 1 * Time.deltaTime;
            mineTimer += 1 * Time.deltaTime;
            MoveTank();
            TurretRotation();
            if (shootTimer >= timeToShoot)
            {
                Shoot();
            }
            if (mineTimer >= timeToMine)
            {
                PlantMine();
            }
            //AUDIO FOR TANK TRACK NOISE (1 line skillz)
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) { tankNoise.volume = 1; } else { tankNoise.volume = 0; }
        }
        else
        {
            if (!playedDeathNoise)
            {
                shootNoise.pitch = 1;
                shootNoise.PlayOneShot(death, 0.4f);                
                deathParticles.gameObject.SetActive(true);
                playedDeathNoise = true;
            }
        }
    }
    void PlantMine()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            PoolController.Instance.SpawnObject("Mine", transform.position, Quaternion.identity);
            mineTimer = 0;
        }
    }
    void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            Turret.GetComponent<Animator>().SetTrigger("TurretShoot");
            shootNoise.pitch = Random.Range(1f, 2f);
            shootNoise.Play();
           PoolController.Instance.SpawnObject("Rocket", RocketSpawnPoint.transform.position, Turret.transform.rotation);
          
           
           shootPuff.Play();
           shootPuff.transform.GetComponent<Animator>().SetTrigger("Shoot");
           shootTimer = 0;
        }
    }
    void TredTrail()
    {
        PoolController.Instance.SpawnObject("Trail", trailSpawn.transform.position, transform.rotation);
       
    }
    //to move the tank
    void MoveTank()
    { 
     
        // instructions for spinning left
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.down * tankRotateSpeed * Time.deltaTime);
                
            }
            //spin right
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * tankRotateSpeed * Time.deltaTime);
            }
            //move tank forward
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * (tankSpeed / 2) * Time.deltaTime);
                
             }
            //move tank backward
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * (tankSpeed / 2) * Time.deltaTime);

            }
        
    }

    // to rotate turret
    void TurretRotation()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity,layerMask:13))
        {
            
            if (Vector3.Distance(transform.position, hit.point) > 1)
            {
               
                marker.transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                //rotation
                Turret.transform.LookAt(marker.transform.position);
            }


        }

    }
}
