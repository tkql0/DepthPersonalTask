using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    private Vector3 _targetPosition;

    private float speed = 1;

    private void OnEnable()
    { // 여기를 안거치네 // 아 이미 생성되있는 오브젝트라 위치가 이상한거구나
        _targetPosition = new Vector3(-transform.position.x,
            transform.position.y, transform.position.z);
        Debug.Log($"{_targetPosition.x} + {_targetPosition.z}");
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, _targetPosition) <= 0)
        {
            gameObject.SetActive(false);
        }

        //transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            _targetPosition, speed * Time.fixedDeltaTime);
    }
}
