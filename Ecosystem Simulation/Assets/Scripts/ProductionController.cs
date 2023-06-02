using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionController : MonoBehaviour
{
    public GameObject ground;    // Reference to the ground object
    public Food foodItem;        // Reference to the Food Scriptable Object
    public float spawnInterval = 1f;
    public int maxGrassCount = 10;
    public Transform hierarcySpawnParent;    // Reference to the parent object for the spawned grass

    private List<GameObject> grassList = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnGrass());
    }

    private IEnumerator SpawnGrass()
    {
        while (true)
        {
            if (grassList.Count < maxGrassCount)
            {
                Vector3 randomPosition = GetRandomPositionOnGround();
                if (IsPositionValid(randomPosition))
                {
                    // Get a random prefab from the list of prefabs in the Food Scriptable Object
                    GameObject randomPrefab = foodItem.GetRandomPrefab();

                    if (randomPrefab != null)
                    {
                        // Instantiate the random prefab at the valid position under the dynamicParent
                        GameObject newGrass = Instantiate(randomPrefab, randomPosition, Quaternion.identity, hierarcySpawnParent);
                        grassList.Add(newGrass);
                    }
                }
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 GetRandomPositionOnGround()
    {
        Vector3 groundSize = ground.GetComponent<Renderer>().bounds.size;
        float x = Random.Range(-groundSize.x / 2f, groundSize.x / 2f);
        float y = groundSize.y - 1f;
        float z = Random.Range(-groundSize.z / 2f, groundSize.z / 2f);
        return new Vector3(x, y, z);
    }

    private bool IsPositionValid(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 0.5f);
        foreach (var collider in colliders)
        {
            if (collider.gameObject != ground && !collider.CompareTag("Food"))
            {
                return false;
            }
        }
        return true;
    }
}
