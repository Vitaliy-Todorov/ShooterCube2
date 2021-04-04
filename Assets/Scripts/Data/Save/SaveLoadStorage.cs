using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
//using System.Linq;
using System;

public class SaveLoadStorage : MonoBehaviour
{
    protected static string filePath;

    //Сериализует и десериализует объект в двоичном формате.
    static BinaryFormatter bf = new BinaryFormatter();

    static Dictionary<string, string> dicictionaryStoringLocalStr = new Dictionary<string, string>();


    /// <summary>
    /// Сохраняем в фаил с именем fileName, временные хранилища
    /// </summary>
    public static void Save(List<StoringLocalData> listStoringLocal, string fileName)
    {
        //listStoringLocal = listStoringLocal.OrderBy(storingLocal => storingLocal.name).ToList(); упорядочиваем по имени
        string strJsonData = "";
        string jsonData = "";

        foreach (StoringLocalData storingLocal in listStoringLocal)
        {
            //превращем объект в string закодированный Json
            //добовлем разделитель
            //b?pM&2 - отделяет хранилища
            jsonData = storingLocal.name + "=h25~Q" + JsonUtility.ToJson(storingLocal, true) + "b?pM&2";
            strJsonData += jsonData;
        }

        //Создаё или перезаписываем фаил для сохранения
        File.WriteAllText(filePath + fileName, strJsonData);

        dicictionaryStoringLocalStr.Clear();
    }

    /// <summary>
    /// Загружает из фаил с именем fileName, временные хранилища
    /// </summary>
    public static void Load(List<StoringLocalData> listStoringLocal, string fileName)
    {
        //listStoringLocal = listStoringLocal.OrderBy(storingLocal => storingLocal.name).ToList();
        //Чтение из файла
        string strJsonData = File.ReadAllText(filePath + fileName);

        string[] separatingStrings = { "b?pM&2" };
        //Разбиваем строку на информацию о разных объектах
        string[] arrayJsonData = strJsonData.Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);

        string[] storingLocalNameValue;

        foreach (string strStoringLocal in arrayJsonData)
        {
            separatingStrings = new[] { "=h25~Q" };
            //Разбиваем строку на имя и информацию хранящуюся в хранилище
            storingLocalNameValue = strStoringLocal.Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);
            dicictionaryStoringLocalStr.Add(storingLocalNameValue[0], storingLocalNameValue[1]);
        }

        foreach (StoringLocalData storingLocal in listStoringLocal)
            JsonUtility.FromJsonOverwrite(dicictionaryStoringLocalStr[storingLocal.name], storingLocal);

        dicictionaryStoringLocalStr.Clear();
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
