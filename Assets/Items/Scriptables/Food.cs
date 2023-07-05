using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "ScriptableObjects/Food", order = 1)]
public class Food : ScriptableObject
{
    public string name;
    public List<GameObject> prefabs;
    public float calories;  

    public GameObject GetRandomPrefab()
    {
        GameObject prefab = prefabs[Random.Range(0,2)];
        return prefab;
    }
}