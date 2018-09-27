using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {
    public float tankRotateSpeed;
    public float tankSpeed;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        MoveTank();
    }
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
}
