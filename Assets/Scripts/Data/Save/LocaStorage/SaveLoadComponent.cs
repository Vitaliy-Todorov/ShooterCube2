using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Родительсткий класс компонента, данные которого мы будем сохранять
/// </summary>
public abstract class SaveLoadComponent : MonoBehaviour
{
    //Список всех компонентов сцены, данные с которых мы будут сохранять
    //Нужен для сохранения всех данных в SaveAll (меняем при сохранении, удаляем из него компоненты уничтоженного объекта)
    protected static Dictionary<GameObject, List<SaveLoadComponent>> saveDictionaryComponentGmObj = new Dictionary<GameObject, List<SaveLoadComponent>>();
    //Нужен для сохранения всех данных в LoadAll (не меняется при загрузке)
    protected static Dictionary<GameObject, List<SaveLoadComponent>> loadDictionaryComponentGmObj = new Dictionary<GameObject, List<SaveLoadComponent>>();

    //Список временных хранилищь данных для каждого объекта, данные с которого будут сохранятся в постоянную память (испоьзуется в
    //AddInSaveListThisGmObj через него связывается каждый отдельный компонент с хранилищем)
    protected static Dictionary<GameObject, StoringLocalData> dictionaryGmOdjAndStoringLocal = new Dictionary<GameObject, StoringLocalData>();
    public static Dictionary<GameObject, StoringLocalData> DictionaryGmOdjAndStoringLocal { get => dictionaryGmOdjAndStoringLocal; set => dictionaryGmOdjAndStoringLocal = value; }

    protected StoringLocalData storingLocal;
    [SerializeField]
    protected bool save;
    [SerializeField]
    protected bool saveInRootGmObj;

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
        saveDictionaryComponentGmObj[gameObject].Add(this);
        loadDictionaryComponentGmObj[gameObject].Add(this);
        storingLocal = dictionaryGmOdjAndStoringLocal[gameObject];
    }

    protected void AddInSaveListRootGmObj()
    {
        saveDictionaryComponentGmObj[transform.root.gameObject].Add(this);
        loadDictionaryComponentGmObj[transform.root.gameObject].Add(this);
        storingLocal = dictionaryGmOdjAndStoringLocal[transform.root.gameObject];
    }

    /// <summary>
    /// Сохраняем данные отдельного компонента
    /// </summary>
    public abstract void Save();

    public abstract void Load();

    /// <summary>
    /// Создаём список для связываем игровой объект и те компаненты, информацию с которых сохраняем (компоненты в список добовляются в AddInSaveList)
    /// </summary>
    public static void AddListComponents(GameObject GmObj)
    {
        saveDictionaryComponentGmObj[GmObj] = new List<SaveLoadComponent>();
        loadDictionaryComponentGmObj[GmObj] = new List<SaveLoadComponent>();
    }

    /// <summary>
    /// Удаляем компонент removeComponent относящийся к GmObj из списка сохраняемых/загружаемых
    /// </summary>
    public static void Remove(GameObject GmObj)
    {
        dictionaryGmOdjAndStoringLocal.Remove(GmObj);
        saveDictionaryComponentGmObj.Remove(GmObj);
    }

    public static void Clear()
    {
        dictionaryGmOdjAndStoringLocal.Clear();
        saveDictionaryComponentGmObj.Clear();
        loadDictionaryComponentGmObj.Clear();
    }

    /// <summary>
    /// Сохранение данные всех компонентов которые находятся в списке listComponent
    /// </summary>
    public static void SaveAll()
    {
        foreach (KeyValuePair<GameObject, List<SaveLoadComponent>> saveKeyValue in loadDictionaryComponentGmObj)
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
        foreach (KeyValuePair<GameObject, List<SaveLoadComponent>> loadKeyValue in loadDictionaryComponentGmObj)
        {
            foreach (SaveLoadComponent save in loadKeyValue.Value) {
                save.Load(); }
        }
    }
}
