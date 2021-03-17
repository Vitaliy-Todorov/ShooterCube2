using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionInput : Motion
{
    [SerializeField]
    float speed = 10.0f;
    bool click;
    float horizontal;
    float vertical;

    private void FixedUpdate()
    {
        horizontal = 0.0f;
        vertical = 0.0f;
        if (Input.GetAxis("Horizontal") != 0.0f && click)
        {
            click = false;
            horizontal = Input.GetAxis("Horizontal");
        }
        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            click = true;
        }
        if (Input.GetAxis("Vertical") != 0.0f && click)
        {
            click = false;
            vertical = Input.GetAxis("Vertical");
        }
        if (Input.GetAxis("Vertical") == 0.0f)
        {
            click = true;
        }

        if ((horizontal != 0) || (vertical != 0))
        {
            Vector3 movement = new Vector3(horizontal, 0, vertical);
            Move(movement, speed);
        }
    }
}
