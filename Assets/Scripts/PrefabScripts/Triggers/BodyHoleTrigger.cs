using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class BodyHoleTrigger : MonoBehaviour, TriggerInterface
{
    public GameObject eventObject;
    private EventInterface eventScript;
    public GameObject indicatorLight;

    public bool isTriggered = false;
    void Start()
    {
        setupEventObject();
    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Corpse")
        {
            indicatorLight.GetComponent<Light>().color = Color.green;
            if (this.eventObject)
            {
                eventScript.executeEvent();
            }
            this.isTriggered = true;
        }

    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Corpse")
        {
            indicatorLight.GetComponent<Light>().color = Color.red;
            if (this.eventObject)
            {
                eventScript.endExecution();
            }
            this.isTriggered = false;
        }

    }

    public bool getIsTriggered()
    {
        return this.isTriggered;
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
