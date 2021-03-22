using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Родительсткий класс компонента, данные которого мы будем сохранять
/// </summary>
public abstract class SaveLoadComponent : MonoBehaviour
{
    //Список всех компонентов сцены, данные с которых мы будут сохранять
    //Нужен для сохранения всех данных в SaveAll
    protected static Dictionary<GameObject, List<SaveLoadComponent>> dictionaryComponentGmObj = new Dictionary<GameObject, List<SaveLoadComponent>>();
    //Список временных хранилищь данных для каждого объекта, данные с которого будут сохранятся в постоянную память (соответственно через класс SaveLoadLink передаётся в SaveLoadScene)
    protected static Dictionary<GameObject, StoringLocalData> listStoringLocal = new Dictionary<GameObject, StoringLocalData>();

    public static Dictionary<GameObject, StoringLocalData> ListStoringLocal { get => listStoringLocal; set => listStoringLocal = value; }
    public static Dictionary<GameObject, List<SaveLoadComponent>> DictionaryComponentGmObj { get => dictionaryComponentGmObj; set => dictionaryComponentGmObj = value; }

    [SerializeField]
    protected bool save;
    protected StoringLocalData storingLocal;

    [SerializeField]
    protected bool saveInRootGmObj;
    protected StoringLocalData storingLocalRootGmObj;

    /// <summary>
    /// Связываем временное хранилище и объект. 
    /// Либо в хранилище прекреплё к родительсткому объекту (указывается в SaveLoadLink)
    /// Либо прикрепляем SaveLoadLink на текущий объект, указываем в нём хранилище и сохраняем туда
    /// </summary>
    protected void AddInSaveList()
    {
        if (save)
        {
            if (!saveInRootGmObj)
            {
                AddInSaveListThisGmObj();
            } else
            {
                AddInSaveListRootGmObj();
            }
        }

    }

    protected void AddInSaveListThisGmObj()
    {
        dictionaryComponentGmObj[gameObject].Add(this);
        storingLocal = listStoringLocal[gameObject];
    }

    protected void AddInSaveListRootGmObj()
    {
        dictionaryComponentGmObj[transform.root.gameObject].Add(this);
        storingLocal = listStoringLocal[transform.root.gameObject];
    }

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
            //Если объект был унечтожен, не сохраняем данные с него (сохранение об его уничтожение происходит в методе DeathRoot())
            if (!(saveKeyValue.Key).Equals(null))
            {
                foreach (SaveLoadComponent save in saveKeyValue.Value)
                    save.Save();
            }
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
