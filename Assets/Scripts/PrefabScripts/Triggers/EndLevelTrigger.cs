using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Time.timeScale = 0f;
            Scene scene = SceneManager.GetActiveScene();

            if (scene.name != "Level8")
            {
                gameManager.CompleteLevel();
            }
            else
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("EndGame");
            }
        }
    }
}
