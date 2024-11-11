using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public int moveSpeed = 1;
    // 길건너 친구들은 한칸씩 이동하기 때문에 int로 설정

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Move(Vector2 inInputVector)
    {
        Vector3 dir = new Vector3(inInputVector.x, 0, inInputVector.y);
        Vector3 newPosition = _rigidbody.position + dir;

        _rigidbody.MovePosition(newPosition);
        transform.rotation = Quaternion.LookRotation(dir);
    }

    public void OnMove(InputAction.CallbackContext inContext)
    {
        if(inContext.phase == InputActionPhase.Started)
        { // 특정 키를 눌렸다면
            Move(inContext.ReadValue<Vector2>());
        }
    }
}