using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnTrigger : MonoBehaviour
{
    public PlayerMovement playerInstance;
    public int respawnOffset = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInstance.setRespawn(respawnOffset);
        }
    }
}
