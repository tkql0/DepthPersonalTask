using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Coin : MonoBehaviour
{
    private Vector3 _particleSpawnPosition;

    public int coinValue = 1;

    private void Start()
    {
        _particleSpawnPosition = new Vector3(0, 1, 0);
    }

    public void AddScore()
    {
        GameManager.Instance.UpdateCoinCount(coinValue);

        GameManager.Instance.
            ParticleSpawn(transform.position + _particleSpawnPosition,
            GameManager.Instance.coinParticleSystem, 100);

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out var outPlayer))
        {
            AddScore();
        }
    }
}
