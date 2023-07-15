using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    public GameObject agentPrefab, ground;
    private GameObject[] agentList;
    public int floorScale = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        agentList = GameObject.FindGameObjectsWithTag("Creature");

        // if there are no agents in the scene, spawn one at a random location. 
        // This is to ensure that there is always at least one agent in the scene.
        if (agentList.Length < 1)
        {
            SpawnCreature();
        } 
    }

    void SpawnCreature()
    {
        Vector3 groundSize = ground.GetComponent<Renderer>().bounds.size;
        float x = Random.Range(-groundSize.x / 2f, groundSize.x / 2f);
        float y = groundSize.y - 1f;
        float z = Random.Range(-groundSize.z / 2f, groundSize.z / 2f);
        // int x = Random.Range(-100, 101)*floorScale;
        // int z = Random.Range(-100, 101)*floorScale;
        Instantiate(agentPrefab, new Vector3(x, y, z), Quaternion.identity);
    }
}