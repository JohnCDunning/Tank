using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        GameObject spawnedRocket = Instantiate(Rocket);
        spawnedRocket.transform.position = RocketSpawnPoint.transform.position;
        spawnedRocket.transform.rotation = Turret.transform.rotation;
        shootPuff.Play();
        shootPuff.transform.GetComponent<Animator>().SetTrigger("Shoot");
    }
    void TredTrail()
    {
        GameObject trail = Instantiate(trailPrefab);
        trail.transform.position = trailSpawn.transform.position;
        trail.transform.rotation = transform.rotation;
    }

}

