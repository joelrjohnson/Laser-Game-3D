using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//moves an object up and down by a player's mouse
public class VerMoveObj : MonoBehaviour
{

    public Transform maxTR;
    public Transform minTR;

    void OnMouseDrag()
    {
        //Help taken from http://answers.unity3d.com/questions/12322/drag-gameobject-with-mouse.html
        //converts the distance from the screen into coords that can be used to move the game object
        float distanceFromScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 positionMove = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromScreen));
       

        //if the object is within it's bounds
        if (positionMove.z < maxTR.position.z - transform.localScale.z / 2 && positionMove.z > minTR.position.z + transform.localScale.z / 2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, positionMove.z);
        }
    }
}
