using UnityEngine;

public class Spawner : MonoBehaviour
{   
    public GameObject[] asteroidPrefabs;

    public GameObject rapidFirePrefab;

    public float spawnRate = 1f;

    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnRate)
        {
            SpawnAsteroid();

            timer = 0f;
        }

        if(spawnRate > 0.3f)
        {
            spawnRate -= 0.001f * Time.deltaTime;
        }
        Asteroid.globalSpeed += 0.4f * Time.deltaTime;
    }

    void SpawnAsteroid()
    {
        float randomX = Random.Range(-8f, 8f);
        Debug.Log(asteroidPrefabs.Length);
        Debug.Log(asteroidPrefabs[0]);

        Vector2 spawnPos = new Vector2(randomX, 20f);

        GameObject randomAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];

        GameObject asteroid = Instantiate(randomAsteroid, spawnPos, Quaternion.identity);

        float randomSize = Random.Range(0.5f, 1.3f);

        asteroid.transform.localScale = Vector3.one * randomSize;

        if(Random.value < 0.05f)
            {
    Instantiate(
        rapidFirePrefab,
        spawnPos,
        Quaternion.identity
    );
            }
    }
}