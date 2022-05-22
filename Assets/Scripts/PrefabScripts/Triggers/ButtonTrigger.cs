using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{

    private bool isTriggered = false;
    private Vector3 startPosition;
    private Vector3 endPosition;

    public GameObject eventObject;
    private DoorScript doorScript;

    void Start()
    {
        startPosition = transform.position;
        endPosition = transform.position + new Vector3(0, -0.15f, 0);

        // Need to consider how we want to do this, we don't want to only check for
        // door scripts. Open to suggestions. 
        doorScript = eventObject.GetComponent<DoorScript>();
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
            doorScript.executeEvent(); // <-- Method needs to be added in the interface
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTriggered = false;
            doorScript.endExecution(); // <-- Method needs to be added in the interface
        }
    }

    void MoveButton(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}
