using UnityEngine;
using Interfaces;

public class LaserScript : MonoBehaviour, EventInterface
{


    void Start()
    {

    }
    public void executeEvent()
    {
        gameObject.SetActive(false);
    }

    public void endExecution()
    {
        gameObject.SetActive(true);
    }
}
