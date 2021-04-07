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

        //���������� �������� ������ ������� � InterfaceStoringLocalShared, ��� ��� ��� �������� listAllStoringLocal 
        //����� InterfaceStoringLocalEachObject �� ��������� � ������ listAllStoringLocal ��� �� ��������

        // �������� ��� SaveLoadScene ������ ���� ����������� ��������� ��������� �� SaveLoadComponent (SaveLoadLink)
        ListAllStoringLocal = InterfaceStoringLocalShared.ListAllStoringLocal;

        // �������� ��� StoringLocalData ������ ���� ����������� ��������� ��������� �� SaveLoadComponent (SaveLoadLink)
        StoringLocalData.ListAllStoringLocal = InterfaceStoringLocalShared.ListAllStoringLocal;

        //���� � ������ ���� ���-�� ��������� � ������ "Load", ������ ��� �������� ����� ��������� ��������, ���������� � ������ �����
        string fileName = PlayerPrefs.GetString("Load");
        if (fileName != "")
        {
            LoadGame(fileName);
        }
    }
}
