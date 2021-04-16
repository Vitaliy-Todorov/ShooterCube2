using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadAllComponent : MonoBehaviour
{
    protected static Dictionary<string, object> dictionaryMediatorComponentAndValue = new Dictionary<string, object>();
    public static List<SaveLoadComponent> listComponents = new List<SaveLoadComponent>();

    private void OnDestroy()
    {
        //dictionaryMediatorComponentAndValue.Clear();
    }

    public static void Set(SaveLoadComponent component, string key, object value)
    {
        if (!listComponents.Contains(component))
            listComponents.Add(component);

        key = component + key;
        if (dictionaryMediatorComponentAndValue.ContainsKey(key))
            dictionaryMediatorComponentAndValue[key] = value;
        else
            dictionaryMediatorComponentAndValue.Add(key, value);
    }

    public static object Get(SaveLoadComponent component, string key)
    {
        return dictionaryMediatorComponentAndValue[component + key];
    }

    public void SetComponent(string component, object value)
    {
        dictionaryMediatorComponentAndValue.Add(component, value);
    }

    public static void SaveAllComponent()
    {
        foreach (SaveLoadComponent component in listComponents)
            component.Save();
    }

    public static void LoadAllComponent()
    {
        foreach (SaveLoadComponent component in listComponents)
            component.Load();
    }

    public static void SaveDestroyAll()
    {

    }
}
