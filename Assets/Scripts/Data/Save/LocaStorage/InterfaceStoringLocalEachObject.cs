using System.Collections.Generic;
using UnityEngine;

public class InterfaceStoringLocalEachObject : InterfaceStoringLocalShared
{
    [SerializeField]
    StoringLocalData storingLocalForGmObj;

    private void Awake()
    {
        //—в€зываем конкретный объект с временным хранилищем его данных
        SaveLoadComponent.DictionaryGmOdjAndStoringLocal[gameObject] = storingLocalForGmObj;

        //—оздаЄм список дл€ св€зываем игровой объект и те компаненты, информацию с которых сохран€ем (компоненты в список добовл€ютс€ в AddInSaveList)
        SaveLoadComponent.AddListComponents(gameObject);

        listAllStoringLocal.Add(storingLocalForGmObj);
    }

    private void OnDestroy()
    {
        SaveLoadComponent.Remove(gameObject);
    }
}
