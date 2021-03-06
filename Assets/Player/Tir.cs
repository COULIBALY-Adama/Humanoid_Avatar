using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour {

    public GameObject Projectile;
    public int Force = 50;
    public AudioClip SoundTir;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1"))
        {
            GetComponent<AudioSource>().PlayOneShot(SoundTir);
            GameObject Bulllet = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
            //Bullet.GetComponent<Rigidbody>().velocity = transform.forward * Force;
        }
		
	}
}
