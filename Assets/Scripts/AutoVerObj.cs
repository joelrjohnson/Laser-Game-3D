using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script moves a obstacle up and down automatically
public class AutoVerObj : MonoBehaviour {

    public Transform maxTR;
    public Transform minTR;
    public float speed, offset;
    private float curSpeed;

    void Start()//initializes the current speed
    {
        curSpeed = speed;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (transform.position.z <= minTR.position.z + transform.localScale.z / 2 + offset)//too low
        {
            curSpeed = speed;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + offset);
        }
        else if(transform.position.z >= maxTR.position.z - transform.localScale.z / 2 - offset)//max height hit
        {
            curSpeed = -speed;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - offset);
        }
        else//move up or down
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (curSpeed * Time.deltaTime));
        }
	}
}
