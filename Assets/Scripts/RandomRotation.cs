
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public float minRotation = -45f;
    public float maxRotation = 45f;

    void Start()
    {
        Transform spriteTransform = transform.Find("Sprite"); 

        if (spriteTransform != null)
        {
            float randomRotation = Random.Range(minRotation, maxRotation);

            spriteTransform.rotation = Quaternion.Euler(0f, 0f, randomRotation);
        }
        else
        {
            Debug.LogError("No se encontró un objeto hijo llamado 'Sprite'.");
        }
    }
}