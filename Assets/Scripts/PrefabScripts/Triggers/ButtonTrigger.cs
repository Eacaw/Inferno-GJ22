using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class ButtonTrigger : MonoBehaviour, TriggerInterface
{

    private bool isTriggered = false;
    private Vector3 startPosition;
    private Vector3 endPosition;

    // public GameObject gameObject;

    public GameObject eventObject;
    private EventInterface eventScript;

    void Start()
    {
        // Store the limits to the button's movement
        startPosition = transform.position;
        endPosition = transform.position + new Vector3(0, -0.15f, 0);
        // Fetch the correct event script
        setupEventObject();
    }

    void Update()
    {
        if (isTriggered)
        {
            MoveButton(endPosition);
        }
        else
        {
            MoveButton(startPosition);
        }
    }

    // Handle Triggers
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Corpse")
        {
            isTriggered = true;
            if (this.eventObject)
            {
                eventScript.executeEvent();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {

        isTriggered = false;
        if (this.eventObject)
        {
            eventScript.endExecution();
        }

    }

    void MoveButton(Vector3 newPosition)
    {
        transform.position = newPosition;
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
            Debug.Log("Error: " + e);
        }
    }

}
