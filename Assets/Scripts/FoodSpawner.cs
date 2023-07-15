using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public float spawnRate = 1;
    public GameObject ground;
    // public int floorScale = 1;
    public List<GameObject> myPrefabs;
    // public GameObject myPrefab;
    public float timeElapsed = 0;

    public GameObject GetRandomPrefab()
    {
        GameObject prefab = myPrefabs[Random.Range(0,2)];
        return prefab;
    }

    void Start()
    {
        // Spawn food at random locations at the start of the game
        for (int i = 0; i < 100; i++)
        {
            SpawnFood();
        }
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        //spawn food every second with timeElapsed
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= spawnRate)
        {
            timeElapsed = timeElapsed % spawnRate;
            SpawnFood();
        }
    }

    void SpawnFood()
    {
        GameObject  randomPrefab = GetRandomPrefab();
        Vector3 groundSize = ground.GetComponent<Renderer>().bounds.size;
        float x = Random.Range(-groundSize.x / 2f, groundSize.x / 2f);
        float y = groundSize.y - 1f;
        float z = Random.Range(-groundSize.z / 2f, groundSize.z / 2f);
        // int x = Random.Range(-100, 101)*floorScale;
        // int z = Random.Range(-100, 101)*floorScale;
        Instantiate(randomPrefab, new Vector3(x, y, z), Quaternion.identity);
    }
}