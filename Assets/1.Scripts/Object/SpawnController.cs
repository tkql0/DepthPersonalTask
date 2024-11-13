using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public bool goLeft = false;
    public bool goRight = false;

    public List<GameObject> items;
    public Spawner spawnersLeft;
    public Spawner spawnersRight;
}
