using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class RotationStatic : SaveLoadComponent
{
    [SerializeField]
    List<GameObject> listRotatableGmObj = new List<GameObject>();

    private void Awake()
    {
        AddInSaveList();
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (GameObject RotatableGmObj in listRotatableGmObj)
            RotatableGmObj.transform.Rotate(0.0f, 90.0f, 0.0f);
    }

    public override void Save()
    {
        for (int i = 0; i < (listRotatableGmObj.Count); i++)
            storingLocal.ListNormal.Add(listRotatableGmObj[i].transform.forward);
    }

    public override void Load()
    {
        foreach (var RotatableGmObj in storingLocal.ListNormal.Zip(listRotatableGmObj, Tuple.Create))
            RotatableGmObj.Item2.transform.forward = RotatableGmObj.Item1;
        storingLocal.ListNormal.Clear();
    }
}
