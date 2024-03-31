using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float Xoffset;

    private void LateUpdate()
    {
        if(target != null)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = target.position.x + Xoffset;
            transform.position = currentPosition;
        }
    }
}
