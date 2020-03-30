using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawns;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;
    public Transform bossSpawn;
    public Enemy boss;

    Wave currentWave;
    int currentWaveIndex;
    Transform player;
    bool finishedSpawning;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
    }

    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];

        for (int i = 0; i< currentWave.count; i++)
        {
            if (player == null)
            {
                yield break;
            }

            if (i == currentWave.count - 1)
            {
                finishedSpawning = true;
            } else
            {
                finishedSpawning = false;
            }

            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length - 1)];
            Transform randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];

            Instantiate(randomEnemy, randomSpawn.position, randomSpawn.rotation);

            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
        }  
    }

    private void Update()
    {
       if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && finishedSpawning == true)
        {
            finishedSpawning = false;
            if (currentWaveIndex + 1 < waves.Length)
            {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));

            } else
            {
                Instantiate(boss, bossSpawn.position, bossSpawn.rotation);
            }
        } 
    }
}