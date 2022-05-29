using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject guideScreenUI;
    public GameObject controlsScreenUI;
    public GameObject levelSelectUI;
    public GameObject mainMenuScreenUI;

    public void loadDevPlaygroundScene()
    {
        SceneManager.LoadScene("DevPlayground");
    }

    public void loadLevelOne()
    {
        SceneManager.LoadScene("Level1");
    }

    public void levelSelect()
    {
        mainMenuScreenUI.SetActive(false);
        levelSelectUI.SetActive(true);
    }

    public void loadGuide()
    {
        mainMenuScreenUI.SetActive(false);
        guideScreenUI.SetActive(true);
    }

    public void loadControls()
    {
        mainMenuScreenUI.SetActive(false);
        guideScreenUI.SetActive(false);
        controlsScreenUI.SetActive(true);
    }

    public void backToMainMenu()
    {
        mainMenuScreenUI.SetActive(true);
        guideScreenUI.SetActive(false);
        controlsScreenUI.SetActive(false);
        levelSelectUI.SetActive(false);
    }

    public void backToGuide()
    {
        guideScreenUI.SetActive(true);
        controlsScreenUI.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
