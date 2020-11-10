using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 45.0f;
    private float spawnRangeZ = 20.0f;
    // private float startDelay = 2;
    // private float spawnInterval = 1.5f;
    private float spawnRate = 1.5f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        // InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval); // call the function every 2 seconds after 1.5 seconds the game starts.
        // 

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartSpawn(int difficulty)
    {
        spawnRate /= difficulty;
        StartCoroutine(SpawnEnemy());
    }

    public IEnumerator SpawnEnemy()
    {
        
        while(gameManager.isGameActive)
        {
            // Debug.Log("Spawan an enemy!");
            // Debug.Log(gameManager.isGameActive);
            
            yield return new WaitForSeconds(spawnRate);
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
    }

    void SpawnRandomEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);

    }
}
