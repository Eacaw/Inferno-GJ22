using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class DoorScript : MonoBehaviour, EventInterface
{
    public void executeEvent()
    {
        // lasers.setActive(false); Hide the model
    }

    public void endExecution()
    {
        // lasers.setActive(true); Show the model
    }
}
