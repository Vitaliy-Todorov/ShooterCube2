using UnityEngine;

public class CallGameMenu : MonoBehaviour
{
    [SerializeField]
    GameObject gameMenu;
    bool ofOn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ofOn = !ofOn;
            gameMenu.gameObject.SetActive(ofOn);
            if (ofOn)
            {
                Time.timeScale = 0;
            } else 
            {
                Time.timeScale = 1;
            }
        }
    }
}
