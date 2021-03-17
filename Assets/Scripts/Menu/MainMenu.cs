using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Button playButton;

    [SerializeField]
    Button loadButton;

    [SerializeField]
    Button settingsButton;

    [SerializeField]
    GameObject settingsMenuObj;

    [SerializeField]
    Button exitButton;

    void Start()
    {
        playButton.onClick.AddListener(PlayPressed);

        loadButton.onClick.AddListener(delegate
        {
            LoadGame(Application.persistentDataPath + "/save.gamesave");
        });

        settingsButton.onClick.AddListener(delegate {
            SettingsPressed(settingsMenuObj);
            });

        exitButton.onClick.AddListener(ExitPressed);
    }

    void PlayPressed()
    {
        SceneManager.LoadScene("Level_1");
    }

    void LoadGame(string loatFile)
    {
        PlayerPrefs.SetString("MainLoad", loatFile);
        SceneManager.LoadScene("Level_1");
    }

    void SettingsPressed(GameObject obj)
    {
        this.gameObject.SetActive(false);
        obj.SetActive(true);
    }

    void ExitPressed()
    {
        Application.Quit();
    }
}
