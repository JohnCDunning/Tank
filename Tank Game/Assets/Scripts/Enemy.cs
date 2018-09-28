using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;
public enum State
{
    Level_1, Level_2, Level_3, Level_4, Level_5
}
public class Enemy : MonoBehaviour
{
    public State Enemy_Level;
    [Range(1f, 5)]
    public int shootTime;
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
    // Use this for initialization
    void Start()
    {
        //Shoots every set time
        InvokeRepeating("Shoot", shootTime, shootTime);
        //Spawns trail every set time
        InvokeRepeating("TredTrail", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 0.5f * Time.deltaTime);
        Turret.transform.Rotate(Vector3.up * turretTurnSpeed * Time.deltaTime);
        if(alive == true)
        {

        }
        else
        {
            deathParticles.SetActive(true);
        }

    }
    void Shoot()
    {
        shoot.pitch = Random.Range(0.6f, 1.2f);
        shoot.Play();
        Turret.GetComponent<Animator>().SetTrigger("TurretShoot");
        PoolController.Instance.SpawnObject("Rocket", RocketSpawnPoint.transform.position, Turret.transform.rotation);
        shootPuff.Play();
        shootPuff.transform.GetComponent<Animator>().SetTrigger("Shoot");
    }
    void TredTrail()
    {
        PoolController.Instance.SpawnObject("Trail", trailSpawn.transform.position, transform.rotation);
    }

}

