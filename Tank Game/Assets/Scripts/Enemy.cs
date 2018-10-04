using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;
using UnityEngine.AI;
public enum State
{
    Level_1, Level_2, Level_3, Level_4, Level_5
}
public class Enemy : MonoBehaviour
{
    public State Enemy_Level;
    [Range(0.1f, 5f)]
    public float shootTime;
    public float timeToMine;
    private float mineTimer;
    public GameObject Turret;
    public GameObject Rocket;
    public GameObject RocketSpawnPoint;
    public float turretTurnSpeed;
    private float shootTimer;
   
    public GameObject trailPrefab;
    public GameObject trailSpawn;
    public GameObject deathParticles;
    public bool alive;
    public ParticleSystem shootPuff;
    public AudioSource shoot;
    public GameObject target;
    private NavMeshAgent nav;

    private int turnDirection = 0;
    private bool turningLeft = true;
    // Use this for initialization
    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player");
    }
    void Start()
    {
        turnDirection = Random.Range(-1, 1);
        if (turnDirection < 0)
        {
            turningLeft = true;
        }
        else { turningLeft = false; }
        InvokeRepeating("UpdateTargetPosition", 1, 1);
        //InvokeRepeating("Shoot", 3, 3);
       
        //Shoots every set time
        //InvokeRepeating("Shoot", shootTime, shootTime);
        //Spawns trail every set time
        
        InvokeRepeating("TredTrail", 0.3f, 0.3f);
    }
    void UpdateTargetPosition()
    {
        if (alive)
        {
            nav.destination = target.transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {       
        //If the tank is alive, it can do all these actions;
        if(alive == true)
        {
            shootTimer += 1 * Time.deltaTime;
            //RAYCAST FOR TURRET
            RaycastHit hit;
            if (Physics.Raycast(Turret.transform.position, Turret.transform.TransformDirection(Vector3.forward * 50), out hit))
            {
                
                if (hit.collider.tag == "Player")
                {
                    if (shootTimer >= shootTime)
                    {
                        Shoot();
                        shootTimer = 0;
                    }
                    LockOn(hit.collider.transform);
                }
                else
                {
                    if (turningLeft)
                    {
                        Turret.transform.Rotate(Vector3.up * -turretTurnSpeed * Time.deltaTime);
                    }
                    else
                    {
                        Turret.transform.Rotate(Vector3.up * turretTurnSpeed * Time.deltaTime);
                    }
                }
            }
            //Moving the tank [Upgrade this to ai]
            //transform.Translate(Vector3.forward * 0.5f * Time.deltaTime);

            switch (Enemy_Level)
            {
                case State.Level_1: //Default Tank
                    nav.speed = 0;nav.angularSpeed = 0;
                    break;
                case State.Level_2: //Moving Tank
                    nav.speed = 0.5f; nav.angularSpeed = 80;
                    break;
                case State.Level_3: //Moving Smart Tank
                    nav.speed = 1; nav.angularSpeed = 80;
                    break;
                case State.Level_4: //MINER TANK
                    nav.speed = 0.4f; nav.angularSpeed = 80;
                    mineTimer += 1 * Time.deltaTime;
                    if (mineTimer >= timeToMine)
                    {
                        PlantMine();
                    }
                    break;
                case State.Level_5: //Advanced Tank
                    nav.speed = 1.5f; nav.angularSpeed = 80;
                    break;
            }
        }
        else
        {
            deathParticles.SetActive(true);
            nav.speed = 0;
            nav.angularSpeed = 0;
        }

    }
    void LockOn(Transform target)
    {
        Turret.transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }
    void Shoot()
    {
        if (alive)
        {
            shoot.pitch = Random.Range(0.6f, 1.2f);
            shoot.Play();
            Turret.GetComponent<Animator>().SetTrigger("TurretShoot");
            PoolController.Instance.SpawnObject("Rocket", RocketSpawnPoint.transform.position, Turret.transform.rotation);
            shootPuff.Play();
            shootPuff.transform.GetComponent<Animator>().SetTrigger("Shoot");
        }
    }
    void TredTrail()
    {
        PoolController.Instance.SpawnObject("Trail", trailSpawn.transform.position, transform.rotation);
    }
    void PlantMine()
    {      
       PoolController.Instance.SpawnObject("Mine", transform.position, Quaternion.identity);
       mineTimer = 0;        
    }

}

