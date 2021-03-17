using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : SaveLoadComponent
{
    [SerializeField]
    bool save;

    private void Awake()
    {
        //Добавляем объект в список сохранемых
        if (save)
            dictionaryComponentGmObj[gameObject].Add(this);
    }

    public override void Save()
    {
        Debug.Log("HealthSave");
    }

    public override void Load()
    {
        Debug.Log("HealthLoad");
    }
}
