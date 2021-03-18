using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadScene : SaveLoadStorage
{
    protected static List<ScriptableObject> listGmObj;

    static List<string> listFile = new List<string>();

    public static List<string> ListFile { get => listFile; }

    /// <summary>
    /// Сохраняем все объекты сцены
    /// </summary>
    public static void SaveGame(string fileName)
    {
        listFile.Add(fileName);
        Save(listGmObj, fileName);
    }

    /// <summary>
    /// Загружаем все объекты сцены
    /// </summary>
    public static void LoadGame(string fileName)
    {
        Load(listGmObj, fileName);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
