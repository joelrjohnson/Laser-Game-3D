using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

	// The button to exit the game has been clicked, so quit the game
	public void OnClick()
    {
        Application.Quit();
    }
}
