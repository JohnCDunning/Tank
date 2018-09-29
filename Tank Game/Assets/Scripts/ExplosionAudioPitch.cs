using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAudioPitch : MonoBehaviour {
    private AudioSource explosion;
    void Awake()
    {
        explosion = GetComponent<AudioSource>();
    }
	// Use this for initialization
	void Start () {
        explosion.pitch = Random.Range(0.7f, 1.6f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
