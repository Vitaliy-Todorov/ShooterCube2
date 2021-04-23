using UnityEngine;

public class Death : SaveLoadComponent
{
    bool death;
    protected LocalStorage locaStorage = new LocalStorage();

    [SerializeField]
    bool save = true;

    private void Awake()
    {
        if (save)
            SaveLoadComponentAndLocalStorage.listComponents.Add(this);
    }

    public void DeathRoot()
    {
        death = true;
        locaStorage.HealthAndDeath.Death = death;

        SaveLoadComponentAndLocalStorage.Set(this, "healthAndDeath", locaStorage);
        //SaveLoadComponentAndLocalStorage.Remove(this);

        Destroy(transform.root.gameObject);
    }

    public override void Save()
    {
        locaStorage.HealthAndDeath.Death = death;
        SaveLoadComponentAndLocalStorage.Set(this, "healthAndDeath", locaStorage);
    }

    public override void Load()
    {
        locaStorage = SaveLoadComponentAndLocalStorage.Get(this, "healthAndDeath");
        death = locaStorage.HealthAndDeath.Death;
        if (death)
            DeathRoot();
    }
}
