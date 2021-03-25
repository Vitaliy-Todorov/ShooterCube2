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
        //Для сериализации
        BinaryFormatter bf = new BinaryFormatter();
        //Создаём поток
        FileStream fs = new FileStream(filePath + fileName, FileMode.Create);

        foreach (StoringLocalData saveDate in listGmObj)
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
    /// Загружает из фаил с именем fileName, временные хранилища
    /// </summary>
    public static void Load(List<StoringLocalData> listGmObj, string fileName)
    {
        if (!File.Exists(filePath + fileName))
            return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath + fileName, FileMode.Open);

        foreach (StoringLocalData loadData in listGmObj)
        {
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(fs), loadData);
        }

        fs.Close();
    }

    /// <summary>
    /// Сохраняем в фаил с именем fileName, временные хранилища
    /// </summary>
    public static void Save(ScriptableObject storingLoca, string fileName)
    {
        //превращем объект в string закодированный Json
        string jsonData = JsonUtility.ToJson(storingLoca, true);

        using (FileStream fstream = File.Create(filePath + fileName))
        {
            // преобразуем строку в байты
            byte[] array = System.Text.Encoding.Default.GetBytes(jsonData);
            // запись массива байтов в файл
            fstream.Write(array, 0, array.Length);
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
        FileStream fs = new FileStream(filePath + fileName, FileMode.Open);

        JsonUtility.FromJsonOverwrite((string)bf.Deserialize(fs), storingLoca);
        
        fs.Close();
    }
}
