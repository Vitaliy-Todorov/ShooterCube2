using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField]
    Button mainMenuButton;

    List<GameObject> listGmObj;

    [SerializeField]
    Button saveButton;

    [SerializeField]
    Button loadButton;

    private void Start()
    {
        mainMenuButton.onClick.AddListener(MainMenu);

        saveButton.onClick.AddListener(Save);

        loadButton.onClick.AddListener(Load);
    }

    void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void Save()
    {
        SaveLoadComponent.SaveAll();
        string fileName = "/save" + 1 + ".gamesave";
        SaveLoadScene.SaveGame(fileName);
    }

    void Load()
    {
        SaveLoadComponent.LoadAll();
        string fileName = "/save" + 1 + ".gamesave";
        SaveLoadScene.LoadGame(fileName);
    }
}
