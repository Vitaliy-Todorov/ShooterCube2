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

        // �������� ��� SaveLoadScene ������ ���� ����������� ��������� ��������� �� SaveLoadComponent (SaveLoadLink)
        ListAllStoringLocal = InterfaceStoringLocalShared.ListAllStoringLocal;

        // �������� ��� StoringLocalData ������ ���� ����������� ��������� ��������� �� SaveLoadComponent (SaveLoadLink)
        StoringLocalData.ListAllStoringLocal = InterfaceStoringLocalShared.ListAllStoringLocal;

        //������������� �� �����. �� ������ ��� ���� ���� ������� � InterfaceStoringLocalShared.
        InterfaceStoringLocalShared.ListAllStoringLocal = InterfaceStoringLocalShared.ListAllStoringLocal
            .OrderBy(storingLocal => storingLocal.name).ToList();

        //���� � ������ ���� ���-�� ��������� � ������ "Load", ������ ��� �������� ����� ��������� ��������, ���������� � ������ �����
        string fileName = PlayerPrefs.GetString("Load");
        if (fileName != "")
        {
            LoadGame(fileName);
        }
    }

    private void OnDestroy()
    {
        //������� ������ ����������� ��������� (������ ����� ��� ��� ���������� SaveLoadComponent �� ��������� )
        SaveLoadComponent.DictionaryComponentGmObj.Clear();
    }
}
