using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnTrigger : MonoBehaviour
{
    public PlayerMovement playerInstance;
    public int zMultiplier = 0;
    public int yMultiplier = 0;
    public int xMultiplier = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInstance.setRespawn(zMultiplier, yMultiplier, xMultiplier);
        }
    }
}
