using UnityEngine;

public class Death : SaveLoadComponent
{
    bool death;

    private void Awake()
    {
        AddInSaveList();
    }

    public void DeathRoot()
    {
        storingLocal.CurrentDeath = true;
        dictionaryComponentGmObj.Remove(gameObject);
        Destroy(transform.root.gameObject);
    }

    public override void Save()
    {
        storingLocal.CurrentDeath = death;
        storingLocal.SaveDestroy();
    }

    public override void Load()
    {
        death = storingLocal.SaveDeath;
        if (death)
            DeathRoot();
    }
}
