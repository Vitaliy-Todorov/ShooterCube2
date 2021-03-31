using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using System;

public class SaveLoadStorage : MonoBehaviour
{
    protected static string filePath;

    //Сериализует и десериализует объект в двоичном формате.
    static BinaryFormatter bf = new BinaryFormatter();


    /// <summary>
    /// Сохраняем в фаил с именем fileName, временные хранилища
    /// </summary>
    public static void Save(List<StoringLocalData> listGmObj, string fileName)
    {
        string strJsonData = "";
        string jsonData = "";

        foreach (StoringLocalData storingLocal in listGmObj)
        {
            //превращем объект в string закодированный Json
            //добовлем разделитель
            //b?pM&2 - отделяет хранилища
            jsonData = JsonUtility.ToJson(storingLocal, true) + "b?pM&2";
            strJsonData += jsonData;
        }

        //Создаё или перезаписываем фаил для сохранения
        File.WriteAllText(filePath + fileName, strJsonData);
    }

    /// <summary>
    /// Загружает из фаил с именем fileName, временные хранилища
    /// </summary>
    public static void Load(List<StoringLocalData> listGmObj, string fileName)
    {
        //Чтение из файла
        string strJsonData = File.ReadAllText(filePath + fileName);

        string[] separatingStrings = { "b?pM&2" };
        //Разбиваем строку на информацию о разных объектах
        string[] arrayJsonData = strJsonData.Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);

        foreach (var storingLocal in arrayJsonData.Zip(listGmObj, Tuple.Create))
        {
            Debug.Log("storingLocal: " + storingLocal.Item2);
            JsonUtility.FromJsonOverwrite(storingLocal.Item1, storingLocal.Item2);
        }
    }




    /// <summary>
    /// Сохраняем в фаил с именем fileName
    /// </summary>
    public static void Save(List<string> listGmObj, string fileName)
    {
        string jsonData = JsonUtility.ToJson(listGmObj, true);

        //Создаё или перезаписываем фаил для сохранения
        using (FileStream fs = File.Create(filePath + fileName))
        {
            bf.Serialize(fs, jsonData);
        }
    }

    /// <summary>
    /// Загружает из фаил с именем fileName
    /// </summary>
    public static void Load(List<string> listGmObj, string fileName)
    {
        //Чтение из файла
        using (FileStream fs = File.OpenRead(filePath + fileName))
        {
            string ds = (string)bf.Deserialize(fs);
            JsonUtility.FromJsonOverwrite(ds, listGmObj);
        }
    }
}
