using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//This script is used for when the laser is colliding with something
//The game responds appropriately
//checks for gameovers or if the laser should bounce
//also applies powerups
public class LaserCollide : MonoBehaviour {

    public Rigidbody laserRB;
    private Vector3 velocity;
    private int bronzeHit = 3, coinHit;
    public GameObject levelCompleteUI,coinUI,bronzeUI;
    private bool firePower;

    void OnCollisionEnter(Collision collisionInfo)//the laser hit something and has to respond appropriately 
    {
        if (collisionInfo.collider.tag == "Metal")//hit metal, so reflect 100%
        {
            //do nothing for now
        }
        else if(collisionInfo.collider.tag == "Crystal")//hit crystal, so complete level
        {
            Destroy(gameObject);
            collisionInfo.collider.GetComponent<Renderer>().material.color = Color.red;
            levelCompleteUI.SetActive(true);
        }
        else if(collisionInfo.collider.tag == "Wood")//hit wood, reflect 0%
        {
            if (firePower)
            {
                Destroy(collisionInfo.gameObject);
            }
            else
            {
                GameOver();
            }
        }
        else if(collisionInfo.collider.tag == "Stone")//hit stone, reflect 0%
        {
            GameOver();
        }
        else if(collisionInfo.collider.tag == "Bronze")//hit bronze, reflect 66%
        {
            bronzeHit= bronzeHit - 1;
            Text bronzeUIRef = bronzeUI.GetComponent<Text>();
            bronzeUIRef.text = bronzeHit.ToString();
            if(bronzeHit < 0)
            {
                GameOver();
            }
        }
        else if(collisionInfo.collider.tag == "Antilaser")//hit antilaser, destroyed
        {
            GameOver();
        }
        
    }

    void OnTriggerEnter(Collider collisionInfo)//the laser hit a nonsolid object
    {
        if(collisionInfo.gameObject.tag == "Glass")//used for glass hits, refract laser to a purely horizontal motion
        {
            velocity = laserRB.velocity;
            float holder = velocity.x;
            if (holder == 0)//keeps the laser from stopping if the x is 0
            {
                velocity.x = -1f;
            }
            velocity.z = 0f;
            laserRB.velocity = velocity;
        }
        else if (collisionInfo.gameObject.tag == "Coin")//hit a coin, 1 bonus objective
        {
            coinHit++;
            Destroy(collisionInfo.gameObject);
            if (coinHit >= 3)
            {
                coinUI.SetActive(true);
            }
        }
        else if(collisionInfo.gameObject.tag == "Fire")//allows the laser to burn through wooden objects
        {
            firePower = true;
            Destroy(collisionInfo.gameObject);
        }
        else if(collisionInfo.gameObject.tag == "MultiLaser")//splits the laser into three
        {
            Destroy(collisionInfo.gameObject);
            Rigidbody[] laserArray = new Rigidbody[3] { laserRB, GameObject.Find("Laser1").GetComponent<Rigidbody>(), GameObject.Find("Laser2").GetComponent<Rigidbody>() };
            laserArray[1].transform.position = new Vector3(laserArray[0].transform.position.x, laserArray[0].transform.position.y, laserArray[0].transform.position.z + 1);
            laserArray[2].transform.position = new Vector3(laserArray[0].transform.position.x, laserArray[0].transform.position.y, laserArray[0].transform.position.z - 1);
            laserArray[1].velocity = new Vector3(laserArray[0].velocity.x, laserArray[0].velocity.y, laserArray[0].velocity.z + 1);
            laserArray[2].velocity = new Vector3(laserArray[0].velocity.x, laserArray[0].velocity.y, laserArray[0].velocity.z - 1);
        }
    }

    void Update()//checks to make sure the laser is still on the board. If it is off it will give a gameover
    {
        if (gameObject.transform.position.y <= 0)
            GameOver();

        if (Input.GetKeyDown("."))//unseen user controls for managing the game as debugs
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else if (Input.GetKeyDown(","))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        else if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void GameOver()//resets the current level because the player lost
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
