using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//the antilaser tracks towards the laser to destroy it
public class AntiLaser : MonoBehaviour {

    private float speed = 1;
    private float xVel, zVel;
    public Rigidbody antilaser;
    private Vector3 laserOriLoc;

    //gets initial laser position so the antilaser knows if the laser has moved
    void Start()
    {
        GameObject laserOriginal = GameObject.Find("Laser");
        laserOriLoc = laserOriginal.transform.position;
    }

	// Update is called once per frame
    //moves the anti laser towards the laser
	void Update () {

        GameObject laser = GameObject.Find("Laser");

        if (laser.transform.position != laserOriLoc)//the laser has moved
        {
            if (gameObject.transform.position.x < laser.transform.position.x)
                xVel = speed;
            else if (gameObject.transform.position.x == laser.transform.position.x)
                xVel = 0;
            else
                xVel = -speed;

            if (gameObject.transform.position.z < laser.transform.position.z)
                zVel = speed;
            else if (gameObject.transform.position.z == laser.transform.position.z)
                zVel = 0;
            else
                zVel = -speed;

            antilaser.velocity = new Vector3(xVel, 0, zVel);
        }

        
	}

    //destroy the laser if collided with
    void OnCollisionEnter(Collision colliderInfo)
    {
        if (colliderInfo.collider.tag == "Laser")
        {
            Destroy(gameObject);
        }
    }
}
