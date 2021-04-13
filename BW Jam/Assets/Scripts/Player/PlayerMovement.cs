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
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
