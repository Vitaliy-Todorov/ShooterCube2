using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SomeSaveLoadStoring
{
    string _filePath;

    public SomeSaveLoadStoring(string filePath)
    {
        _filePath = filePath;
    }

    //Помещаем данные в хранилище
    public void Save(object saveObject, string fileName)
    {
        string saveStr = JsonUtility.ToJson(saveObject);

        File.WriteAllText(_filePath + fileName, saveStr);
    }

    //Выгружаем данные из хранилища
    public object Load(string fileName)
    {
        //Чтение из файла
        string save = File.ReadAllText(_filePath + fileName);

        return JsonUtility.FromJson<Dictionary<string, object>>(save);
    }
}
