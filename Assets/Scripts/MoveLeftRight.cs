using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    private float speed = 20f;
    private float amplitude = 0.05f;
    private float startPositionX; 

    void Start()
    {
        startPositionX = transform.position.x; 
    }

    void Update()
    {
        // Calculamos la nueva posición X basándonos en la posición inicial
        float newPosX = startPositionX + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
    }
}
