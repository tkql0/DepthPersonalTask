using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapScroll : MonoBehaviour
{
    [SerializeField]
    private Vector3 targetPosition;
    [SerializeField]
    private GameObject spawnPositionObject;
    [SerializeField]
    private MapGenerator mapGenerator;

    private void Awake()
    {
        mapGenerator = GetComponentInParent<MapGenerator>();
    }

    private void OnEnable()
    {
        if (mapGenerator.mapObjectArray.Count > 0)
        {
            spawnPositionObject = mapGenerator.mapObjectArray
                [mapGenerator.mapObjectArray.Count - 1];

            transform.position =
                spawnPositionObject.transform.position + new Vector3(0, 0, 1f);
        }
    }

    private void Update()
    {
        targetPosition = new Vector3(0, 0, GameManager.Instance.player.transform.position.z - 2);

        if (Vector3.Distance(transform.position, targetPosition) <= 0f)
        {
            PositionReSet();
        }
    }
    private void PositionReSet()
    {
        GameObject newMapObject = mapGenerator.
            GetMapObject();
        mapGenerator.mapObjectArray.Add(newMapObject);

        gameObject.SetActive(false);
        mapGenerator.mapObjectArray.Remove(gameObject);
    }
}
