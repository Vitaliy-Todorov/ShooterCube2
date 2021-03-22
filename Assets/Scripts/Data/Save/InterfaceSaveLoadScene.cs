using UnityEngine;

/// <summary>
/// ��������� ������ �� ����� ��� �������� �����
/// � ��� �� ��������� ���������� ��������� � ���������.
/// </summary>
public class InterfaceSaveLoadScene : SaveLoadScene
{
    void Start()
    {
        //�� ���� ���� ����������!!
        //���� ����������� ����� �. �.
        //get_persistentDataPath �� ����� ���� ������ �� ������������ MonoBehaviour (��� �������������� ���� ����������) 
        //���� ���������� ����������� � ������������ � SaveLoadStorage
        filePath = Application.persistentDataPath;

        //���� � ������ ���� ���-�� ��������� � ������ "Load", ������ ��� �������� ����� ��������� ��������, ���������� � ������ �����
        string fileName = PlayerPrefs.GetString("Load");
        if (fileName != "")
        {
            LoadGame(fileName);
            SaveLoadComponent.LoadAll();
            PlayerPrefs.DeleteKey("Load");
            //��������� ����� ����� �������� �� �������� ����
            Time.timeScale = 1;
        }

        // �������� ��� SaveLoadScene ������ ���� ����������� ��������� ��������� �� SaveLoadComponent (SaveLoadLink)
        ListStoringLocal = InterfaceStoringLocaAndComponent.ListAllStoringLocal;

        // �������� ��� StoringLocalData ������ ���� ����������� ��������� ��������� �� SaveLoadComponent (SaveLoadLink)
        StoringLocalData.ListAllStoringLocal = InterfaceStoringLocaAndComponent.ListAllStoringLocal;
    }


}
