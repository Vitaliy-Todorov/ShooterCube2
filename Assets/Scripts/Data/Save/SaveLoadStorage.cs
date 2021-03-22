using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadStorage : MonoBehaviour
{
    protected static string filePath;

    /// <summary>
    /// Сохраняем в фаил с именем fileName, временные хранилища из списка fileName
    /// </summary>
    public static void Save(List<StoringLocalData> listGmObj, string fileName)
    {
        //Для сериализации
        BinaryFormatter bf = new BinaryFormatter();
        //Создаём поток
        FileStream fs = new FileStream(filePath + fileName, FileMode.Create);

        foreach (ScriptableObject saveDate in listGmObj)
        {
            //превращем объект в string закодированный Json
            string jsonData = JsonUtility.ToJson(saveDate, true);

            //сериализуем и сохраняем
            bf.Serialize(fs, jsonData);
        }

        //Закрываем поток
        fs.Close();
    }

    /// <summary>
    /// Загружает из фаил с именем fileName, временные хранилища из списка fileName
    /// </summary>
    public static void Load(List<ScriptableObject> listGmObj, string fileName)
    {
        if (!File.Exists(filePath + fileName))
            return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath + fileName, FileMode.Open);

        foreach (ScriptableObject loadData in listGmObj)
        {
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(fs), loadData);
        }

        fs.Close();
    }
}
