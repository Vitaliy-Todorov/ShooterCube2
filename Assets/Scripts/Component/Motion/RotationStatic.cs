using System.Collections.Generic;
using UnityEngine;

public class RotationStatic : SaveLoadComponent
{
    [SerializeField]
    List<GameObject> listRotatableGmObj = new List<GameObject>();

    [SerializeField]
    bool save = true;

    private void Awake()
    {
        if (save)
            SaveLoadComponentAndLocalStorage.listComponents.Add(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (GameObject rotatableGmObj in listRotatableGmObj)
            rotatableGmObj.transform.Rotate(0.0f, 90.0f, 0.0f);
    }

    public override void Save()
    {
        foreach (GameObject rotatableGmObj in listRotatableGmObj)
            SaveLoadComponentAndLocalStorage.Set(this,rotatableGmObj + "normal", new LocalStorage(rotatableGmObj.transform.forward));
    }

    public override void Load()
    {
        foreach (GameObject rotatableGmObj in listRotatableGmObj)
            rotatableGmObj.transform.forward = SaveLoadComponentAndLocalStorage.Get(this,rotatableGmObj + "normal").Vector3ToStorage;
    }
}
