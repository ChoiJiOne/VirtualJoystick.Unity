using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private VirtualJoystick _virtualJoystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private bool _isRun = false;
    private Vector3 _moveDirection = Vector3.zero;

    private void Update()
    {
        UpdateMoveDirection();

        transform.position += _moveDirection * _moveSpeed * Time.deltaTime;

        UpdateAnimationState();
    }

    private void UpdateMoveDirection()
    {
        _moveDirection.x = _virtualJoystick.Horizontal;
        _moveDirection.y = _virtualJoystick.Vertical;
    }
    
    private void UpdateAnimationState()
    {
        bool isDirty = false;
        if (_isRun && _moveDirection.x == 0.0f && _moveDirection.y == 0.0f)
        {
            isDirty = true;
            _isRun = false;
        }

        if (!_isRun && (_moveDirection.x != 0.0f || _moveDirection.y != 0.0f))
        {
            isDirty = true;
            _isRun = true;
        }

        if (isDirty)
        {
            _animator.SetBool("IsRun", _isRun);
        }
    }
}
