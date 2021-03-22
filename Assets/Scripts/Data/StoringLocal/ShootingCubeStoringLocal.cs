using UnityEngine;

/// <summary>
/// Временное хранилище данных
/// </summary>
[CreateAssetMenu(fileName = "Nwe Save Data", menuName = "ShootingCube", order = 1)]
public class ShootingCubeStoringLocal : StoringLocalData
{
    [Header("Position")]

    [SerializeField]
    Vector3 position;
    [SerializeField]
    Vector3 normal;
    [SerializeField]
    Vector3 normalModel;

    [Header("Health")]

    [SerializeField]
    float health;

    [SerializeField]
    bool currentDeath;
    [SerializeField]
    bool saveDeath;

    public override Vector3 Position
    {
        set { position = value; }
        get { return position; }
    }

    public override Vector3 Normal
    {
        set { normal = value; }
        get { return normal; }
    }
    public override Vector3 NormalModel { get => normalModel; set => normalModel = value; }

    public override float Health
        { get => health; set => health = value; }

    public override bool CurrentDeath
        { get => currentDeath; set => currentDeath = value; }

    public override bool SaveDeath { get => saveDeath; set => saveDeath = value; }

    public override void SaveDestroy()
    {
        base.SaveDestroy();

        saveDeath = currentDeath;
    }
}
