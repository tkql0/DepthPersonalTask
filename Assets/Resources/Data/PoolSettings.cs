using UnityEngine;

[CreateAssetMenu(fileName = "PoolSettings", menuName = "Pooling/PoolSettings")]
public class PoolSettings : ScriptableObject
{
    public string tag;
    public GameObject prefab;
    public int size;
}