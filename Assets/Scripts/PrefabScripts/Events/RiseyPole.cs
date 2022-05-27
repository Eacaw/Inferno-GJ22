using UnityEngine;
using Interfaces;

public class RiseyPole : MonoBehaviour, EventInterface, TriggerInterface
{

    private bool isMoving = true;
    private bool canMove = true;
    public GameObject eventObject;
    private EventInterface eventScript;

    void Start()
    {
        setupEventObject();
    }
    public bool getIsTriggered()
    {
        return !isMoving;
    }

    void FixedUpdate()
    {
        // Move platform up and down with a sine wave
        float getSineOffsetToVerticalPosition = Mathf.Sin(Time.time * 1.0f) + 1f;
        if (this.isMoving && canMove)
        {
            transform.position = new Vector3(transform.position.x, getSineOffsetToVerticalPosition * 2.25f + 0.7f, transform.position.z);
        }
    }

    public void executeEvent()
    {
        this.isMoving = false;
        eventScript.executeEvent();
    }

    public void endExecution()
    {
        this.isMoving = true;
        eventScript.endExecution();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canMove = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canMove = true;
        }
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
