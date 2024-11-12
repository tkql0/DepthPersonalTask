using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    private Vector3 _targetPosition;

    private float speed = 1;

    private void OnEnable()
    {
        _targetPosition = new Vector3(-transform.position.x,
            transform.position.y, transform.position.z);
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, _targetPosition) <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            _targetPosition, speed * Time.fixedDeltaTime);
    }
}
