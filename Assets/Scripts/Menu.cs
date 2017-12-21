using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//used for UI in side menu of level
public class Menu : MonoBehaviour {

    public GameObject menuButton, menu, instructions, menuBack;

	public void OnClick()//opens menu
    {
        menuButton.SetActive(false);
        instructions.SetActive(false);
        menu.SetActive(true);
        menuBack.SetActive(true);
    }

    public void OnReset()//reset button clicked, restart level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMain()//goes to main menu
    {
        SceneManager.LoadScene(0);
    }

    public void OnClose()//closes menu
    {
        menuButton.SetActive(true);
        instructions.SetActive(true);
        menu.SetActive(false);
        menuBack.SetActive(false);
    }
}
