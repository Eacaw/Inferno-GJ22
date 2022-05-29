using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corpseScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            FindObjectOfType<SoundManager>().Play("CorpseSplat");
        }
    }
}
