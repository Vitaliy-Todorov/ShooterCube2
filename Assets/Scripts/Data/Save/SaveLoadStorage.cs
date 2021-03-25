using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadStorage : MonoBehaviour
{
    protected static string filePath;

    /// <summary>
    /// Сохраняем в фаил с именем fileName, временные хранилища
    /// </summary>
    public static void Save(List<StoringLocalData> listGmObj, string fileName)
    {
        //Сериализует и десериализует объект в двоичном формате.
        BinaryFormatter bf = new BinaryFormatter();

        //Создаё или перезаписываем фаил для сохранения
        using (FileStream fs = File.Create(filePath + fileName))
        {
            foreach (StoringLocalData saveDate in listGmObj)
            {
                //превращем объект в string закодированный Json
                string jsonData = JsonUtility.ToJson(saveDate, true);

                //сериализуем и сохраняем
                bf.Serialize(fs, jsonData);
            }
        }
    }

    /// <summary>
    /// Загружает из фаил с именем fileName, временные хранилища
    /// </summary>
    public static void Load(List<StoringLocalData> listGmObj, string fileName)
    {
        if (!File.Exists(filePath + fileName))
            return;

        BinaryFormatter bf = new BinaryFormatter();

        //Чтение из файла
        using (FileStream fs = File.OpenRead(filePath + fileName))
        {
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(fs), listGmObj);
        }
    }

    /// <summary>
    /// Сохраняем в фаил с именем fileName, временные хранилища
    /// </summary>
    public static void Save(ScriptableObject storingLoca, string fileName)
    {
        //превращем объект в string закодированный Json
        string jsonData = JsonUtility.ToJson(storingLoca, true);

        BinaryFormatter bf = new BinaryFormatter();

        //Создаё или перезаписываем фаил для сохранения
        using (FileStream fs = File.Create(filePath + fileName))
        {
            bf.Serialize(fs, jsonData);
        }
    }

    /// <summary>
    /// Загружает из фаил с именем fileName, временные хранилища
    /// </summary>
    public static void Load(ScriptableObject storingLoca, string fileName)
    {
        if (!File.Exists(filePath + fileName))
            return;

        BinaryFormatter bf = new BinaryFormatter();

        //Чтение из файла
        using (FileStream fs = File.OpenRead(filePath + fileName))
        {
            JsonUtility.FromJsonOverwrite((string) bf.Deserialize(fs), storingLoca);
        }
    }
}
