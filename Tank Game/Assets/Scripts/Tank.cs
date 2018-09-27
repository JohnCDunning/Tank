using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {
    public float tankRotateSpeed;
    public float tankSpeed;
    public GameObject Turret;
    public GameObject marker;
    public GameObject Rocket;
    public GameObject RocketSpawnPoint;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        MoveTank();
        TurretRotation();
        Shoot();
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
           GameObject spawnedRocket = Instantiate(Rocket);
           spawnedRocket.transform.position = RocketSpawnPoint.transform.position;
           spawnedRocket.transform.rotation = Turret.transform.rotation;
        }
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
        if (Physics.Raycast(ray, out hit))
        {
            if (Vector3.Distance(transform.position, hit.point) > 1)
            {
                Debug.Log(hit.point);
                marker.transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                //rotation
                Turret.transform.LookAt(marker.transform.position);
            }


        }

    }
}
