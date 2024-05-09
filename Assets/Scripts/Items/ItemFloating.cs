using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFloating : MonoBehaviour
{
    public float floatSpeed = 4f; 
    public float floatHeight = 0.01f;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
