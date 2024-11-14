using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemObject", menuName = "ObjectDatas/NewItemObjectData")]
public class ObjectSO : ScriptableObject
{
    public string itemName;
    public GameObject prefab;

    public float speedMin = 1;
    public float speedMax = 4;
    public Color color;

    public float randomSpeed()
    {
        float speed = 0;

        return speed = Random.Range(speedMin, speedMax);
    }
}