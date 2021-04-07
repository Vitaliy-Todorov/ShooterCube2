using System.Collections.Generic;
using UnityEngine;

public class InterfaceStoringLocalEachObject : InterfaceStoringLocalShared
{
    [SerializeField]
    StoringLocalData storingLocalForGmObj;

    private void Awake()
    {
        //��������� ���������� ������ � ��������� ���������� ��� ������
        SaveLoadComponent.DictionaryGmOdjAndStoringLocal[gameObject] = storingLocalForGmObj;

        //������ ������ ��� ��������� ������� ������ � �� ����������, ���������� � ������� ��������� (���������� � ������ ����������� � AddInSaveList)
        SaveLoadComponent.AddListComponents(gameObject);

        listAllStoringLocal.Add(storingLocalForGmObj);
    }

    private void OnDestroy()
    {
        SaveLoadComponent.Remove(gameObject);
    }
}
