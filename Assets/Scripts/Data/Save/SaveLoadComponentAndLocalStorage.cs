using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������� � ������ �����������/����������� ��������� � �������� ��������������� ���� �����������
/// </summary>
public class SaveLoadComponentAndLocalStorage : MonoBehaviour
{
    [SerializeField]
    protected static Dictionary<string, LocalStorage> dictionaryComponentAndLocalStorage = new Dictionary<string, LocalStorage>();
    [SerializeField]
    public static List<SaveLoadComponent> listComponents = new List<SaveLoadComponent>();

    /// <summary>
    /// ��������� ���������� � ������ �����������/����������. ��������� ��������� � ������� �����������/����������
    /// </summary>
    /// <param name="key">����� �� �������� �������������� ����������</param>
    public static void Set(SaveLoadComponent component, string key, LocalStorage localStorage)
    {
        //���� ���������� ��� ����� �����������, ��������� �
        if (!listComponents.Contains(component))
            listComponents.Add(component);

        //��������� ������� ������ � ���� �������� ���� � ����������, ���� �������������� �������� �� �����
        key = component + key;
        if (dictionaryComponentAndLocalStorage.ContainsKey(key))
            dictionaryComponentAndLocalStorage[key] = localStorage;
        else
            dictionaryComponentAndLocalStorage.Add(key, localStorage);
    }

    /// <summary>
    /// �������� ��������� �� ������� �����������/����������
    /// </summary>
    /// <param name="key">����� �� �������� �������������� ����������</param>
    public static LocalStorage Get(SaveLoadComponent component, string key)
    {
        return dictionaryComponentAndLocalStorage[component + key];
    }

    /// <summary>
    /// ������� ��������� �� �����������
    /// </summary>
    public static void RemoveDictionary(SaveLoadComponent component, string key)
    {
        listComponents.Remove(component);
        dictionaryComponentAndLocalStorage.Remove(component + key);
    }
}
