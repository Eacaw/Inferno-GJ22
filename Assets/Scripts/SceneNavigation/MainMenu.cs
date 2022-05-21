using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void loadDevPlaygroundScene()
    {
        SceneManager.LoadScene("DevPlayground");
    }

    public void loadLevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void loadGuide()
    {
        SceneManager.LoadScene("Guide");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
