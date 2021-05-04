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

    private void OnDestroy()
    {
        SaveLoadComponentAndLocalStorage.RemoveDictionary(this, transform.root + "normal");
    }

    public override void Save()
    {
        try
        {
            SaveLoadComponentAndLocalStorage.Set(this, transform.root + "normal", new LocalStorage(transform.forward));
        }
        catch { }
    }

    public override void Load()
    {
        try
        {
            transform.forward = SaveLoadComponentAndLocalStorage.Get(this, transform.root + "normal").Vector3ToStorage;
        }
        catch { }
    }
}
