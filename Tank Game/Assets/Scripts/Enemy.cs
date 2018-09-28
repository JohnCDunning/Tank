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
    
  
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Shoot", shootTime, shootTime);
    }

    // Update is called once per frame
    void Update()
    {
        Turret.transform.Rotate(Vector3.up * turretTurnSpeed * Time.deltaTime);


    }
    void Shoot()
    {       
        GameObject spawnedRocket = Instantiate(Rocket);
        spawnedRocket.transform.position = RocketSpawnPoint.transform.position;
        spawnedRocket.transform.rotation = Turret.transform.rotation;

    }
}

