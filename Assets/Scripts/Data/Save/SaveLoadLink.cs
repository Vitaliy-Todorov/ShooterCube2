using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Связываем объект, сохраняемые компоненты и временное хранилище данных
/// </summary>
public class SaveLoadLink : MonoBehaviour
{
    [SerializeField]
    StoringLocalData storingLocal;

    private void Awake()
    {
        //Связываем конкретный объект с временным хранилищем его данных
        SaveLoadComponent.ListStoringLocal[gameObject] = storingLocal;

        //Связываем объект и те компаненты информацию с которых нужно сохранить
        SaveLoadComponent.DictionaryComponentGmObj[gameObject] = new List<SaveLoadComponent>();
    }
}
