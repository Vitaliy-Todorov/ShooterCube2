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

    [SerializeField]
    Button exitButton;

    private void Start()
    {
        Time.timeScale = 0;

        mainMenuButton.onClick.AddListener(MainMenu);

        saveButton.onClick.AddListener(Save);

        loadButton.onClick.AddListener(Load);

        exitButton.onClick.AddListener(ExitPressed);
    }

    void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        //Запускаем время после загрузки
        Time.timeScale = 1;
    }

    void Save()
    {
        string fileName = "/save" + 1;
        SaveLoadScene.SaveGame(fileName);
    }

    void Load()
    {
        string fileName = "/save" + 1;
        SaveLoadScene.LoadGameInManu(fileName);
        //Запускаем время после загрузки
        Time.timeScale = 1;
    }

    void ExitPressed()
    {
        Application.Quit();
    }
}
