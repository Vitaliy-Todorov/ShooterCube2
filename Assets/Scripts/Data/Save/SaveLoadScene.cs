using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadScene : SaveLoadStorage
{
    static List<StoringLocalData> listAllStoringLocal = new List<StoringLocalData>();

    protected static SaveNameAndScenes saveNameAndScenes;

    public static List<StoringLocalData> ListAllStoringLocal { get => listAllStoringLocal; set => listAllStoringLocal = value; }

    /// <summary>
    /// Сохраняем все объекты сцены
    /// </summary>
    public static void SaveGame(string fileName)
    {
        //Сохраняем название сцены (связка названия сохранения и названия сцены)
        string sceneName = SceneManager.GetActiveScene().name;
        if (saveNameAndScenes.ContainsSave(fileName))
            saveNameAndScenes.ChangeScene(fileName, sceneName);
        else
            saveNameAndScenes.AddSave(fileName, sceneName);
        Save(saveNameAndScenes, "/listSaveName.gamesave");

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

        SaveLoadComponent.LoadAll();
        PlayerPrefs.DeleteKey("Load");
        //Запускаем время после загрузки
        Time.timeScale = 1;
    }

    public static void LoadGameInManu(string fileName)
    {
        Load(saveNameAndScenes, "/listSaveName");

        //Очищаем список сохраняемых хранилищь
        InterfaceStoringLocaAndComponent.ListAllStoringLocal.Clear();

        //Говорим InterfaceSaveLoadScene о том что нужно производить загрузку файла после запуска сцены и говорим какой файл загружать fileName
        PlayerPrefs.SetString("Load", fileName);

        //Получаем название сцены в которой был сохранён fileName
        string sceneName = saveNameAndScenes.GetScenes(fileName);
        SceneManager.LoadScene(sceneName);
    }
}
