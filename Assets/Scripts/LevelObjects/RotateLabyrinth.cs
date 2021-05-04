using System.Collections.Generic;
using UnityEngine;

public class RotateLabyrinth : SaveLoadComponent
{
    [SerializeField]
    GameObject rotatable;
    [SerializeField]
    List<GameObject> noRotatables;
    Dictionary<GameObject, GameObject> noRotatablesSaveCoordinates = new Dictionary<GameObject, GameObject>();

    [SerializeField]
    List<GameObject> noActiveObjects;
    [SerializeField]
    List<GameObject> activeObjects;

    [SerializeField]
    Vector3 eulers;

    [SerializeField]
    bool save = true;

    private void Awake()
    {
        if (save)
            SaveLoadComponentAndLocalStorage.listComponents.Add(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Создаём болванку которую будем поворачивать и на чьё место будем телепортировать неповарачиваемый объект
        GameObject gmObj;
        foreach (GameObject noRotatable in noRotatables)
        {
            gmObj = new GameObject();
            gmObj.transform.position = noRotatable.transform.position;
            gmObj.transform.parent = rotatable.transform;
            noRotatablesSaveCoordinates.Add(noRotatable, gmObj);
        }

        //поворачиваем всё что нужно повернуть
        rotatable.transform.Rotate(eulers, Space.Self);

        //помещаем на место балванки которая повенулоась вместе со всем объектом, объект что не нужно ыбло поворачивать
        foreach (KeyValuePair<GameObject, GameObject> noRotatable in noRotatablesSaveCoordinates)
        {
            Motion motion = noRotatable.Key.transform.root.gameObject.GetComponent<Motion>();
            motion.Teleportation(noRotatable.Value.transform.position);
        }
        noRotatablesSaveCoordinates.Clear();

        //выключаем то что должно стать невидимым
        foreach (GameObject noActiveObject in noActiveObjects)
            noActiveObject.SetActive(false);
        //включаем то что должно стать видимым
        foreach (GameObject activeObject in activeObjects)
            activeObject.SetActive(true);
    }

    public override void Save()
    {
        SaveLoadComponentAndLocalStorage.Set(this, rotatable + "normal", new LocalStorage(rotatable.transform.eulerAngles));

        foreach (GameObject active in noActiveObjects)
            SaveLoadComponentAndLocalStorage.Set(this, active + "active", new LocalStorage(active.activeInHierarchy));
        foreach (GameObject active in activeObjects)
            SaveLoadComponentAndLocalStorage.Set(this, active + "active", new LocalStorage(active.activeInHierarchy));
    }

    public override void Load()
    {
        rotatable.transform.eulerAngles = SaveLoadComponentAndLocalStorage.Get(this, rotatable + "normal").Vector3ToStorage;

        bool hidden;
        foreach (GameObject active in noActiveObjects)
        {
            hidden = SaveLoadComponentAndLocalStorage.Get(this, active + "active").Bool;
            active.SetActive(hidden);
        }
        foreach (GameObject active in activeObjects)
        {
            hidden = SaveLoadComponentAndLocalStorage.Get(this, active + "active").Bool;
            active.SetActive(hidden);
        }
    }
}
