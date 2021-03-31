using System.Collections.Generic;
using UnityEngine;

public class InterfaceStoringLocalEachObject : InterfaceStoringLocalShared
{
    [SerializeField]
    StoringLocalData storingLocalForGmObj;

    private void Awake()
    {
        //Связываем конкретный объект с временным хранилищем его данных
        SaveLoadComponent.ListStoringLocal[gameObject] = storingLocalForGmObj;

        //Связываем игровой объект и те компаненты, информацию с которых сохраняем
        SaveLoadComponent.DictionaryComponentGmObj[gameObject] = new List<SaveLoadComponent>();

        listAllStoringLocal.Add(storingLocalForGmObj);
    }

    private void OnDestroy()
    {
        SaveLoadComponent.ListStoringLocal.Remove(gameObject);

        SaveLoadComponent.DictionaryComponentGmObj.Remove(gameObject);
    }
}
