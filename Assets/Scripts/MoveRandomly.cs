using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomly : MonoBehaviour
{
    private float speedX;
    private float speedY;
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - 300, Screen.height - 300));

        // Asignar direcciones aleatorias (1 o -1)
        float directionX = Random.Range(0f, 1f) > 0.5f ? 1f : -1f;
        float directionY = Random.Range(0f, 1f) > 0.5f ? 1f : -1f;  

        // Aplicar la dirección a las velocidades
        speedX *= directionX;
        speedY *= directionY;
    }

    void Update()
    {
        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0f);

        if (transform.position.x > screenBounds.x || transform.position.x < -screenBounds.x)
        {
            speedX = -speedX;
        }

        if (transform.position.y > screenBounds.y || transform.position.y < -screenBounds.y)
        {
            speedY = -speedY;
        }
    }

    public void SetSpeeds(float newSpeedX, float newSpeedY)
    {
        speedX = newSpeedX;
        speedY = newSpeedY;
    }
}


