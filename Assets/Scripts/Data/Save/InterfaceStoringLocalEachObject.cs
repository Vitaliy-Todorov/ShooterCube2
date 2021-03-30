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

        //��������� ������� ������ � �� ����������, ���������� � ������� ���������
        SaveLoadComponent.DictionaryComponentGmObj[gameObject] = new List<SaveLoadComponent>();

        listAllStoringLocal.Add(storingLocalForGmObj);
    }

    private void OnDestroy()
    {
        SaveLoadComponent.ListStoringLocal.Remove(gameObject);

        SaveLoadComponent.DictionaryComponentGmObj.Remove(gameObject);
    }
}
