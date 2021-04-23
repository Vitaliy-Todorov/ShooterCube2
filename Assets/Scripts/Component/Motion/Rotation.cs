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
        SaveLoadComponentAndLocalStorage.Set(this, "normal", new LocalStorage(transform.forward));
    }

    public override void Load()
    {
        transform.forward = SaveLoadComponentAndLocalStorage.Get(this, "normal").Vector3;
    }
}
