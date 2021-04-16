using UnityEngine;

public class Death : SaveLoadComponent
{
    bool death;

    private void Awake()
    {
        //AddInSaveList();
        SaveLoadAllComponent.listComponents.Add(this);
    }

    public void DeathRoot()
    {
        death = true;
        SaveLoadAllComponent.Set(this, ".death", death);
        Remove(gameObject);
        Destroy(transform.root.gameObject);
    }

    public override void Save()
    {
        SaveLoadAllComponent.Set(this, ".death", death);
    }

    public override void Load()
    {
        Debug.Log(this);
        death = (bool) SaveLoadAllComponent.Get(this, ".death");
        if (death)
            DeathRoot();
    }
}
