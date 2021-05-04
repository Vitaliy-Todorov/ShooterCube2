using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ���������/��������� � ����
/// </summary>
public class SaveLoadToFile
{
    string _filePath;

    /// <summary>
    /// ���� ����������
    /// </summary>
    public SaveLoadToFile(string filePath)
    {
        _filePath = filePath;
    }

    public void Save<T>(T saveObject, string fileName)
    {
        string strJsonData = JsonConvert.SerializeObject(saveObject);
        File.WriteAllText(_filePath + fileName, strJsonData);
    }

    public T Load<T>(string fileName)
    {
        string strJsonData = File.ReadAllText(_filePath + fileName);
        return JsonConvert.DeserializeObject<T>(strJsonData);
    }
}
