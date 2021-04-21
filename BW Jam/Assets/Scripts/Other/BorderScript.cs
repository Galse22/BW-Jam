using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    public float xToChange;
    public float yToChange;

    Transform playerTransform;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "PlayerCol")
        {
            playerTransform = col.transform.parent.GetComponent<Transform>();
            ChangePos();
        }
    }

    void ChangePos()
    {
        Vector3 newPos = playerTransform.position;
        newPos.x += xToChange;
        newPos.y += yToChange;
        playerTransform.position = newPos;
        playerTransform = null;
    }
}
