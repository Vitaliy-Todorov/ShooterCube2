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
        AddInSaveList();
    }

    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);

        if (gmObjArmorPaint != null)
        {
            float minusColorG = 250f / 255f - armor / 5f;
            gmObjArmorPaint.GetComponent<Renderer>().material.color = new Color(255f / 255f, minusColorG, 50f / 255f, 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        InflictDamage bullet = other.GetComponent<InflictDamage>();

        if ((other.transform.root != transform.root) && bullet)
        {
            currentHealth -= bullet.Damege / armor;
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
        storingLocal.Health = currentHealth;
    }

    public override void Load()
    {
        base.Load();

        currentHealth = storingLocal.Health;
        healthBar.SetHealth(currentHealth);
    }
}
