using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadScene : SaveLoadStorage
{
    static List<StoringLocalData> listAllStoringLocal = new List<StoringLocalData>();

    static Dictionary<string, string> dictionaryFileName = new Dictionary<string, string>();
    protected static SaveNameAndScenes saveNameAndScenes;

    public static Dictionary<string, string> DictionaryFileName { get => dictionaryFileName; }
    public static List<StoringLocalData> ListAllStoringLocal { get => listAllStoringLocal; set => listAllStoringLocal = value; }

    /// <summary>
    /// Сохраняем все объекты сцены
    /// </summary>
    public static void SaveGame(string fileName)
    {
        //Сохраняем название сцены (связка названия сохранения и названия сцены)
        string sceneName = SceneManager.GetActiveScene().name;
        if (dictionaryFileName.ContainsKey(fileName))
        {
            saveNameAndScenes.health = 23;
            dictionaryFileName[fileName] = sceneName;
            saveNameAndScenes.Dictionary = dictionaryFileName;
            Save(saveNameAndScenes, "/listSaveName.gamesave");
        }
        else
        {
            saveNameAndScenes.health = 23;
            dictionaryFileName.Add(fileName, sceneName);
            saveNameAndScenes.Dictionary = dictionaryFileName;
            Save(saveNameAndScenes, "/listSaveName.gamesave");
        }

        SaveLoadComponent.SaveAll();
        StoringLocalData.SaveDestroyAll();
        Save(listAllStoringLocal, fileName);
    }

    /// <summary>
    /// Загружаем все объекты сцены
    /// </summary>
    public static void LoadGame(string fileName)
    {
        Load(listAllStoringLocal, fileName);
        dictionaryFileName = saveNameAndScenes.Dictionary;

        SaveLoadComponent.LoadAll();
        PlayerPrefs.DeleteKey("Load");
        //Запускаем время после загрузки
        Time.timeScale = 1;
    }

    public static void LoadGameInManu(string fileName)
    {
        Load(saveNameAndScenes, "/listSaveName");
        dictionaryFileName = saveNameAndScenes.Dictionary;
        _ = dictionaryFileName;
        _ = saveNameAndScenes.health;

        //Очищаем список сохраняемых хранилищь
        InterfaceStoringLocaAndComponent.ListAllStoringLocal.Clear();

        //Говорим InterfaceSaveLoadScene о том что нужно производить загрузку файла после запуска сцены и говорим какой файл загружать fileName
        PlayerPrefs.SetString("Load", fileName);

        //Получаем название сцены в которой был сохранён fileName
        string sceneName = dictionaryFileName[fileName];
        SceneManager.LoadScene(sceneName);
    }
}
