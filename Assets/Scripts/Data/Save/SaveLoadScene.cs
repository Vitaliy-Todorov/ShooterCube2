using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadScene : SaveLoadStorage
{
    static List<StoringLocalData> listAllStoringLocal = new List<StoringLocalData>();

    static List<string> listSaveName = new List<string>();

    public static List<StoringLocalData> ListAllStoringLocal { get => listAllStoringLocal; set => listAllStoringLocal = value; }

    /// <summary>
    /// Сохраняем все объекты сцены
    /// </summary>
    public static void SaveGame(string fileName)
    {
        listSaveName.Add(fileName);
        Save(listSaveName, "/listSaveName");
        //Сохраняем название сцены (связка названия сохранения и названия сцены)
        string sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString(fileName, sceneName);

        SaveLoadComponent.SaveAll();
        StoringLocalData.SaveDestroyAll();
        Save(listAllStoringLocal, fileName);
    }

    /// <summary>
    /// Загружаем все объекты сцены
    /// </summary>
    public static void LoadGame(string fileName)
    {
        Load(listSaveName, "/listSaveName");
        Load(listAllStoringLocal, fileName);

        SaveLoadComponent.LoadAll();
        PlayerPrefs.DeleteKey("Load");
    }

    public static void LoadGameInManu(string fileName)
    {
        Load(listSaveName, "/listSaveName");

        //Говорим InterfaceSaveLoadScene о том что нужно производить загрузку файла после запуска сцены и говорим какой файл загружать fileName
        PlayerPrefs.SetString("Load", fileName);

        //Получаем название сцены в которой был сохранён fileName
        string sceneName = PlayerPrefs.GetString(fileName);
        SceneManager.LoadScene(sceneName);
    }
}
