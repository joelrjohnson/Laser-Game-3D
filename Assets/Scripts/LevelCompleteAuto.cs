using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//automatically fills in text on the level complete screen
public class LevelCompleteAuto : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Text levelHead = gameObject.GetComponent<Text>();
        levelHead.text = string.Concat("Level ", SceneManager.GetActiveScene().buildIndex - 1, " Complete");
    }
}
