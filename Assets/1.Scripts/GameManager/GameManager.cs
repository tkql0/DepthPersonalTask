using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleTon<GameManager>
{
    public Player player;

    public ParticleSystem coinParticleSystem;
    public ParticleSystem fallParticleSystem;
}
