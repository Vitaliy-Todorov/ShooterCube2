using UnityEngine;

public class Motion : SaveLoadComponent
{
    private void Awake()
    {
        AddInSaveList();
    }

    public void Move(Vector3 movement, float speed)
    {
        transform.Translate(movement * speed * Time.fixedDeltaTime, Space.World);
    }

    public void Teleportation(Vector3 positionTeleportation, Vector3 normalTeleportation)
    {
        transform.position = positionTeleportation;
        transform.forward = normalTeleportation;
    }

    public override void Save()
    {
        storingLocal.Position = transform.position;
        storingLocal.Normal = transform.forward;
    }

    public override void Load()
    {
        transform.position = storingLocal.Position;
        transform.forward = storingLocal.Normal;
    }
}
