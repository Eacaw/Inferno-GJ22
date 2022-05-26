using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class RagdollTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject player = other.gameObject;
            PlayerMovement script = player.GetComponentInParent<PlayerMovement>() as PlayerMovement;
            script.disableInput();
        }
    }

}
