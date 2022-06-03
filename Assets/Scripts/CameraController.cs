using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public int cameraOffsetId = 0;

    void LateUpdate()
    {
        Vector3[] cameraOffsets = new Vector3[]
        {
            new Vector3(8, 4, -1), // Initial camera offset
            new Vector3(8, 10, 0)  // Camera behind player - walking forwards in level
        };

        transform.position = target.position + cameraOffsets[cameraOffsetId];
        transform.LookAt(target);
    }
}