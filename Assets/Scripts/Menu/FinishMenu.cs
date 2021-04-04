using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
    [SerializeField]
    Button mainMenuButton;

    [SerializeField]
    Button loadButton;

    [SerializeField]
    Button exitButton;

    private void Start()
    {
        mainMenuButton.onClick.AddListener(MainMenu);

        loadButton.onClick.AddListener(Load);

        exitButton.onClick.AddListener(ExitPressed);
    }

    void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        //Запускаем время после загрузки
        Time.timeScale = 1;
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
