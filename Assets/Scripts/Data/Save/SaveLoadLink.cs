using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����� ��� ���������� ������������ ������� ���������� ���������. ��� ��� � ���������� ������ SaveLoadCube data ��� ����������� ����, ��� �� �������� ��� �������� � ��������� ��� ����������� ������� �� �������� ������ �����
public class SaveLoadLink : MonoBehaviour
{
    [SerializeField]
    StoringLocalData storingLocal;

    private void Awake()
    {
        SaveLoadComponent.ListStoringLocal[gameObject] = storingLocal;

        SaveLoadComponent.DictionaryComponentGmObj[gameObject] = new List<SaveLoadComponent>();
    }
}
