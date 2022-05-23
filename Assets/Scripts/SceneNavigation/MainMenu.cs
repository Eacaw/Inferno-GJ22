using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject guideScreenUI;
    public GameObject controlsScreenUI;

    public void loadDevPlaygroundScene()
    {
        SceneManager.LoadScene("DevPlayground");
    }

    public void loadLevelOne()
    {
        SceneManager.LoadScene("Level1");
    }

    public void loadGuide()
    {
        guideScreenUI.SetActive(true);
    }

    public void loadControls()
    {
        controlsScreenUI.SetActive(true);
    }

    public void backToMainMenu()
    {
        guideScreenUI.SetActive(false);
        controlsScreenUI.SetActive(false);
    }

    public void backToGuide()
    {
        controlsScreenUI.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
