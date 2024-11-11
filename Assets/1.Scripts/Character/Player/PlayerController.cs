using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public int moveSpeed = 1;
    // ��ǳ� ģ������ ��ĭ�� �̵��ϱ� ������ int�� ����

    private Rigidbody _rigidbody;
    private Animator _animator;

    private static readonly int isJump = Animator.StringToHash("isJump");


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Move(Vector2 inInputVector)
    {
        Vector3 dir = new Vector3(inInputVector.x, 0, inInputVector.y);
        Vector3 newPosition = _rigidbody.position + dir;

        _rigidbody.MovePosition(newPosition);
        transform.rotation = Quaternion.LookRotation(dir);
        _animator.SetTrigger(isJump);
    }

    public void OnMove(InputAction.CallbackContext inContext)
    {
        if(inContext.phase == InputActionPhase.Started)
        { // Ư�� Ű�� ���ȴٸ�
            Move(inContext.ReadValue<Vector2>());
        }
    }
}