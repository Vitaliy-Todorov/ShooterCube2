using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Словарь и список сохраняемых/загружаемых компонент и хранилищ соответствующих этим компонентам
/// </summary>
public class SaveLoadComponentAndLocalStorage : MonoBehaviour
{
    protected static Dictionary<string, LocalStorage> dictionaryComponentAndLocalStorage = new Dictionary<string, LocalStorage>();
    public static List<SaveLoadComponent> listComponents = new List<SaveLoadComponent>();

    /// <summary>
    /// Добовляем компоненту в список сохраняемых/загружемых. Добовляем хранилище в словарь сохроняемых/загружемых
    /// </summary>
    /// <param name="key">ключь по которому идентифицируем переменную</param>
    public static void Set(SaveLoadComponent component, string key, LocalStorage localStorage)
    {
        //если компоненты нет среди сохраняемых, добавляем её
        if (!listComponents.Contains(component))
            listComponents.Add(component);

        //Проверяем наличие ключае и либо добаляем ключ с хранилищем, либо перезаписываем значение по ключу
        key = component + key;
        if (dictionaryComponentAndLocalStorage.ContainsKey(key))
            dictionaryComponentAndLocalStorage[key] = localStorage;
        else
            dictionaryComponentAndLocalStorage.Add(key, localStorage);
    }

    /// <summary>
    /// Получаем хранилище из словаря сохроняемых/загружемых
    /// </summary>
    /// <param name="key">ключь по которому идентифицируем переменную</param>
    public static LocalStorage Get(SaveLoadComponent component, string key)
    {
        return dictionaryComponentAndLocalStorage[component + key];
    }

    /// <summary>
    /// Удаляем компонент из сохраняемых
    /// </summary>
    public static void Remove(SaveLoadComponent component)
    {
        listComponents.Remove(component);
    }
}
