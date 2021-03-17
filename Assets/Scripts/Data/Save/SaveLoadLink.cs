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
        SaveLoadComponent.ListStoringLocal = new Dictionary<GameObject, StoringLocalData>();
        SaveLoadComponent.ListStoringLocal[gameObject] = storingLocal;

        SaveLoadComponent.DictionaryComponentGmObj = new Dictionary<GameObject, List<SaveLoadComponent>>
            { [gameObject] = new List<SaveLoadComponent>() };
    }
}
