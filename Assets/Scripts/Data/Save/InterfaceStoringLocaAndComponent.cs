using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Связываем объект, сохраняемые компоненты и временное хранилище данных.
/// </summary>
public class InterfaceStoringLocaAndComponent : MonoBehaviour
{
    [SerializeField]
    StoringLocalData storingLocalForGmObj;

    private static List<StoringLocalData> listAllStoringLocal = new List<StoringLocalData>();

    public static List<StoringLocalData> ListAllStoringLocal { get => listAllStoringLocal; set => listAllStoringLocal = value; }

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
