using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//This script fills in text information in the side menu of a level
public class LevelAuto : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text levelHead = gameObject.GetComponent<Text>();
        levelHead.text = string.Concat("Level ", SceneManager.GetActiveScene().buildIndex -1);
    }
}
