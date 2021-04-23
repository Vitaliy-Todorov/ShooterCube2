using UnityEngine;

public class Motion : SaveLoadComponent
{
    [SerializeField]
    bool save = true;

    private void Awake()
    {
        if(save)
            SaveLoadComponentAndLocalStorage.listComponents.Add(this);
    }

    private void OnDestroy()
    {
        SaveLoadComponentAndLocalStorage.Remove(this);
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
        SaveLoadComponentAndLocalStorage.Set(this, "position", new LocalStorage(transform.position));
        SaveLoadComponentAndLocalStorage.Set(this, "normal", new LocalStorage(transform.forward));
    }

    public override void Load()
    {
        transform.position = SaveLoadComponentAndLocalStorage.Get(this, "position").Vector3;
        transform.forward = SaveLoadComponentAndLocalStorage.Get(this, "normal").Vector3;
    }
}
