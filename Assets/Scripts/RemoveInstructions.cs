using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script to hide the instructions
public class RemoveInstructions : MonoBehaviour {

    public GameObject instructionUI;

	// Use this for initialization
	void OnMouseDown()
    {
        instructionUI.SetActive(false);
    }
}
