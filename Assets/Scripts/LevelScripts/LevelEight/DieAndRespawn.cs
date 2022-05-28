using UnityEngine;
using UnityEngine.SceneManagement;

public class DieAndRespawn : MonoBehaviour
{
    public PlayerMovement playerInstance;
    public int respawnOffset = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInstance.setRespawn(0, respawnOffset, 0);
            playerInstance.dieAndRespawn(1);
        }
    }
}