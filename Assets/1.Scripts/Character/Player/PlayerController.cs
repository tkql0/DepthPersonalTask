using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Animator _animator;

    private Vector2 _inputVector;

    public event Action OnItemAdd;
    public event Action OnDie;

    public bool isSwimming = false;

    private static readonly int isJump = Animator.StringToHash("isJump");
    private static readonly int isEnemyHitDie = Animator.StringToHash("isEnemyHitDie");
    private static readonly int isTreeHitDie = Animator.StringToHash("isTreeHitDie");

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
        { // 특정 키를 눌렸다면
            _inputVector = inContext.ReadValue<Vector2>();

            Move(_inputVector);
        }
    }

    private void OnTriggerEnter(Collider inOther)
    {
        if (inOther.TryGetComponent<Enemy>(out var outEnemy))
        {
            _animator.SetBool(isEnemyHitDie, true);
        }
        else if (inOther.TryGetComponent<Tree>(out var outTree))
        {
            _animator.SetBool(isTreeHitDie, true);
            Vector3 dir = new Vector3(_inputVector.x, 0, _inputVector.y);
            Vector3 newPosition = _rigidbody.position - dir;

            _rigidbody.MovePosition(newPosition);
            transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}