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
    public bool bounceCube = false;
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
        laserBars.gameObject.SetActive(false);
        deathTrigger.SetActive(false);
        FindObjectOfType<SoundManager>().Play("LaserShutdown");
    }

    public void endExecution()
    {
        laserBuzzSound.Play();
        flickerLight.enabled = true;
        laserBars.gameObject.SetActive(true);
        deathTrigger.SetActive(true);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<SoundManager>().Play("LaserSizzle");
            playerMovement.dieAndRespawn(1);
        }
        else if (
            other.gameObject.tag == "Corpse")
        {
            Destroy(other.gameObject);
        }
        // This is not a perfect solution, we need to refine this, it's going in the fixit bucket
        else if (
            other.gameObject.tag == "MovableTrigger")
        {
            if (this.bounceCube)
            {
                Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();
                // push the object backwards
                otherRb.AddForce(-otherRb.velocity * 2.0f, ForceMode.Impulse);
            }
        }


    }
}
