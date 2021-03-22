using UnityEngine;

public class Rotation : SaveLoadComponent
{
    private void Awake()
    {
        AddInSaveList();
    }

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

    public override void Save()
    {
        storingLocal.NormalModel = transform.forward;
    }

    public override void Load()
    {
        transform.forward = storingLocal.NormalModel;
    }
}
