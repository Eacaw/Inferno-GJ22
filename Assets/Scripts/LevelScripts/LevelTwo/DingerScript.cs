using UnityEngine;

public class DingerScript : MonoBehaviour
{
    private AudioSource audioSource;
    void
     Start(){
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Corpse") {
            audioSource.Play();
        }
    }
}