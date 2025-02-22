using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 5f;
    private bool isSpawing = true;

    private void Start()
    {
        //StartCoroutine(DeleySpawn());  
        StartCoroutine(SpawnEnemies());

    }
    //IEnumerator DeleySpawn()
    //{
    //    yield return new WaitForSeconds(5f);
    //    StartCoroutine(SpawnEnemies());
    //}
    IEnumerator SpawnEnemies()
    {
        if (isSpawing)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(spawnInterval);
            StartCoroutine(SpawnEnemies());
        }
    }
    public void StopSpawing()
    {
        isSpawing = false;
    }
    public void StartSpawing()
    {
        if (!isSpawing)
        {
            isSpawing = true;
            StartCoroutine(SpawnEnemies());
        }
    }
}
