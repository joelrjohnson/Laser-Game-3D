using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//moves a block back and forth horizontally
public class AutoHorObj : MonoBehaviour {

    public Transform maxTR;
    public Transform minTR;
    public float speed, offset;
    private float curSpeed;

    void Start()//initializes the current speed
    {
        curSpeed = speed;
    }

    //checks block position
    void FixedUpdate()
    {
        if (transform.position.x <= minTR.position.x + transform.localScale.x / 2 + offset)//too far left
        {
            curSpeed = speed;
            transform.position = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= maxTR.position.x - transform.localScale.x / 2 - offset)//too far right
        {
            curSpeed = -speed;
            transform.position = new Vector3(transform.position.x - offset, transform.position.y, transform.position.z);
        }
        else//move left or right
        {
            transform.position = new Vector3(transform.position.x + (curSpeed * Time.deltaTime), transform.position.y, transform.position.z);
        }
    }
}
