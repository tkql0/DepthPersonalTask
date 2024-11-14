using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleTon<GameManager>
{
    public Player player;

    public ParticleSystem coinParticleSystem;
    public ParticleSystem fallParticleSystem;

    private int currentCoins = 0;
    private int currentDistance = 0;
    private bool canPlay = false;

    private AudioSource effect;
    private AudioClip clip = null;
    // 나중에 게임 크기가 커지면 리스트를 만드는지 배열 만드는지

    public event Action<int> coins;
    public event Action<int> distance;
    public event Action gameOver;

    private void Start()
    {
        effect = GetComponent<AudioSource>();
        clip = effect.clip;
    }

    public void UpdateCoinCount(int value)
    {
        currentCoins += value;
        effect.PlayOneShot(clip);
        // 코인 먹었을때 소리 출력
        coins?.Invoke(currentCoins);
    }

    public void ParticleSpawn(Vector3 inTargetPosition,
        ParticleSystem inParticleSystem, int inMaxCount)
    {
        ParticleSystem particleSystem =
            Instantiate(inParticleSystem);
        particleSystem.transform.position = inTargetPosition;
        particleSystem.Stop();
        ParticleSystem.EmissionModule emissionModule =
                particleSystem.emission;
        emissionModule.SetBurst(0, new ParticleSystem.Burst(0, inMaxCount));
        particleSystem.Play();
    }
}
