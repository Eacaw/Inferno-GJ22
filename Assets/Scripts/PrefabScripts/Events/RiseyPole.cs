using UnityEngine;
using Interfaces;

public class RiseyPole : MonoBehaviour, EventInterface
{

    private bool isMoving = true;
    private bool canMove = true;

    public bool getIsTriggered()
    {
        return !isMoving;
    }

    void FixedUpdate()
    {
        // Move platform up and down with a sine wave
        float getSineOffsetToVerticalPosition = Mathf.Sin(Time.time * 1.0f) + 1f;
        if (this.isMoving && canMove)
        {
            transform.position = new Vector3(transform.position.x, getSineOffsetToVerticalPosition * 2.25f + 0.7f, transform.position.z);
        }
    }

    public void executeEvent()
    {
        this.isMoving = false;
    }

    public void endExecution()
    {
        this.isMoving = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canMove = true;
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
