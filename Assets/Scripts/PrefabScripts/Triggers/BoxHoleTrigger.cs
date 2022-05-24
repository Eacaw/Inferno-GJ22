using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class BoxHoleTrigger : MonoBehaviour, TriggerInterface
{
    public GameObject eventObject;
    private EventInterface eventScript;
    void Start()
    {
        setupEventObject();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MovableTrigger")
        {
            eventScript.executeEvent();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MovableTrigger")
        {
            eventScript.endExecution();
        }
    }

    public void setupEventObject()

    {
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
