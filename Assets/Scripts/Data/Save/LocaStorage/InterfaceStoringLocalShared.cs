using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Связываем объект, сохраняемые компоненты и временное хранилище данных.
/// </summary>
public class InterfaceStoringLocalShared : MonoBehaviour
{
    //Сортируется в InterfaceSaveLoadScene.
    //Не здесь, так как Shared запускается перед EachObject (так как здесь обявляется listAllStoringLocal),
    //то и сортровать здесь нечего, а EachObject запускается при создании каждого объекта, поэтому и там сортировать не оптимально.
    protected static List<StoringLocalData> listAllStoringLocal = new List<StoringLocalData>();

    public static List<StoringLocalData> ListAllStoringLocal { get => listAllStoringLocal; set => listAllStoringLocal = value; }

    private void OnDestroy()
    {
        listAllStoringLocal.Clear();
        //Очищаем список сохраняемых компонент (делаем здесь так как экземпляры SaveLoadComponent не создаются )
        SaveLoadComponent.Clear();
    }
}
