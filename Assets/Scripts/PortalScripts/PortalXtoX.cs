using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//connects two portals that face opposite directions
public class PortalXtoX : MonoBehaviour {

    public GameObject partner;
    private float offset = 1f;

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (partner.transform.position.x <= gameObject.transform.position.x)//adds or subtracts offset
        {
            collisionInfo.gameObject.transform.position = new Vector3(partner.transform.position.x - offset, partner.transform.position.y, partner.transform.position.z);
        }
        else
        {
            collisionInfo.gameObject.transform.position = new Vector3(partner.transform.position.x + offset, partner.transform.position.y, partner.transform.position.z);
        }
    }
}
