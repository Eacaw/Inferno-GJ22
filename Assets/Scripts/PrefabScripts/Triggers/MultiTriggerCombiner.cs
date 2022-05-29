using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class MultiTriggerCombiner : MonoBehaviour, TriggerInterface
{
    public GameObject eventObject;
    private EventInterface eventScript;

    public GameObject[] triggers;

    private bool hasFired = false;

    void Start()
    {
        setupEventObject();

    }

    void FixedUpdate()
    {
        int numTriggered = 0;

        for (int i = 0; i < triggers.Length; i++)
        {
            TriggerInterface triggerScript = triggers[i].GetComponent(typeof(TriggerInterface)) as TriggerInterface;
            if (triggerScript.getIsTriggered())
            {
                numTriggered++;
            }
        }

        if (numTriggered == triggers.Length)
        {
            eventScript.executeEvent();
            hasFired = true;
        }

        if (hasFired && numTriggered < triggers.Length)
        {
            eventScript.endExecution();
            hasFired = false;
        }

    }

    public bool getIsTriggered() { return false; }

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
