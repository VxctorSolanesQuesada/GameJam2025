using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatGenerator : MonoBehaviour
{

    public GameObject[] cats;
    private float timeBetweenAppearances = 4f;
    public Image targetCatImage;
    public PointsControl puntos;
    public Text scoreText;
    public int score = 0;
    private bool goodClick = false;

    public GameObject targetCat;
    public int targetCatIndex = -1;
    private float waitTime;

    void Start()
    {
        waitTime = timeBetweenAppearances;
        SpawnCats(5, 3);
    }

    void Update()
    {
        waitTime -= Time.deltaTime;

        if (waitTime <= 0f)
        {
            puntos.puntos = score;
            Debug.Log("Te has quedado sin tiempo!");
            GameManager.Instance.GameOver();
            return;  
        }

        if (goodClick)
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
            else if (score >= 25 && score < 35)
            {
                SpawnCats(30, 10);
            }
            else if (score >= 35)
            {
                SpawnCats(30, 10);
            }

            if (score % 5 == 0 && timeBetweenAppearances >= 2f)
            {
                timeBetweenAppearances -= 0.2f;
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
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - 300, Screen.height -300));
        List<Vector3> catPositions = new List<Vector3>();

        // Elegir el gato correcto aleatoriamente entre los tipos disponibles
        int targetCatIndex = Random.Range(0, maxCatTypes);

        // Generar una lista de todos los índices de gatos a spawnear
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

        // Insertamos el gato correcto en una posición aleatoria
        int targetCatPosition = Random.Range(0, numberOfCats);
        catsToSpawn.Insert(targetCatPosition, targetCatIndex);

        // Generamos los gatos en la pantalla
        for (int i = 0; i < numberOfCats; i++)
        {
            Vector3 spawnPosition = GetRandomPosition(screenBounds, catPositions);
            GameObject spawnedCat = Instantiate(cats[catsToSpawn[i]], spawnPosition, Quaternion.identity);
            catPositions.Add(spawnPosition);

            // Añadimos el componente correspondiente según si es el gato correcto o no
            if (i == targetCatPosition)
            {
                spawnedCat.AddComponent<CatCorrect>();
            }
            else
            {
                spawnedCat.AddComponent<CatWrong>();

            }

            if (score >=15)
            {
                spawnedCat.AddComponent<RandomRotation>();
            }

            spawnedCat.AddComponent<MoveRandomly>();
            MoveRandomly moveRandomlyScript = spawnedCat.GetComponent<MoveRandomly>();

            if (score >= 0 && score < 5)
            {
                moveRandomlyScript.SetSpeeds(0.5f, 0.5f);
            } else if (score >= 5 && score < 15)
            {
                moveRandomlyScript.SetSpeeds(1f, 1f);
            } else if (score >= 15 && score < 25)
            {
                moveRandomlyScript.SetSpeeds(1.5f, 1.5f);
            } else if (score >= 25)
            {
                moveRandomlyScript.SetSpeeds(2f, 2f);
            }
        }

        // Actualizamos la imagen del gato correcto en el UI
        GameObject targetCat = cats[targetCatIndex];
        if (targetCatImage != null)
        {
            targetCatImage.enabled = true;
            targetCatImage.sprite = targetCat.GetComponent<SpriteRenderer>().sprite;
            targetCatImage.rectTransform.localScale = Vector3.one; // Restart
            targetCatImage.SetNativeSize();
            targetCatImage.rectTransform.localScale *= 2f;
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