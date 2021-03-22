using UnityEngine;

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
        filePath = Application.persistentDataPath;

        //Если в память было что-то сохранено с меткой "Load", значит при загрузки сцены выколняем загрузку, указанного в паняти файла
        string fileName = PlayerPrefs.GetString("Load");
        if (fileName != "")
        {
            LoadGame(fileName);
            SaveLoadComponent.LoadAll();
            PlayerPrefs.DeleteKey("Load");
            //Запускаем время после загрузки из игрового меню
            Time.timeScale = 1;
        }

        // Получаем для SaveLoadScene список всех сохраняемых временных хранилищь из SaveLoadComponent (SaveLoadLink)
        ListStoringLocal = InterfaceStoringLocaAndComponent.ListAllStoringLocal;

        // Получаем для StoringLocalData список всех сохраняемых временных хранилищь из SaveLoadComponent (SaveLoadLink)
        StoringLocalData.ListAllStoringLocal = InterfaceStoringLocaAndComponent.ListAllStoringLocal;
    }


}
