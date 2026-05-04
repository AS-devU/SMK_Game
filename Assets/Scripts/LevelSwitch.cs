using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    void Start()
    {
        nextLevelButton.onClick.AddListener(OnNextLevelPress);
        quitButton.onClick.AddListener(OnQuitPress);
    }
    public Button nextLevelButton, quitButton;

    void OnNextLevelPress()
    {
        Debug.Log("Next level button pressed!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void OnQuitPress()
    {
        Debug.Log("Quit button pressed!");
        Application.Quit();
    }
}
