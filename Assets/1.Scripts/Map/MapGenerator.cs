using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private string[] mapNameArray = { "EnemyMap", "WaterMap", "TreeMap" };
    public List<GameObject> mapObjectArray = new List<GameObject>();

    private float mapSpawnDistance = 1;
    private int mapSpawnCount = 11;

    private void Start()
    {
        for (int i = 1; i < mapSpawnCount; i++)
        {
            StartMapSpawn(i);
        }
    }

    private void StartMapSpawn(int inSpawnCount)
    {
        GameObject newMapObject = GetMapObject();

        newMapObject.transform.position =
            new Vector3(0, 0, inSpawnCount * mapSpawnDistance);
        mapObjectArray.Add(newMapObject);
    }

    public GameObject GetMapObject()
    {
        int randomMap = Random.Range(0, mapNameArray.Length);
        GameObject outNewMap = ObjectPool.Instance.SpawnFromPool(mapNameArray[randomMap]);

        return outNewMap;
    }
}
