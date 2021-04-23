using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadScene : SaveLoadComponentAndLocalStorage
{
    static List<string> listSaveName = new List<string>();
    static string _filePath = "";

    void Start()
    {
        _filePath = Application.dataPath;

        //���� � ������ ���� ���-�� ��������� � ������ "Load", ������ ��� �������� ����� ��������� ��������, ���������� � ������ �����
        string fileName = PlayerPrefs.GetString("Load");
        if (fileName != "")
        {
            LoadGame(fileName);
        }
    }

    private void OnDestroy()
    {
        //������� ����������� ����
        listComponents.Clear();
        dictionaryComponentAndLocalStorage.Clear();
    }

    /// <summary>
    /// ��������� ���������� �� ���� �������� �����
    /// </summary>
    public static void SaveGame(string fileName)
    {
        SaveLoadToFile saveLoad = new SaveLoadToFile(_filePath);

        //��������� �������� �����
        if(!listSaveName.Contains(fileName))
            listSaveName.Add(fileName);

        //��������� ������ �������� ������
        saveLoad.Save(listSaveName, "/listSaveName");

        //��������� �������� ����� (������ �������� ���������� � �������� �����)
        string sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString(fileName, sceneName);

        //�������� ����������� ���������� � LocalStorage. �������� ��� LocalStorage � ������� � ��������� �������
        SaveAllComponent();
        saveLoad.Save(dictionaryComponentAndLocalStorage, fileName);
    }

    /// <summary>
    /// ��������� ���������� ��� ���� �������� �����
    /// </summary>
    public static void LoadGame(string fileName)
    {
        SaveLoadToFile saveLoad = new SaveLoadToFile(_filePath);

        PlayerPrefs.DeleteKey("Load");
        //Load(listSaveName, "/listSaveName");
        dictionaryComponentAndLocalStorage = saveLoad.Load<Dictionary<string, LocalStorage>>(fileName);

        LoadAllComponent();
    }

    public static void LoadGameInManu(string fileName)
    {
        //������� ��� ����� ����������� �������� ����� ����� ������� ����� � ������� ����� ���� ���������: fileName
        PlayerPrefs.SetString("Load", fileName);

        //�������� �������� ����� � ������� ��� ������� fileName
        string sceneName = PlayerPrefs.GetString(fileName);
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// �������� ����������� ���������� � LocalStorage ��� ��� Component. 
    /// �������� ��� LocalStorage � ������� dictionaryComponentAndLocalStorage
    /// </summary>
    public static void SaveAllComponent()
    {
        foreach (SaveLoadComponent component in listComponents)
            component.Save();
    }

    /// <summary>
    /// ��������� LocalStorage �� dictionaryComponentAndLocalStorage ��� ���� Component.
    /// </summary>
    public static void LoadAllComponent()
    {
        foreach (SaveLoadComponent component in listComponents)
            component.Load();
    }
}
