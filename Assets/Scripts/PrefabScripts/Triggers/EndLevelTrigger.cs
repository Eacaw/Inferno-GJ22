using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter()
    {
        Time.timeScale = 0f;
        gameManager.CompleteLevel();
    }
}
