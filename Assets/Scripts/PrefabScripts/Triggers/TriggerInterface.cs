using UnityEngine;
namespace Interfaces

{
    public interface TriggerInterface
    {

        // Must contain this public GameObject and private Interface reference:
        // public GameObject eventObject;
        // private EventInterface eventScript;
        public void setupEventObject();
        // Method body must be:
        // {
        //     // Fetch the correct event script
        //     try
        //     {
        //         eventScript = eventObject.GetComponent(typeof(EventInterface)) as EventInterface;
        //     }
        //     catch (System.Exception e)
        //     {
        //         Debug.Log("You haven't connected a gameobject to this trigger" + e);
        //     }
        // }

    }
}