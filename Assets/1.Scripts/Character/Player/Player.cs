using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller { get; private set; }

    void Awake()
    {
        GameManager.Instance.player = this;

        controller = GetComponent<PlayerController>();
    }
}
