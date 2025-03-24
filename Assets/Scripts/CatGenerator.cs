using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CatGenerator : MonoBehaviour
{
    private Camera _mainCamera;

    public GameObject[] cats;
    public float timeBetweenAppearances = 6f;
    public Image targetCatImage;
    public Text scoreText;
    private int score = 0;
    public Color color1;

    public GameObject targetCat;
    private int targetCatIndex = -1;
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        waitTime = timeBetweenAppearances;
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;

        //Cuando el contador llega a 0 reinicia las posiciones de los gatos
        if (waitTime <= 0f)
        {
            SpawnCats();
            waitTime = timeBetweenAppearances;
        }
    }

    void SpawnCats()
    {
        // Error check
        if (cats.Length == 0)
        {
            Debug.LogError("Cats are not assigned!");
            return; 
        }

        // Destruimos los gatos anteriores si hay
        GameObject[] existingCats = GameObject.FindGameObjectsWithTag("Cat");
        if (existingCats.Length != 0)
        {
            foreach (GameObject cat in existingCats)
            {
                Destroy(cat);
            }
        }

        // Posiciones de la pantalla
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width-300, Screen.height));
        List<Vector3> catPositions = new List<Vector3>();

        // Spawnear gatos
        targetCatIndex = Random.Range(0, cats.Length);

        int catCount = cats.Length;
        for (int i = 0; i < catCount; i++)
        {
            Vector3 spawnPosition = GetRandomPosition(screenBounds, catPositions);
            GameObject spawnedCat = Instantiate(cats[i], spawnPosition, Quaternion.identity);

            targetCat = cats[targetCatIndex];

            // Actualizamos la imagen del gato en el Canvas
            if (targetCatImage != null)
             {
                targetCatImage.enabled = true;
                targetCatImage.sprite = targetCat.GetComponent<SpriteRenderer>().sprite;
                targetCatImage.color = targetCat.GetComponent<SpriteRenderer>().color;
                color1= targetCat.GetComponent<SpriteRenderer>().color;
            }

            catPositions.Add(spawnPosition);
        }
    }
    // Funcion para comprobar que los gatos no spawnean uno encima del otro
    Vector3 GetRandomPosition(Vector2 screenBounds, List<Vector3> catPositions)
    {
        Vector3 newPosition = Vector3.zero;
        bool validPosition = false;

        while (!validPosition)
        {
            float randomX = Random.Range(-screenBounds.x, screenBounds.x);
            float randomY = Random.Range(-screenBounds.y, screenBounds.y);
            newPosition = new Vector3(randomX, randomY, 0f);

            validPosition = true;
            foreach (Vector3 pos in catPositions)
            {
                if (Vector3.Distance(newPosition, pos) < 1f)
                {
                    validPosition = false;
                    break;
                }
            }
        }

        return newPosition;
    }

    // Actualizar el texto del puntaje en el Canvas
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
