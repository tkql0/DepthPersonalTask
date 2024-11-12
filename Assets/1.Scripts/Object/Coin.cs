using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Coin : MonoBehaviour
{
    private Vector3 _particleSpawnPosition;

    private void Start()
    {
        _particleSpawnPosition = new Vector3(0, 1, 0);
        GameManager.Instance.player.controller.OnItemAdd += AddScore;
    }

    public void AddScore()
    {
        ParticleSpawn();

        gameObject.SetActive(false);
    }

    private void ParticleSpawn()
    {
        ParticleSystem particleSystem =
            Instantiate(GameManager.Instance.coinParticleSystem);
        particleSystem.transform.position = transform.position + _particleSpawnPosition;
        // 내위치에서 파티클 실행
        particleSystem.Stop();
        ParticleSystem.EmissionModule emissionModule =
                particleSystem.emission;
        emissionModule.SetBurst(0, new ParticleSystem.Burst(0, 100));
        particleSystem.Play();
    }    
}
