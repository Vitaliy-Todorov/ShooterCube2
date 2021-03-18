using UnityEngine;

public class Motion : SaveLoadComponent
{
    [SerializeField]
    bool save;
    StoringLocalData storingLocal;

    private void Awake()
    {
        if (save)
        {
            storingLocal = listStoringLocal[gameObject];
            dictionaryComponentGmObj[gameObject].Add(this);
        }
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
        storingLocal.CurrentPosition = transform.position;
        storingLocal.CurrentNormal = transform.forward;
    }

    public override void Load()
    {
        transform.position = storingLocal.CurrentPosition;
        transform.forward = storingLocal.CurrentNormal;
    }
}
