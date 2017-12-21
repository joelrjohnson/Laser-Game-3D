using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//moves an object left and right by the user's mouse
public class HorMoveObj : MonoBehaviour {

    public Transform maxTR;
    public Transform minTR;

    void OnMouseDrag()
    {
        //Help taken from http://answers.unity3d.com/questions/12322/drag-gameobject-with-mouse.html
        //converts the distance from the screen into coords that can be used to move the game object
        float distanceFromScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 positionMove = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromScreen));

        //if the object is within it's bounds
        if (positionMove.x < maxTR.position.x - transform.localScale.x / 2 && positionMove.x > minTR.position.x + transform.localScale.x / 2)
        {
            transform.position = new Vector3(positionMove.x, transform.position.y, transform.position.z);
        }
    }
}
