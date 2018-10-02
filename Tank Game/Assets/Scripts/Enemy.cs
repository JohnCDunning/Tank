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
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTargetPosition", 3, 3);
        target = GameObject.FindWithTag("Player");
       
        //Shoots every set time
        //InvokeRepeating("Shoot", shootTime, shootTime);
        //Spawns trail every set time
        InvokeRepeating("TredTrail", 0.3f, 0.3f);
    }
    void UpdateTargetPosition()
    {
        if (alive)
        {
            GetComponent<NavMeshAgent>().destination = target.transform.position;
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
                    Turret.transform.Rotate(Vector3.up * -turretTurnSpeed * Time.deltaTime);
                }
            }
            //Moving the tank [Upgrade this to ai]
            //transform.Translate(Vector3.forward * 0.5f * Time.deltaTime);
           

            if (Enemy_Level == State.Level_4)
            {
                mineTimer += 1 * Time.deltaTime;
                if (mineTimer >= timeToMine)
                {
                    PlantMine();
                }
            }
        }
        else
        {
            deathParticles.SetActive(true);
            GetComponent<NavMeshAgent>().enabled = false;
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

