using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script connects two portals that are facing the same direction
public class NegXtoX : MonoBehaviour {

    public GameObject partner;
    private float offset = 0.5f;

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (partner.transform.position.x <= gameObject.transform.position.x) //detects which portal is farther to the left to determine if the offset needs to be added or subtracted
        {
            collisionInfo.gameObject.transform.position = new Vector3(partner.transform.position.x + offset, partner.transform.position.y, partner.transform.position.z);
        }
        else
        {
            collisionInfo.gameObject.transform.position = new Vector3(partner.transform.position.x - offset, partner.transform.position.y, partner.transform.position.z);
        }
    }
}
