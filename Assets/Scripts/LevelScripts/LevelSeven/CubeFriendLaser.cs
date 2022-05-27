using UnityEngine;
using Interfaces;

public class CubeFriendLaser : MonoBehaviour, TriggerInterface
{

    public GameObject eventObject;
    private EventInterface eventScript;
    public bool isTriggered; // <- must track current state
    public GameObject playerInstance;
    private PlayerMovement playerMovement;

    void Start()
    {
        setupEventObject();
        playerMovement = playerInstance.GetComponent<PlayerMovement>();
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

        else if (other.gameObject.tag == "CubeFriend")
        {
            eventScript.executeEvent();
            Destroy(other.gameObject);
        }
    }

    public bool getIsTriggered()
    {
        return this.isTriggered;
    }
    public void setupEventObject()
    {
        // Fetch the correct event script
        try
        {
            eventScript = eventObject.GetComponent(typeof(EventInterface)) as EventInterface;
        }
        catch (System.Exception e)
        {
            Debug.Log("You haven't connected a gameobject to this trigger" + e);
        }
    }


}
