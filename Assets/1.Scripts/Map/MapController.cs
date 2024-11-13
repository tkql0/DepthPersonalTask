using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var outPlayer))
        {
            GameManager.Instance.
            ParticleSpawn(outPlayer.transform.position,
            GameManager.Instance.fallParticleSystem, 50);
            PlayerPrefs.Save();
        }
    }
}
