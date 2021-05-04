using UnityEngine;

public class HealthAndDeathLocaStorage
{
    [SerializeField]
    private float health;
    [SerializeField]
    private bool death;

    public float Health { get => health; set => health = value; }
    public bool Death { get => death; set => death = value; }
}
