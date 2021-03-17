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

    //Сохраняем, загружаем данные отдельного компонента
    public abstract void Save();

    public abstract void Load();

    //Удаляем компонент из списка загружаемых
    public static void Remove(GameObject GmObj, SaveLoadComponent removeComponent)
    {
        dictionaryComponentGmObj[GmObj].Remove(removeComponent);
    }

    //Сохраняем, загружаем данные всех компонентов которые находятся в списке listComponent
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
