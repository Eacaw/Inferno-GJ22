using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class BoxHoleTrigger : MonoBehaviour, TriggerInterface
{
    public GameObject eventObject;
    private EventInterface eventScript;

    public GameObject indicatorLight;

    public bool isTriggered;
    void Start()
    {
        setupEventObject();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MovableTrigger")
        {
            indicatorLight.GetComponent<Light>().color = Color.green;
            this.isTriggered = true;
            if (this.eventObject)
            {

                eventScript.executeEvent();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MovableTrigger")
        {
            Debug.Log("Box has entered the Hole");
            FindObjectOfType<SoundManager>().Play("BoxSuccess");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MovableTrigger")
        {
            indicatorLight.GetComponent<Light>().color = Color.red;
            this.isTriggered = false;
            if (this.eventObject)
            {

                eventScript.endExecution();
            }
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
