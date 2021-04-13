using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Thanks Brackeys and david timms
    public float moveSpeed;

    public Rigidbody2D rb;

    Vector2 movement;

    public bool lostUpMov;
    public bool lostRightMov;

    bool lookingRight;

    // [HideInInspector] 

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(lostUpMov)
        {
            if(movement.y == 1)
            {
                movement.y = 0;
            }
        }

        if(lostRightMov)
        {
            if(movement.x == 1)
            {
                movement.x = 0;
            }
        }

        CheckFlip();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void CheckFlip()
    {
        if(movement.x == 1 && !lookingRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            lookingRight = true;
        }
        else if(movement.x == -1)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            lookingRight = false;
        }
    }
}
