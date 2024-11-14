using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private Vector3 _targetPosition;
    private Renderer renderer;
    public Color color;
    public float speed;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        if (color != null && renderer != null)
        {
            renderer.material.color = color;
        }
    }

    private void Update()
    {
        if (transform.position.x < -15f || transform.position.x > 15f)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(speed * Time.fixedDeltaTime, 0, 0);
    }
}
