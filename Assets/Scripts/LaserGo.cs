using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script detects when the laser is clicked
//This makes the laser begin its motions

public class LaserGo : MonoBehaviour {

    public Rigidbody laserRB;
    public float xVel, yVel, zVel, minSpeed,speedInc, maxSpeed;
    private bool clicked = false;
    private LineRenderer arrowBase, arrowHeadLeft, arrowHeadRight;
    public float windx = 0;
    public float windz = 0;

    void Start()
    {
        //draws the line to show aiming
        //Help from http://answers.unity3d.com/questions/8338/how-to-draw-a-line-using-script.html
        GameObject arrow = new GameObject();
        arrow.AddComponent<LineRenderer>();
        arrowBase = arrow.GetComponent<LineRenderer>();
        arrowBase.startWidth = 0.1f;
        arrowBase.endWidth = 0.1f;
        arrowBase.material = new Material(Shader.Find("Unlit/Texture"));
    }

    void OnMouseDrag()//Allows the user to drag back on the laser to aim the direction of its travel
    {
        //Help taken from http://answers.unity3d.com/questions/12322/drag-gameobject-with-mouse.html
        //Converts camera offset and coords to usable 2D coords
        float distanceFromScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 positionMove = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromScreen));

        xVel = (gameObject.transform.position.x - positionMove.x) * (speedInc);
        zVel = (gameObject.transform.position.z - positionMove.z) * (speedInc);

        Vector3 endArrow = new Vector3(positionMove.x - 2*(positionMove.x - gameObject.transform.position.x), gameObject.transform.position.y, positionMove.z - 2*(positionMove.z -gameObject.transform.position.z));
        arrowBase.SetPosition(1, gameObject.transform.position);
        arrowBase.SetPosition(0, endArrow);

        xVel = CheckSpeeds(xVel);
        zVel = CheckSpeeds(zVel);
    }

    //When the user releases the mouse, after clicking on the laser, the laser begins motion
	void OnMouseUp()
    {
        if (!clicked && (xVel != 0 || zVel != 0))//only allow one click
        {
            laserRB.velocity = new Vector3(xVel, yVel, zVel);
            clicked = true;
            DestroyObject(arrowBase);
            DestroyObject(arrowHeadRight);
            DestroyObject(arrowHeadLeft);
        }
    }

    //makes sure the speeds are not too fast
    float CheckSpeeds(float speed)
    {
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        else if (speed < -maxSpeed)
        {
            speed = -maxSpeed;
        }
        
        return speed;
    }

    //moves the laser if it has been launched by the user
    void Update()
    {
        if (clicked)
        {
            xVel = laserRB.velocity.x + windx/10;
            zVel = laserRB.velocity.z + windz/10;

            laserRB.velocity = new Vector3(xVel, yVel, zVel);
        }
    }
}
