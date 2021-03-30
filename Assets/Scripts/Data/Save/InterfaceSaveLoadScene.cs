using UnityEngine;
using System.Linq;

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
        filePath = Application.dataPath;

        //���� � ������ ���� ���-�� ��������� � ������ "Load", ������ ��� �������� ����� ��������� ��������, ���������� � ������ �����
        string fileName = PlayerPrefs.GetString("Load");
        if (fileName != "")
        {
            LoadGame(fileName);
        }

        // �������� ��� SaveLoadScene ������ ���� ����������� ��������� ��������� �� SaveLoadComponent (SaveLoadLink)
        ListAllStoringLocal = InterfaceStoringLocalShared.ListAllStoringLocal;
        _ = ListAllStoringLocal;

        // �������� ��� StoringLocalData ������ ���� ����������� ��������� ��������� �� SaveLoadComponent (SaveLoadLink)
        StoringLocalData.ListAllStoringLocal = InterfaceStoringLocalShared.ListAllStoringLocal;

        //������������� �� �����. �� ������ ��� ���� ���� ������� � InterfaceStoringLocalShared.
        
        InterfaceStoringLocalShared.ListAllStoringLocal = InterfaceStoringLocalShared.ListAllStoringLocal
            .OrderBy(storingLocal => storingLocal.name).ToList();
    }

    private void OnDestroy()
    {
        //������� ������ ����������� ��������� (������ ����� ��� ��� ���������� SaveLoadComponent �� ��������� )
        SaveLoadComponent.DictionaryComponentGmObj.Clear();
    }
}
