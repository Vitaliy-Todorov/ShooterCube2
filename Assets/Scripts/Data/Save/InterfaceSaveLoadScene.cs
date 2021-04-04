using UnityEngine;
using System.Linq;

/// <summary>
/// Загружаем данные из файла при создании сцены
/// А так же связываем постоянное хранилище и временные.
/// </summary>
public class InterfaceSaveLoadScene : SaveLoadScene
{
    void Start()
    {
        //НЕ ТРОЖ ПУТЬ НАЗНАЧЕНИЯ!!
        //Путь назначается здесь т. к.
        //get_persistentDataPath не может быть вызван из конструктора MonoBehaviour (или инициализатора поля экземпляра) 
        //Хотя переменная объявляется и используется в SaveLoadStorage
        filePath = Application.dataPath;

        // Получаем для SaveLoadScene список всех сохраняемых временных хранилищь из SaveLoadComponent (SaveLoadLink)
        ListAllStoringLocal = InterfaceStoringLocalShared.ListAllStoringLocal;

        // Получаем для StoringLocalData список всех сохраняемых временных хранилищь из SaveLoadComponent (SaveLoadLink)
        StoringLocalData.ListAllStoringLocal = InterfaceStoringLocalShared.ListAllStoringLocal;

        //Если в память было что-то сохранено с меткой "Load", значит при загрузки сцены выколняем загрузку, указанного в паняти файла
        string fileName = PlayerPrefs.GetString("Load");
        if (fileName != "")
        {
            LoadGame(fileName);
        }
    }

    private void OnDestroy()
    {
        //Очищаем список сохраняемых компонент (делаем здесь так как экземпляры SaveLoadComponent не создаются )
        SaveLoadComponent.Clear();
    }
}
