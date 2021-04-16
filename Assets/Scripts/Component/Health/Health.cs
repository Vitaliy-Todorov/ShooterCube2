using UnityEngine;

public class Health : Death
{
    [Header("ArmorHealth")]

    [SerializeField]
    int maxHealth;
    [SerializeField]
    float currentHealth;
    [SerializeField]
    HealthBar healthBar;

    [Header("Armor")]

    [SerializeField]
    [Range(1, 5)]
    int armor = 1;
    [SerializeField]
    GameObject gmObjArmorPaint;

    private void Awake()
    {
        //AddInSaveList();
        SaveLoadAllComponent.listComponents.Add(this);
    }

    private void Start()
    {
        if (!(healthBar == null))
        {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(currentHealth);
        }

        if (gmObjArmorPaint != null)
        {
            float minusColorG = 250f / 255f - armor / 5f;
            gmObjArmorPaint.GetComponent<Renderer>().material.color = new Color(255f / 255f, minusColorG, 50f / 255f, 1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        InflictDamage bullet = collision.gameObject.GetComponent<InflictDamage>();

        if ((collision.gameObject.transform.root != transform.root) && bullet)
        {
            currentHealth -= bullet.Damege / armor;
            if (!(healthBar == null))
                healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                DeathRoot();
            }
        }
    }

    public override void Save()
    {
        base.Save();
        //storingLocal.Health = currentHealth;
        SaveLoadAllComponent.Set(this, "health", currentHealth);
    }

    public override void Load()
    {
        base.Load();

        //currentHealth = storingLocal.Health;
        currentHealth = (float) SaveLoadAllComponent.Get(this, "health");
        if(healthBar != null)
            healthBar.SetHealth(currentHealth);
    }
}
