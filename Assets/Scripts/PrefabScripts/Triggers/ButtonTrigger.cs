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
        eventScript = eventObject.GetComponent(typeof(EventInterface)) as EventInterface;
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
        if (other.gameObject.tag == "Player")
        {
            isTriggered = true;
            eventScript.executeEvent(); // <-- Method needs to be added in the interface
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTriggered = false;
            eventScript.endExecution(); // <-- Method needs to be added in the interface
        }
    }

    void MoveButton(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

}
