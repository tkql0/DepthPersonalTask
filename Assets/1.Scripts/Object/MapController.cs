using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.player.controller.OnDie += ParticleSpawn;
    }

    public void ParticleSpawn()
    {
        if (!GameManager.Instance.player.controller.isSwimming)
        {
            return;
        }

        ParticleSystem particleSystem =
            Instantiate(GameManager.Instance.fallParticleSystem);
        particleSystem.transform.position = transform.position;
        // 내위치에서 파티클 실행
        particleSystem.Stop();
        ParticleSystem.EmissionModule emissionModule =
                particleSystem.emission;
        emissionModule.SetBurst(0, new ParticleSystem.Burst(0, 100));
        particleSystem.Play();
    }
}
