using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Player player;

    private void Start()
    {
        player = GameManager.Instance.player;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }
    }
}
