using System.Collections.Generic;
using UnityEngine;

public class InterfaceStoringLocalEachObject : InterfaceStoringLocalShared
{
    [SerializeField]
    StoringLocalData storingLocalForGmObj;

    private void Awake()
    {
        //��������� ���������� ������ � ��������� ���������� ��� ������
        SaveLoadComponent.ListStoringLocal[gameObject] = storingLocalForGmObj;

        //������ ������ ��� ��������� ������� ������ � �� ����������, ���������� � ������� ��������� (���������� � ������ ����������� � AddInSaveList)
        SaveLoadComponent.AddListComponents(gameObject);

        listAllStoringLocal.Add(storingLocalForGmObj);
    }

    private void OnDestroy()
    {
        SaveLoadComponent.Remove(gameObject);
    }
}
