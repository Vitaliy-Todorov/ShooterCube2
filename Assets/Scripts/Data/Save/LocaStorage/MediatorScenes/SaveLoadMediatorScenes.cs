using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadMediatorScenes : SaveLoadAllComponent
{
    static List<string> listSaveName = new List<string>();
    static string _filePath = "";

    void Start()
    {
        //НЕ ТРОЖ ПУТЬ НАЗНАЧЕНИЯ!!
        //Путь назначается здесь т. к.
        //get_persistentDataPath не может быть вызван из конструктора MonoBehaviour (или инициализатора поля экземпляра) 
        //Хотя переменная объявляется и используется в SaveLoadStorage
        _filePath = Application.dataPath;

        //Если в память было что-то сохранено с меткой "Load", значит при загрузки сцены выколняем загрузку, указанного в паняти файла
        string fileName = PlayerPrefs.GetString("Load");
        if (fileName != "")
        {
            LoadGame(fileName);
        }
    }

    private void OnDestroy()
    {
        listComponents.Clear();
    }

    /// <summary>
    /// Сохраняем все объекты сцены
    /// </summary>
    public static void SaveGame(string fileName)
    {
        SomeSaveLoadStoring saveLoad = new SomeSaveLoadStoring(_filePath);

        //Сохраняем название файла
        if(!listSaveName.Contains(fileName))
            listSaveName.Add(fileName);
        saveLoad.Save(listSaveName, "/listSaveName");

        //Сохраняем название сцены (связка названия сохранения и названия сцены)
        string sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString(fileName, sceneName);

        SaveAllComponent();
        SaveDestroyAll();
        saveLoad.Save(dictionaryMediatorComponentAndValue, fileName);
    }

    /// <summary>
    /// Загружаем все объекты сцены
    /// </summary>
    public static void LoadGame(string fileName)
    {
        SomeSaveLoadStoring saveLoad = new SomeSaveLoadStoring(_filePath);

        PlayerPrefs.DeleteKey("Load");
        //Load(listSaveName, "/listSaveName");
        //dictionaryMediatorComponentAndValue = (Dictionary<string, object>) saveLoad.Load(fileName);

        /*foreach (SaveLoadComponent x in listComponents)
            Debug.Log(x);*/
        LoadAllComponent();
    }

    public static void LoadGameInManu(string fileName)
    {
        //Говорим InterfaceSaveLoadScene о том что нужно производить загрузку файла после запуска сцены и говорим какой файл загружать fileName
        PlayerPrefs.SetString("Load", fileName);

        //Получаем название сцены в которой был сохранён fileName
        string sceneName = PlayerPrefs.GetString(fileName);
        SceneManager.LoadScene(sceneName);
    }
}
