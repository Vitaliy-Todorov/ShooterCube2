using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadStorage : MonoBehaviour
{
    protected static string filePath;

    public static void Save(List<ScriptableObject> listGmObj, string fileName)
    {
        //��� ������������
        BinaryFormatter bf = new BinaryFormatter();
        //������ �����
        FileStream fs = new FileStream(filePath + fileName, FileMode.Create);

        foreach (ScriptableObject saveDate in listGmObj)
        {
            //��������� ������ � string �������������� Json
            string jsonData = JsonUtility.ToJson(saveDate, true);

            //����������� � ���������
            bf.Serialize(fs, jsonData);
        }

        //��������� �����
        fs.Close();
    }

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
