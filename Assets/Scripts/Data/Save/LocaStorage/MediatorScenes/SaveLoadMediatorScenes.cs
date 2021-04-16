using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadMediatorScenes : SaveLoadAllComponent
{
    static List<string> listSaveName = new List<string>();
    static string _filePath = "";

    void Start()
    {
        //�� ���� ���� ����������!!
        //���� ����������� ����� �. �.
        //get_persistentDataPath �� ����� ���� ������ �� ������������ MonoBehaviour (��� �������������� ���� ����������) 
        //���� ���������� ����������� � ������������ � SaveLoadStorage
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
        listComponents.Clear();
    }

    /// <summary>
    /// ��������� ��� ������� �����
    /// </summary>
    public static void SaveGame(string fileName)
    {
        SomeSaveLoadStoring saveLoad = new SomeSaveLoadStoring(_filePath);

        //��������� �������� �����
        if(!listSaveName.Contains(fileName))
            listSaveName.Add(fileName);
        saveLoad.Save(listSaveName, "/listSaveName");

        //��������� �������� ����� (������ �������� ���������� � �������� �����)
        string sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString(fileName, sceneName);

        SaveAllComponent();
        SaveDestroyAll();
        saveLoad.Save(dictionaryMediatorComponentAndValue, fileName);
    }

    /// <summary>
    /// ��������� ��� ������� �����
    /// </summary>
    public static void LoadGame(string fileName)
    {
        SomeSaveLoadStoring saveLoad = new SomeSaveLoadStoring(_filePath);

        PlayerPrefs.DeleteKey("Load");
        //Load(listSaveName, "/listSaveName");
        //dictionaryMediatorComponentAndValue = (Dictionary<string, object>) saveLoad.Load(fileName);

        /*foreach (SaveLoadComponent x in listComponents)
            Debug.Log(x);*/
        LoadAllComponent();
    }

    public static void LoadGameInManu(string fileName)
    {
        //������� InterfaceSaveLoadScene � ��� ��� ����� ����������� �������� ����� ����� ������� ����� � ������� ����� ���� ��������� fileName
        PlayerPrefs.SetString("Load", fileName);

        //�������� �������� ����� � ������� ��� ������� fileName
        string sceneName = PlayerPrefs.GetString(fileName);
        SceneManager.LoadScene(sceneName);
    }
}
