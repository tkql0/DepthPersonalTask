using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
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
        renderer.material.color = color;
    }

    private void Update()
    {
        if (transform.position.x < -25f || transform.position.x > 25f)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(speed * Time.fixedDeltaTime, 0, 0);
    }
}
