using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadScene : SaveLoadComponentAndLocalStorage
{
    static List<string> listSaveName = new List<string>();
    static string _filePath = "";

    void Start()
    {
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
        //Очищаем статические поля
        listComponents.Clear();
        dictionaryComponentAndLocalStorage.Clear();
    }

    /// <summary>
    /// Сохраняем информацию со всех объектов сцены
    /// </summary>
    public static void SaveGame(string fileName)
    {
        SaveLoadToFile saveLoad = new SaveLoadToFile(_filePath);

        //Сохраняем название файла
        if(!listSaveName.Contains(fileName))
            listSaveName.Add(fileName);

        //Сохраняем список названий файлов
        saveLoad.Save(listSaveName, "/listSaveName");

        //Сохраняем название сцены (связка названия сохранения и названия сцены)
        string sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString(fileName, sceneName);

        //Помещаем сохраняемую информацию в LocalStorage. Помещаем все LocalStorage в словарь и сохраняем словарь
        SaveAllComponent();
        saveLoad.Save(dictionaryComponentAndLocalStorage, fileName);
    }

    /// <summary>
    /// Загружаем информацию для всех объектов сцены
    /// </summary>
    public static void LoadGame(string fileName)
    {
        SaveLoadToFile saveLoad = new SaveLoadToFile(_filePath);

        PlayerPrefs.DeleteKey("Load");
        //Load(listSaveName, "/listSaveName");
        dictionaryComponentAndLocalStorage = saveLoad.Load<Dictionary<string, LocalStorage>>(fileName);

        LoadAllComponent();
    }

    public static void LoadGameInManu(string fileName)
    {
        //Говорим что нужно производить загрузку файла после запуска сцены и говорим какой файл загружать: fileName
        PlayerPrefs.SetString("Load", fileName);

        //Получаем название сцены в которой был сохранён fileName
        string sceneName = PlayerPrefs.GetString(fileName);
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Помещаем сохраняемую информацию в LocalStorage для всх Component. 
    /// Помещаем все LocalStorage в словарь dictionaryComponentAndLocalStorage
    /// </summary>
    public static void SaveAllComponent()
    {
        foreach (SaveLoadComponent component in listComponents)
            component.Save();
    }

    /// <summary>
    /// Выгружаем LocalStorage из dictionaryComponentAndLocalStorage для всех Component.
    /// </summary>
    public static void LoadAllComponent()
    {
        foreach (SaveLoadComponent component in listComponents)
            component.Load();
    }
}
