using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatGenerator : MonoBehaviour
{

    public GameObject[] cats;
    public float timeBetweenAppearances = 3f;
    public Image targetCatImage;
    public Text scoreText;
    private int score = 0;
    private bool goodClick = false;

    public GameObject targetCat;
    public int targetCatIndex = -1;
    private float waitTime;
    
    void Start()
    {
        waitTime = timeBetweenAppearances;
        SpawnCats(5,3);
    }

    void Update()
    {
        waitTime -= Time.deltaTime;

        if (waitTime <= 0f || goodClick)
        {
            goodClick = false;

            // Condiciones para la puntuacion
            if (score <= 3)
            {
                SpawnCats(5, 3);
            }
            else if (score >= 3 && score < 10)
            {
                SpawnCats(10, 5);
            }
            else if (score >= 10 && score < 15)
            {
                SpawnCats(15, 7);
            }
            else if (score >= 15 && score < 20)
            {
                SpawnCats(20, 10);
            }
            else if (score >= 20 && score < 25)
            {
                SpawnCats(25, 10);
            }
            else if (score >= 25 && score < 30)
            {
                SpawnCats(30, 10);
            }
            else if (score >= 35)
            {
                SpawnCats(30, 10);
                timeBetweenAppearances = 2.5f;
            }


            waitTime = timeBetweenAppearances;
        }
    }


    void SpawnCats(int numberOfCats, int maxCatTypes)
    {
     
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
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - 300, Screen.height));
        List<Vector3> catPositions = new List<Vector3>();

        // Elegir el gato correcto aleatoriamente entre los tipos disponibles
        int targetCatIndex = Random.Range(0, maxCatTypes);

        // Generar una lista de todos los �ndices de gatos a spawnear
        List<int> catsToSpawn = new List<int>();

        // Primero agregamos los gatos incorrectos (no incluimos el gato correcto)
        for (int i = 0; i < numberOfCats - 1; i++)
        {
            int randomCat = Random.Range(0, maxCatTypes);

            // Aseguramos que no se seleccione el gato correcto
            while (randomCat == targetCatIndex)
            {
                randomCat = Random.Range(0, maxCatTypes);
            }

            catsToSpawn.Add(randomCat); 
        }

        // Insertamos el gato correcto en una posici�n aleatoria
        int targetCatPosition = Random.Range(0, numberOfCats);  
        catsToSpawn.Insert(targetCatPosition, targetCatIndex); 

        // Generamos los gatos en la pantalla
        for (int i = 0; i < numberOfCats; i++)
        {
            Vector3 spawnPosition = GetRandomPosition(screenBounds, catPositions);
            GameObject spawnedCat = Instantiate(cats[catsToSpawn[i]], spawnPosition, Quaternion.identity);
            catPositions.Add(spawnPosition);

            // A�adimos el componente correspondiente seg�n si es el gato correcto o no
            if (i == targetCatPosition)
            {
                spawnedCat.AddComponent<CatCorrect>();  
            }
            else
            {
                spawnedCat.AddComponent<CatWrong>();
            }
        }

        // Actualizamos la imagen del gato correcto en el UI
        GameObject targetCat = cats[targetCatIndex];
        if (targetCatImage != null)
        {
            targetCatImage.enabled = true;
            targetCatImage.sprite = targetCat.GetComponent<SpriteRenderer>().sprite;
            targetCatImage.color = targetCat.GetComponent<SpriteRenderer>().color;
        }

        goodClick = false;
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
    public void UpdateScoreText()
    {
        score++;
        goodClick = true;
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
