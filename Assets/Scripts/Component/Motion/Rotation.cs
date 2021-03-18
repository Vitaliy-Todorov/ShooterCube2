using UnityEngine;

public class Rotation : SaveLoadComponent
{
    [SerializeField]
    bool save;
    StoringLocalData storingLocal;

    private void Awake()
    {
        if (save)
        {
            storingLocal = listStoringLocal[gameObject];
            dictionaryComponentGmObj[gameObject].Add(this);
        }
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
        storingLocal.CurrentNormal = transform.forward;
    }

    public override void Load()
    {
        transform.forward = storingLocal.CurrentNormal;
    }
}
