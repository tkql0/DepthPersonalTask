using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Spawner : MonoBehaviour
{
    public Transform startPos = null;

    public float delayMin = 1.5f;
    public float delayMax = 5;

    public bool useSpawnPlacement = false;
    public int spawnCount = 4;

    private float lastTime = 0;
    private float delayTime = 0;
    private Color spawnColor;

    [HideInInspector] public ObjectSO Item = null;
    [HideInInspector] public bool goLeft = false;
    [HideInInspector] public float spawnLeftPos = 0;
    [HideInInspector] public float spawnRightPos = 0;

    void Start()
    {
        if (useSpawnPlacement)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                SpawnItem();
            }
        }
    }

    void Update()
    {
        if (useSpawnPlacement) return;

        if (Time.time > lastTime + delayTime)
        {
            lastTime = Time.time;
            delayTime = Random.Range(delayMin, delayMax);
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        Debug.Log("Spawn Item");
        GameObject newObject = ObjectPool.Instance.SpawnFromPool(Item.itemName);
        newObject.transform.position = GetSpawnPosition();
        float direction = 0;
        if (goLeft) direction = 180;

        if (!useSpawnPlacement)
        {
            if (!newObject.TryGetComponent<ItemObject>(out var outItemData))
            {
                return;
            }
            outItemData.speed = Item.randomSpeed();
            outItemData.color = Item.color;
            newObject.transform.rotation =
                newObject.transform.rotation * Quaternion.Euler(0, direction, 0);
        }
    }

    Vector3 GetSpawnPosition()
    {
        if (useSpawnPlacement)
        {
            return new Vector3(Random.Range(spawnLeftPos, spawnRightPos), 0.45f, startPos.position.z);
        }
        else
        {
            return startPos.position;
        }
    }
}
