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
            //превращем объект в string закодированный Json и добовлем разделитель, отмечающий,
            //что заончилась информация от одном объекте
            jsonData = JsonUtility.ToJson(storingLocal, true) + "b?pM&2";
            strJsonData += jsonData;
        }

        Debug.Log(strJsonData);

        //Создаё или перезаписываем фаил для сохранения
        /*using (FileStream fs = File.Create(filePath + fileName))
        {
            bf.Serialize(fs, jsonData);
        }*/
        File.WriteAllText(filePath + fileName, strJsonData);
    }

    /// <summary>
    /// Загружает из фаил с именем fileName, временные хранилища
    /// </summary>
    public static void Load(List<StoringLocalData> listGmObj, string fileName)
    {
        string strJsonData = File.ReadAllText(filePath + fileName);
        /*string strJsonData;
        //Чтение из файла
        using (FileStream fs = File.OpenRead(filePath + fileName))
        {
            strJsonData = (string)bf.Deserialize(fs);
        }*/
        Debug.Log(strJsonData);

        string[] separatingStrings = { "b?pM&2" };
        //Разбиваем на информацию о разных объектах
        string[] arrayJsonData = strJsonData.Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);

        foreach (var storingLocal in arrayJsonData.Zip(listGmObj, Tuple.Create))
        {
            JsonUtility.FromJsonOverwrite(storingLocal.Item1, storingLocal.Item2);
        }
    }




    /// <summary>
    /// Сохраняем в фаил с именем fileName, временные хранилища
    /// </summary>
    public static void Save(ScriptableObject storingLoca, string fileName)
    {
        //Создаё или перезаписываем фаил для сохранения
        using (FileStream fs = File.Create(filePath + fileName))
        {
            string jsonData = JsonUtility.ToJson(storingLoca, true);
            bf.Serialize(fs, jsonData);
        }
    }

    /// <summary>
    /// Загружает из фаил с именем fileName, временные хранилища
    /// </summary>
    public static void Load(ScriptableObject storingLoca, string fileName)
    {
        //Чтение из файла
        using (FileStream fs = File.OpenRead(filePath + fileName))
        {
            string ds = (string)bf.Deserialize(fs);
            JsonUtility.FromJsonOverwrite(ds, storingLoca);
        }
    }




    /// <summary>
    /// Сохраняем в фаил с именем fileName
    /// </summary>
    public static void Save(List<string> listGmObj, string fileName)
    {
        //Создаё или перезаписываем фаил для сохранения
        using (FileStream fs = File.Create(filePath + fileName))
        {
            string jsonData = JsonUtility.ToJson(listGmObj, true);
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
