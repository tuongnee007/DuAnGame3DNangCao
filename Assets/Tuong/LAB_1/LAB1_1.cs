using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAB1_1 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector3 spawnRange = new Vector3(5f,5f,5f);
    public int maxSpawnCount = 10;
    private int spawnCount = 0;
    private void Start()
    {
        StartCoroutine(WaitAndSpawnEnemy());
    }
    IEnumerator WaitAndSpawnEnemy()
    {
        while (spawnCount < maxSpawnCount)
        {
            yield return new WaitForSeconds(2f);
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnRange.x, spawnRange.x),
                Random.Range(-spawnRange.y, spawnRange.y),
                Random.Range(-spawnRange.z,spawnRange.z));

            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            spawnCount++;
        }
    }
}
