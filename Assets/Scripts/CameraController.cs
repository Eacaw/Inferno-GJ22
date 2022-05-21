using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + new Vector3(8, 4, -1);
        transform.LookAt(target);
    }
}