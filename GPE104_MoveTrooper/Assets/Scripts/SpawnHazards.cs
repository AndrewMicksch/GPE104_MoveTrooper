using UnityEngine;

public class SpawnHazards : MonoBehaviour
{

    public GameObject AsteroidToSpawn;
    public GameObject UFOToSpawn;
    public Controller ControllerToGrab;

    [Header("Location")]
    public float spawnTime;
    public float spawnArea;
    float minX = -10f;
    float maxX = 10f;
    float minY = -5f;
    float maxY = 5f;
    private Transform spawnPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnUFO()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        transform.position = new Vector2(randomX, randomY);
        
    }
    public void SpawnAsteroid()
    {

    }
}
