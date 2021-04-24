using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationInput : Rotation
{
    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            transform.Rotate(0.0f, -90.0f, 0.0f);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            transform.Rotate(0.0f, 90.0f, 0.0f);
        }
    }
}
