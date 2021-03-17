using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Нужен для назначения оперделённому объекту временного хранилища. Так как в абстрактом классе SaveLoadCube data это статическое поле, что бы изменить его значение в редакторе для конкретного объекта ис пользуем данный класс
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
