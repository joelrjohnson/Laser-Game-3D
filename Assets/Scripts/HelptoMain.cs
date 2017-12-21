using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//returns the scene from the help menu back to the main menu
public class HelptoMain : MonoBehaviour {

    public void ReturnMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
