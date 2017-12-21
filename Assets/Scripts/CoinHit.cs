using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHit : MonoBehaviour {

	void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
