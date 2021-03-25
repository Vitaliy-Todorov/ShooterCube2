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
            LoadGame("/save" + 1 + ".gamesave");
        });

        settingsButton.onClick.AddListener(delegate {
            SettingsPressed(settingsMenuObj);
            });

        exitButton.onClick.AddListener(ExitPressed);
    }

    void PlayPressed()
    {
        SceneManager.LoadScene("Level_0");
    }

    void LoadGame(string fileName)
    {
        PlayerPrefs.SetString("Load", fileName);
        SaveLoadScene.LoadGameInManu(fileName);
    }

    void SettingsPressed(GameObject obj)
    {
        gameObject.SetActive(false);
        obj.SetActive(true);
    }

    void ExitPressed()
    {
        Application.Quit();
    }
}
