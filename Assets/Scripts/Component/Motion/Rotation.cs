using UnityEngine;

public class Rotation : SaveLoadComponent
{
    [SerializeField]
    bool save = true;

    private void Awake()
    {
        if (save)
            SaveLoadComponentAndLocalStorage.listComponents.Add(this);
    }

    public override void Save()
    {
        SaveLoadComponentAndLocalStorage.Set(this, "normal", new LocalStorage(transform.forward));
    }

    public override void Load()
    {
        transform.forward = SaveLoadComponentAndLocalStorage.Get(this, "normal").Vector3;
    }
}
