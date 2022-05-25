using UnityEngine;
using Interfaces;

public class LaserScript : MonoBehaviour, EventInterface
{

    public GameObject playerInstance;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = playerInstance.GetComponent<PlayerMovement>();
    }
    public void executeEvent()
    {
        gameObject.SetActive(false);
    }

    public void endExecution()
    {
        gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerMovement.dieAndRespawn(1);
        }
        else if (
            other.gameObject.tag == "Corpse")
        {
            Destroy(other.gameObject);
        }
    }
}
