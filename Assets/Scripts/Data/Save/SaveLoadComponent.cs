using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Родительсткий класс компонента, данные которого мы будем сохранять
/// </summary>
public abstract class SaveLoadComponent : MonoBehaviour
{
    //Список всех компонентов сцены, данные с которых мы будем сохранять (пока отправлять во временное хранилеще данных)
    protected static Dictionary<GameObject, List<SaveLoadComponent>> dictionaryComponentGmObj = new Dictionary<GameObject, List<SaveLoadComponent>>();
    //Список временных хранилищь данных для каждого объекта, данные с которого будут сохранятся
    protected static Dictionary<GameObject, StoringLocalData> listStoringLocal = new Dictionary<GameObject, StoringLocalData>();

    public static Dictionary<GameObject, StoringLocalData> ListStoringLocal { get => listStoringLocal; set => listStoringLocal = value; }
    public static Dictionary<GameObject, List<SaveLoadComponent>> DictionaryComponentGmObj { get => dictionaryComponentGmObj; set => dictionaryComponentGmObj = value; }

    /// <summary>
    /// Сохраняем данные отдельного компонента
    /// </summary>
    public abstract void Save();

    public abstract void Load();

    /// <summary>
    /// Удаляем компонент removeComponent относящийся к GmObj из списка сохраняемых/загружаемых
    /// </summary>
    public static void Remove(GameObject GmObj, SaveLoadComponent removeComponent)
    {
        dictionaryComponentGmObj[GmObj].Remove(removeComponent);
    }

    /// <summary>
    /// Сохранение данные всех компонентов которые находятся в списке listComponent
    /// </summary>
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
