using UnityEngine;

public class GunInput : Gun
{
    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            Shot();
    }
}
