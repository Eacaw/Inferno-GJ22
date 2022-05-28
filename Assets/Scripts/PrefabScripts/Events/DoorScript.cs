using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class DoorScript : MonoBehaviour, EventInterface
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    public int speed;

    public AudioSource doorMoving;

    private bool isTriggered = false;
    private bool canMove = true;
    private bool isMoving = false;
    private bool isMoveSoundPlaying = false;

    void Start()
    {
        startPosition = transform.position;
        endPosition = transform.position + new Vector3(0, 3.5f, 0);
    }

    void Update()
    {
        if (canMove)
        {
            if (isTriggered && transform.position.y <= endPosition.y)
            {
                isMoving = true;
                transform.Translate(new Vector3(0, 0, 1) * (speed * Time.deltaTime));
            }
            else if (!isTriggered && transform.position.y >= startPosition.y)
            {
                isMoving = true;
                transform.Translate(new Vector3(0, 0, -2) * (speed * Time.deltaTime));
            }
            else
            {
                isMoving = false;
                isMoveSoundPlaying = false;
                doorMoving.Stop();
            }
        }
        playMoveSound();
    }

    void playMoveSound()
    {
        if (!isMoveSoundPlaying && isMoving)
        {
            doorMoving.Play();
            isMoveSoundPlaying = true;
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
