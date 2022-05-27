using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class CubeFriendHole : MonoBehaviour, TriggerInterface
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
        if (other.gameObject.tag == "CubeFriend")
        {
            this.isTriggered = true;
            indicatorLight.GetComponent<Light>().color = Color.green;
            eventScript.executeEvent();
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
