using System.Collections;
using UnityEngine;
using Interfaces;

public class LaserScript : MonoBehaviour, EventInterface
{

    public GameObject playerInstance;
    public GameObject laserBars;
    private PlayerMovement playerMovement;
    public AudioSource laserBuzzSound;
    // private AudioSource laserShutoffSound;
    public Light flickerLight;

    private GameObject deathTrigger;

    void Start()
    {
        playerMovement = playerInstance.GetComponent<PlayerMovement>();
        deathTrigger = GetComponent<BoxCollider>().gameObject;
        // laserShutoffSound = GetComponent<AudioSource>();
    }
    public void executeEvent()
    {
        laserBuzzSound.Stop();
        // laserShutoffSound.Stop();
        flickerLight.enabled = false;
        laserBars.gameObject.SetActive(false);
        deathTrigger.SetActive(false);
    }

    public void endExecution()
    {
        // laserShutoffSound.Play();
        laserBuzzSound.Play();
        flickerLight.enabled = true;
        laserBars.gameObject.SetActive(true);
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
