using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������������� ����� ����������, ������ �������� �� ����� ���������
/// </summary>
public abstract class SaveLoadComponent : MonoBehaviour
{
    //������ ���� ����������� �����, ������ � ������� �� ����� ��������� (���� ���������� �� ��������� ��������� ������)
    protected static Dictionary<GameObject, List<SaveLoadComponent>> dictionaryComponentGmObj = new Dictionary<GameObject, List<SaveLoadComponent>>();
    //������ ��������� ��������� ������ ��� ������� �������, ������ � �������� ����� ����������
    protected static Dictionary<GameObject, StoringLocalData> listStoringLocal = new Dictionary<GameObject, StoringLocalData>();

    public static Dictionary<GameObject, StoringLocalData> ListStoringLocal { get => listStoringLocal; set => listStoringLocal = value; }
    public static Dictionary<GameObject, List<SaveLoadComponent>> DictionaryComponentGmObj { get => dictionaryComponentGmObj; set => dictionaryComponentGmObj = value; }

    //���������, ��������� ������ ���������� ����������
    public abstract void Save();

    public abstract void Load();

    //������� ��������� �� ������ �����������
    public static void Remove(GameObject GmObj, SaveLoadComponent removeComponent)
    {
        dictionaryComponentGmObj[GmObj].Remove(removeComponent);
    }

    //���������, ��������� ������ ���� ����������� ������� ��������� � ������ listComponent
    public static void SaveAll()
    {
        foreach (KeyValuePair<GameObject, List<SaveLoadComponent>> saveKeyValue in dictionaryComponentGmObj)
        {
            foreach(SaveLoadComponent save in saveKeyValue.Value)
                save.Save();
        }
    }

    public static void LoadAll()
    {
        foreach (KeyValuePair<GameObject, List<SaveLoadComponent>> loadKeyValue in dictionaryComponentGmObj)
        {
            foreach (SaveLoadComponent save in loadKeyValue.Value)
                save.Load();
        }
    }
}
