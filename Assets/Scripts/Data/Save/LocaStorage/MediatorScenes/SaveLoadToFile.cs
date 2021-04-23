using System.IO;
using Newtonsoft.Json;

/// <summary>
/// Сохраняет/загружает в файл
/// </summary>
public class SaveLoadToFile
{
    string _filePath;

    /// <summary>
    /// Путь сохранения
    /// </summary>
    public SaveLoadToFile(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(object saveObject, string fileName)
    {
        string strJsonData = JsonConvert.SerializeObject(saveObject);

        File.WriteAllText(_filePath + fileName, strJsonData);
    }

    public Type Load<Type>(string fileName)
    {
        string strJsonData = File.ReadAllText(_filePath + fileName);

        return JsonConvert.DeserializeObject<Type>(strJsonData);
    }
}
