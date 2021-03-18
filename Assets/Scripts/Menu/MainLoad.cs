using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Загружаем данные из файла при переходе с главного экрана
public class MainLoad : SaveLoadScene
{
    [SerializeField]
    List<ScriptableObject> listGmObj_;

    void Start()
    {
        filePath = Application.persistentDataPath;
        string fileName = PlayerPrefs.GetString("MainLoad");
        listGmObj = listGmObj_;
        if (fileName != "")
        {
            LoadGame(fileName);
            PlayerPrefs.DeleteKey("MainLoad");
        }
    }
}
