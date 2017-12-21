using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//a script to turn on portals if a switch is activated
public class Switch : MonoBehaviour {

    public GameObject portal, portalPartner;

	void OnTriggerEnter()
    {
        Destroy(gameObject);
        portal.SetActive(true);
        portalPartner.SetActive(true);
    }
}
