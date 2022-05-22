using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    public int speed;

    private bool isTriggered = false;
    void Start()
    {
        startPosition = transform.position;
        endPosition = transform.position + new Vector3(0, 10, 0);
        Debug.Log("Start Position: " + startPosition);
        Debug.Log("End Position: " + endPosition);
    }

    void Update()
    {
        if (isTriggered && transform.position.y <= endPosition.y)
        {
            Debug.Log("Position: " + transform.position);
            Debug.Log("End Position: " + endPosition);
            transform.Translate(new Vector3(0, 0, 1) * (speed * Time.deltaTime));
        }
        else if (!isTriggered && transform.position.y >= startPosition.y)
        {
            transform.Translate(new Vector3(0, 0, -2) * (speed * Time.deltaTime));
        }
    }

    public void executeEvent()
    {

        isTriggered = true;
    }

    public void endExecution()
    {
        isTriggered = false;
    }
}
