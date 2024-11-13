using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoSingleTon<ObjectPool>
{
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        PoolSettings[] poolSettingsList = Resources.LoadAll<PoolSettings>("PoolingSettings");
        foreach (var pool in poolSettingsList)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject newObject = Instantiate(pool.prefab, transform);
                newObject.SetActive(false);
                objectPool.Enqueue(newObject);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }


    public GameObject SpawnFromPool(string inTag)
    {
        if (!poolDictionary.ContainsKey(inTag))
        {
            return null;
        }
        Queue<GameObject> objectPool = poolDictionary[inTag];

        int count = objectPool.Count;
        for (int i = 0; i < objectPool.Count; i++)
        {
            GameObject outObject = objectPool.Dequeue();

            if (!outObject.activeInHierarchy)
            {
                outObject.SetActive(true);
                objectPool.Enqueue(outObject);
                return outObject;
            }

            count++;
            objectPool.Enqueue(outObject);
        }

        if (count == objectPool.Count)
        {
            GameObject outNewObject = Instantiate(objectPool.Peek());
            outNewObject.SetActive(true);
            objectPool.Enqueue(outNewObject);

            return outNewObject;
        }

        return null;
    }
}
