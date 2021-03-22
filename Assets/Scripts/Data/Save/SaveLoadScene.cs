using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Загружаем и сохраняем все временные хранилища сцены
/// </summary>
public class SaveLoadScene : SaveLoadStorage
{
    static List<StoringLocalData> listStoringLocal = new List<StoringLocalData>();

    static List<string> listFile = new List<string>();

    public static List<string> ListFile { get => listFile; }
    public static List<StoringLocalData> ListStoringLocal { get => listStoringLocal; set => listStoringLocal = value; }

    /// <summary>
    /// Сохраняем все объекты сцены
    /// </summary>
    public static void SaveGame(string fileName)
    {
        SaveLoadComponent.SaveAll();
        StoringLocalData.SaveDestroyAll();
        listFile.Add(fileName);
        Save(ListStoringLocal, fileName);
    }

    /// <summary>
    /// Загружаем все объекты сцены
    /// </summary>
    public static void LoadGame(string fileName)
    {
        PlayerPrefs.SetString("Load", fileName);
    }
}
