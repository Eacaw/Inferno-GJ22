using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class MovingWall : MonoBehaviour, EventInterface
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    public int speed;

    private bool isTriggered = false;
    private bool canMove = true;

    void Start()
    {
        startPosition = transform.position;
        endPosition = transform.position + new Vector3(0, -20f, 0);
    }

    void Update()
    {
        if (isTriggered && transform.position.y >= endPosition.y && canMove)
        {
            Debug.Log("Triggered");
            transform.Translate(new Vector3(0, 0, -1) * (speed * Time.deltaTime));
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

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canMove = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canMove = true;
        }
    }
}
