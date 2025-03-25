using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public float minRotation = -45f;
    public float maxRotation = 45f;

    void Start()
    {
        float randomRotation = Random.Range(minRotation, maxRotation);
        transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);
    }
}
