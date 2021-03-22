using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField]
    Button mainMenuButton;

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
        SceneManager.LoadScene("MainMenu");
    }

    void Save()
    {
        string fileName = "/save" + 1 + ".gamesave";
        SaveLoadScene.SaveGame(fileName);
    }

    void Load()
    {
        string fileName = "/save" + 1 + ".gamesave";
        PlayerPrefs.SetString("Load", fileName);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
