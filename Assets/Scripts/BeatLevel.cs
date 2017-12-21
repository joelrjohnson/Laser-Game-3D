using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//the level has been completed and the next scene is called
public class BeatLevel : MonoBehaviour {

	public void nextLevel () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
