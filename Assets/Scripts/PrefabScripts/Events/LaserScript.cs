using System.Collections;
using UnityEngine;
using Interfaces;

public class LaserScript : MonoBehaviour, EventInterface
{

    public GameObject playerInstance;
    public GameObject laserBars;
    private PlayerMovement playerMovement;
    public AudioSource laserBuzzSound;

    public Light flickerLight;

    private GameObject deathTrigger;

    void Start()
    {
        playerMovement = playerInstance.GetComponent<PlayerMovement>();
        deathTrigger = GetComponent<BoxCollider>().gameObject;

    }
    public void executeEvent()
    {
        laserBuzzSound.Stop();

        flickerLight.enabled = false;
        laserBars.SetActive(false);
        deathTrigger.SetActive(false);
    }

    public void endExecution()
    {

        laserBuzzSound.Play();
        flickerLight.enabled = true;
        laserBars.SetActive(true);
        deathTrigger.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player has entered the laser trigger");
            playerMovement.dieAndRespawn(1);
        }
        else if (
            other.gameObject.tag == "Corpse")
        {
            Destroy(other.gameObject);
        }
    }
}
